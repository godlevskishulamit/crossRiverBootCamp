
using CoronaApp.Dal.Models;
using CoronaApp.Services;
using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace CoronaApp.Dal
{
    public class LocationRepository: ILocationRepository
    {
        ILocationDal _LocationDal;
        public LocationRepository(ILocationDal LocationDal)
        {
            _LocationDal =LocationDal;
        }
        public async Task<List<Location>> getAllLocation()
        {
            return await _LocationDal.getAllLocation();
        }
        public async Task<List<Location>> getLocationsByPatientId(string id)
        {
            return await _LocationDal.getLocationsByPatientId(id);
        }
        public async Task<List<Location>> getAllLocationByCity( string city)
        {
            return await _LocationDal.getAllLocationByCity(city);
        }
        public async Task<int> addNewLocation(Location newLocation)
        {
            return await _LocationDal.addNewLocation(newLocation);
        }
        

        public async Task<List<Location>> getFilterdLocation(LocationSearch locationSearch)
        {
            return await _LocationDal.getFilteredLOcation(locationSearch);
        }
    }
}
