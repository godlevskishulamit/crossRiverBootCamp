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
        CoronaAppDBContext _CoronaAppDBContext;
        public LocationDal(CoronaAppDBContext CoronaAppDBContext)
        {
            _CoronaAppDBContext = CoronaAppDBContext;
        }

        public async Task<List<Location>> getAllLocation()
        {
            return await _CoronaAppDBContext.Locations.ToListAsync();
        }
        public async Task<List<Location>> getLocationsByPatientId(string id)
        {
           return await _CoronaAppDBContext.Locations.Where(location => location.Patient.Id.Equals(id)).ToListAsync();
             
        }
        public async Task<int> addNewLocation(Location newLocation)
        {
            await _CoronaAppDBContext.Locations.AddAsync(newLocation);
            await _CoronaAppDBContext.SaveChangesAsync();
            return newLocation.Id;
        }
        public async Task<List<Location>> getFilteredLOcation(LocationSearch locationSearch)
        {
            return await _CoronaAppDBContext.Locations.Include(p=>p.Patient).Where(location=>(location.Patient.Age!=null &&location.Patient.Age == locationSearch.Age)||
            (locationSearch.StartDate!=null &&locationSearch.EndDate!=null && DateTime.Compare(locationSearch.StartDate, location.StartDate) <= 0 && DateTime.Compare(locationSearch.EndDate, location.EndDate) >= 0)
            || location.Patient.Age != null && location.Patient.Age == locationSearch.Age&& locationSearch.StartDate != null && locationSearch.EndDate != null && DateTime.Compare(locationSearch.StartDate, location.StartDate) <= 0 && DateTime.Compare(locationSearch.EndDate, location.EndDate) >= 0).ToListAsync();
        }
        /*public async Task<List<Location>> getAllLocationBetweenDates(LocationSearch dates)
        {
            return await _CoronaAppDBContext.Locations.Where(location => DateTime.Compare(dates.StartDate, location.StartDate) <= 0 && DateTime.Compare(dates.EndDate, location.EndDate) >= 0).ToListAsync() ;
        }*/
        public async Task<List<Location>> getAllLocationByCity(string city)
        {
            return await _CoronaAppDBContext.Locations.Where(location => location.City.Contains(city)).ToListAsync();
        }

    }
}
