using AutoMapper;
using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public class LocationService : ILocationService
    {
        ILocationRepository _locationRepository;
        IPatientService _patientService;
        IMapper _mapper;
        public LocationService(ILocationRepository locationRepository, IPatientService patientService,IMapper mapper)
        {
            _locationRepository = locationRepository;
            _patientService = patientService;
            _mapper = mapper;
        }
        /*  public async Task<ICollection<Location>> GetAllLocations()
          {
              return await locationDal.GetAllLocation();
          }*/
        public async Task<List<LocationDTO>> GetLocationsByCity(string city)
        {
           List<Location> locations= await _locationRepository.GetLocationsByCity(city);
            List<LocationDTO> locationsDTO = new List<LocationDTO>();
            foreach(Location loc in locations)
            {
                locationsDTO.Add(_mapper.Map<LocationDTO>(loc));
            }
            return locationsDTO;
        }
        public async Task<List<LocationDTO>> GetLocationsByPatientId(string patientId)
        {
            List<Location> locations= await _locationRepository.GetLocationsByPatientId(patientId);
            List<LocationDTO> locationsDTO = new List<LocationDTO>();
            foreach(Location loc in locations)
            {
                locationsDTO.Add(_mapper.Map<LocationDTO>(loc));
            }
            return locationsDTO;
        }
        public async Task<List<LocationDTO>> GetLocationsByDate(DateTime startDate, DateTime endDate)
        {
            List<Location> locations = await _locationRepository.GetLocationsByDate(startDate, endDate); ;
            List<LocationDTO> locationsDTO = new List<LocationDTO>();
            foreach(Location loc in locations)
            {
                locationsDTO.Add(_mapper.Map<LocationDTO>(loc));
            }
            return locationsDTO;
        }
        public async Task PostLocation(LocationDTOPost location)
        {
            List<Patient> pat = (List<Patient>)await _patientService.GetAllPatient();
            if (pat == null || pat.Find(p => p.Id == location.PatientId) == null)
            {
                await _patientService.PostPatient(new PatientDTO(location.PatientId));
            };
            await _locationRepository.PostLocation(_mapper.Map<Location>(location));
        }
        public async Task<List<LocationDTO>> GetLocations(Models.LocationSearch locationSearch)
        {
            List<Location> locations = new List<Location>();
            if(locationSearch.Age==null&&locationSearch.StartDate==null&&locationSearch.EndDate==null)
                locations=(List<Location>)await _locationRepository.GetAllLocation();

            if (locationSearch.StartDate != null && locationSearch.EndDate != null && locationSearch.Age != null)
                locations=(List<Location>)await _locationRepository.
                    GetLocationsByDateAndPatientAge(locationSearch.StartDate, locationSearch.EndDate, locationSearch.Age);
            
            if (locationSearch.Age == null)
                locations= await _locationRepository.GetLocationsByDate(locationSearch.StartDate, locationSearch.EndDate);
           
            if (locationSearch.StartDate == null && locationSearch.EndDate == null)
                locations= await _locationRepository.GetLocationsByPatientAge(locationSearch.Age);
            if (locations.Count > 0)
            {
                List<LocationDTO> locationsDTO = new List<LocationDTO>();
                foreach (Location loc in locations)
                    locationsDTO.Add(_mapper.Map<LocationDTO>(loc));
                return locationsDTO;
            }
            return null;
        }
        public async Task Delete(string patientId, int locationId)
        {
            await _locationRepository.Delete(patientId, locationId);
        }
    }
}
