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
        public LocationRepository()
        {

        }

        public async Task<List<Location>> getAllLocation()
        {
            using (var _CoronaAppDBContext = new CoronaAppDBContext())
            {
                return await _CoronaAppDBContext.Locations.ToListAsync();
            }
        }
        public async Task<List<Location>> getLocationsByPatientId(string id)
        {
            using (var _CoronaAppDBContext = new CoronaAppDBContext())
            {
                return await _CoronaAppDBContext.Locations.Where(location => location.Patient.Id.Equals(id)).ToListAsync();
            }
        }
        public async Task<int> addNewLocation(Location newLocation)
        {
            using (var _CoronaAppDBContext = new CoronaAppDBContext())
            {
                try
                {
                    await _CoronaAppDBContext.Locations.AddAsync(newLocation);
                    await _CoronaAppDBContext.SaveChangesAsync();
                    return newLocation.Id;
                }
                catch (Exception)
                {
                    throw new DbUpdateException();
                }
            }
        }
        public async Task<List<Location>> getLocationsBetweenDates(LocationSearch locationSearch)
        {
            using (var _CoronaAppDBContext = new CoronaAppDBContext())
            {
                return await _CoronaAppDBContext.Locations.Where(location => ( DateTime.Compare((DateTime)locationSearch.StartDate, location.StartDate) <= 0 && DateTime.Compare((DateTime)locationSearch.EndDate, location.EndDate) >= 0)).ToListAsync();
            }
        }
        public async Task<List<Location>> getLocationsByAge(LocationSearch locationSearch)
        {
            using (var _CoronaAppDBContext = new CoronaAppDBContext())
            {
               List<Location> locations = await _CoronaAppDBContext.Locations.Include(location=>location.Patient).Where(location => (DateTime.Now.Year - location.Patient.dateOfBirth.Year) >= locationSearch.Age).ToListAsync();
                return locations;
                /*   return await _CoronaAppDBContext.Locations.Where(location => ((DateTime.Now.Year - location.Patient.dateOfBirth.Year) != null && (DateTime.Now.Year - location.Patient.dateOfBirth.Year) == locationSearch.Age) ||
             (locationSearch.StartDate != null && locationSearch.EndDate != null && DateTime.Compare((DateTime)locationSearch.StartDate, location.StartDate) <= 0 && DateTime.Compare((DateTime)locationSearch.EndDate, location.EndDate) >= 0)
             || (DateTime.Now.Year - location.Patient.dateOfBirth.Year) != null && (DateTime.Now.Year - location.Patient.dateOfBirth.Year) == locationSearch.Age && locationSearch.StartDate != null && locationSearch.EndDate != null && DateTime.Compare((DateTime)locationSearch.StartDate, location.StartDate) <= 0 && DateTime.Compare((DateTime)locationSearch.EndDate, location.EndDate) >= 0).ToListAsync();*/
            }
        }
        public async Task<List<Location>> getLocationsByLocationSaerch(LocationSearch locationSearch)
        {
            using (var _CoronaAppDBContext = new CoronaAppDBContext())
            {
                return  await _CoronaAppDBContext.Locations.Include(location => location.Patient).Where(location => (DateTime.Compare((DateTime)locationSearch.StartDate, location.StartDate) <= 0 && DateTime.Compare((DateTime)locationSearch.EndDate, location.EndDate) >= 0)
                && (DateTime.Now.Year - location.Patient.dateOfBirth.Year) >= locationSearch.Age).ToListAsync();
            }
        }

        public async Task<List<Location>> getLocationsByCity(string city)
        {
            using (var _CoronaAppDBContext = new CoronaAppDBContext())
            {
                return await _CoronaAppDBContext.Locations.Where(location => location.City.ToUpper().Contains(city.ToUpper())).ToListAsync();
            }
        }
    }
}
