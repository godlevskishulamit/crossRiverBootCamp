using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public class LocationRepository : ILocationRepository
    {
        ILocationDal _locationDal;// = new LocationDal();
        IPatientRepository _patientRepository;
        public LocationRepository(ILocationDal locationDal, IPatientRepository patientRepository)
        {
            this._locationDal = locationDal;
            this._patientRepository = patientRepository;
        }
        /*  public async Task<ICollection<Location>> GetAllLocations()
          {
              return await locationDal.GetAllLocation();
          }*/
        public async Task<List<Location>> GetLocationsByCity(string city)
        {
            return await this._locationDal.GetLocationsByCity(city);
        }
        public async Task<List<Location>> GetLocationsByPatientId(string patientId)
        {
            return await this._locationDal.GetLocationsByPatientId(patientId);
        }
        public async Task<List<Location>> GetLocationsByDate(DateTime startDate, DateTime endDate)
        {
            return await this._locationDal.GetLocationsByDate(startDate, endDate);
        }
        public async Task PostLocation(Location location)
        {
            List<Patient> pat = (List<Patient>)await _patientRepository.GetAllPatient();
            if (pat == null || pat.Find(p => p.Id == location.PatientId) == null)
            {
                await this._patientRepository.PostPatient(new Patient(location.PatientId));
            };
            await this._locationDal.PostLocation(location);
        }
        public async Task<List<Location>> GetLocations(Models.LocationSearch locationSearch)
        { 
            if(locationSearch.Age==null&&locationSearch.StartDate==null&&locationSearch.EndDate==null)
                return (List<Location>)await this._locationDal.GetAllLocation();

            if (locationSearch.StartDate != null && locationSearch.EndDate != null && locationSearch.Age != null)
                return (List<Location>)await this._locationDal.
                    GetLocationsByDateAndPatientAge(locationSearch.StartDate, locationSearch.EndDate, locationSearch.Age);
            
            if (locationSearch.Age == null)
                return await this._locationDal.GetLocationsByDate(locationSearch.StartDate, locationSearch.EndDate);
           
            if (locationSearch.StartDate == null && locationSearch.EndDate == null)
                return await this._locationDal.GetLocationsByPatientAge(locationSearch.Age);
           
            return null;
        }
        public async Task Delete(string patientId, int locationId)
        {
            await this._locationDal.Delete(patientId, locationId);
        }
    }
}
