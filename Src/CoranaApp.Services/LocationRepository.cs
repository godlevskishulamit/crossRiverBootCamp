using CoronaApp.Dal.Models;
using CoronaApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Dal;
public class LocationRepository : ILocationRepository
{
    ILocationDal _LocationDal;
    public LocationRepository(ILocationDal LocationDal)
    {
        _LocationDal = LocationDal;
    }

    public async Task<List<Location>> getAllLocation()
    {
        return await _LocationDal.getAllLocation();
    }

    public async Task<List<Location>> getLocationsByPatientId(string id)
    {
        return await _LocationDal.getLocationsByPatientId(id);
    }

    public async Task<List<Location>> getAllLocationByCity(string city)
    {
        return await _LocationDal.getAllLocationByCity(city);
    }

    public async Task<int> addNewLocation(Location newLocation)
    {
        return await _LocationDal.addNewLocation(newLocation);
    }

    public async Task<List<Location>> getAllLocationBetweenDates(LocationSearch dates)
    {
        return await _LocationDal.getAllLocationBetweenDates(dates);
    }

    public async Task<List<Location>> getAllLocationByAge(LocationSearch age)
    {
        return await _LocationDal.getAllLocationByAge(age);
    }

}
