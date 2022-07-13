using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal
{
    public class LocationDal : ILocationDal
    {
        CoronaDBContext _dbContext;
        public LocationDal(CoronaDBContext DbContext)
        {
            this._dbContext = DbContext;
        }
        public async Task<ICollection<Location>> GetAllLocation()
        {
            return await this._dbContext.Locations.ToListAsync();
        }
        public async Task<List<Location>> GetLocationsByCity(string city)
        {

            city = city.ToLower();
            return await this._dbContext.Locations
                 .Where(location => location.City.ToLower() == city).ToListAsync();
        }
        public async Task<List<Location>> GetLocationsByPatientId(string patientId)
        {
            return await this._dbContext.Locations
                .Where(location => location.PatientId == patientId).ToListAsync();
        }
        public async Task<List<Location>> GetLocationsByDate(DateTime? startDate, DateTime? endDate)
        {
            return await this._dbContext.Locations
                 .Where(location => location.StartDate >= startDate && location.StartDate <= endDate
                 || location.EndDate >= startDate && location.EndDate <= endDate).ToListAsync();
        }

        public async Task<List<Location>> GetLocationsByPatientAge(int? age)
        {
            return await this._dbContext.Locations.Include(loc=>loc.Patient)
                 .Where(location => location.Patient.Age==age).ToListAsync();
        }
        public async Task<List<Location>> GetLocationsByDateAndPatientAge(DateTime? startDate, DateTime? endDate,int? age)
        {
            return  this.GetLocationsByPatientAge(age).Result.Where(location => location.StartDate >= startDate && location.StartDate <= endDate
                 || location.EndDate >= startDate && location.EndDate <= endDate).ToList();
        }
        public async Task PostLocation(Location location)
        {
            this._dbContext.Locations.Add(location);
            await this._dbContext.SaveChangesAsync();
        }        
        public async Task Delete(string patientId, int locationId)
        {
            Location l = await this._dbContext.Locations
                .Where(location => location.Id == locationId).FirstOrDefaultAsync();
            this._dbContext.Locations.Remove(l);
            await this._dbContext.SaveChangesAsync();
        }
    }
}
