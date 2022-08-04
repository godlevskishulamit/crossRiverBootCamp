using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal
{
    public class LocationRepository : ILocationRepository
    {
       
    
        public async Task<ICollection<Location>> GetAllLocation()
        {
            using (var _dbContext = new CoronaDBContext())
            {
            return await _dbContext.Locations.ToListAsync();

            }
        }
        public async Task<List<Location>> GetLocationsByCity(string city)
        {
            using (var _dbContext = new CoronaDBContext())
            {
                city = city.ToLower();
                return await _dbContext.Locations
                     .Where(location => location.City.ToLower() == city).ToListAsync();
            }
        }
        public async Task<List<Location>> GetLocationsByPatientId(string patientId)
        {
            using (var _dbContext = new CoronaDBContext())
            {
                List<Location> locations = await _dbContext.Locations
                .Where(location => location.PatientId == patientId).ToListAsync();
                if (locations.Count == 0)
                    throw new Exception("Patient id not Exsit");
                return locations;
            }
        }
        public async Task<List<Location>> GetLocationsByDate(DateTime? startDate, DateTime? endDate)
        {
            using (var _dbContext = new CoronaDBContext())
            {
                return await _dbContext.Locations
                 .Where(location => location.StartDate >= startDate && location.StartDate <= endDate
                 || location.EndDate >= startDate && location.EndDate <= endDate).ToListAsync();
            }
            }

        public async Task<List<Location>> GetLocationsByPatientAge(int? age)
        {
            using (var _dbContext = new CoronaDBContext())
            {
                return await _dbContext.Locations.Include(loc => loc.Patient)
                 .Where(location => location.Patient.Age == age).ToListAsync();
            }
        }
        public async Task<List<Location>> GetLocationsByDateAndPatientAge(DateTime? startDate, DateTime? endDate,int? age)
        {
            using (var _dbContext = new CoronaDBContext())
            {
                return this.GetLocationsByPatientAge(age).Result.Where(location => location.StartDate >= startDate && location.StartDate <= endDate
                 || location.EndDate >= startDate && location.EndDate <= endDate).ToList();
            }
        }
        public async Task PostLocation(Location location)
        {
            using (var _dbContext = new CoronaDBContext())
            {
                _dbContext.Locations.Add(location);
                await _dbContext.SaveChangesAsync();
            }
        }        
        public async Task Delete(string patientId, int locationId)
        {
            using (var _dbContext = new CoronaDBContext())
            {
                Location l = await _dbContext.Locations
                .Where(location => location.Id == locationId).FirstOrDefaultAsync();
               _dbContext.Locations.Remove(l);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
