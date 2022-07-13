using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public class LocationRepository : ILocationRepository
    {
        ILocationDal locationDal;// = new LocationDal();
        IPatientRepository patientRepository;
        public LocationRepository(ILocationDal locationDal, IPatientRepository patientRepository)
        {
            this.locationDal = locationDal;
            this.patientRepository = patientRepository;
        }
        /*  public async Task<ICollection<Location>> GetAllLocations()
          {
              return await locationDal.GetAllLocation();
          }*/
        public async Task<List<Location>> GetLocationsByCity(string city)
        {
            return await this.locationDal.GetLocationsByCity(city);
        }
        public async Task<List<Location>> GetLocationsByPatientId(string patientId)
        {
            return await this.locationDal.GetLocationsByPatientId(patientId);
        }
        public async Task<List<Location>> GetLocationsByDate(DateTime startDate, DateTime endDate)
        {
            return await this.locationDal.GetLocationsByDate(startDate, endDate);
        }
        public async Task PostLocation(Location location)
        {
            List<Patient> pat = (List<Patient>)await patientRepository.GetAllPatient();
            if (pat == null || pat.Find(p => p.Id == location.PatientId) == null)
            {
                await this.patientRepository.PostPatient(new Patient(location.PatientId));
            };
            await this.locationDal.PostLocation(location);
        }
        public async Task<List<Location>> GetLocations(Models.LocationSearch locationSearch)
        {
            if(locationSearch.Age==null&&locationSearch.StartDate==null&&locationSearch.EndDate==null)
                return (List<Location>)await this.locationDal.GetAllLocation();

            if (locationSearch.StartDate != null && locationSearch.EndDate != null && locationSearch.Age != null)
                return (List<Location>)await this.locationDal.
                    GetLocationsByDateAndPatientAge(locationSearch.StartDate, locationSearch.EndDate, locationSearch.Age);
            
            if (locationSearch.Age == null)
                return await this.locationDal.GetLocationsByDate(locationSearch.StartDate, locationSearch.EndDate);
           
            if (locationSearch.StartDate == null && locationSearch.EndDate == null)
                return await this.locationDal.GetLocationsByPatientAge(locationSearch.Age);
           
            return null;
        }
        public async Task Delete(string patientId, int locationId)
        {
            await this.locationDal.Delete(patientId, locationId);
        }
    }
}
