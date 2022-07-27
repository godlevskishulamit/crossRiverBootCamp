using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ILocationDal _locationDal;

        public LocationRepository(ILocationDal locationDal)
        {
            _locationDal = locationDal;
        }
        //A function that return all locations
        public async Task<List<Location>> GetAllLocations()
        {
            return await _locationDal.GetAllLocations();

        }

        //A function that return locations by city
        public async Task<List<Location>> GetLocationsByCity(string city)
        {
            return await _locationDal.GetLocationsByCity(city);
        }

        //A function that return locations by date
        public async Task<List<Location>> GetLocationsByDate(LocationSearch locationSearch)
        {
            return await _locationDal.GetLocationsByDate(locationSearch);
        }

        //A function that return locations by patient's age
        public async Task<List<Location>> GetLocationsByAge(LocationSearch locationSearch)
        {
            return await _locationDal.GetLocationsByAge(locationSearch);
        }
    }
}
