using CoronaApp.Dal.Classes;
using CoronaApp.Dal.Interfaces;
using CoronaApp.Dal.Models;
using CoronaApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.Classes;
public class LocationService : ILocationService
{
    private readonly ILocationDAL _locationDal;
    public LocationService(ILocationDAL locationDal)
    {
        _locationDal = locationDal;
    }
    public async Task<List<Location>> GetAllLocations(string city = "")
    {
        return await _locationDal.GetAllLocations(city);
    }
    public async Task<List<Location>> GetLocationsByLocationSearch(LocationSearch location)
    {
        if (location.Age != 0)
        {
            return await _locationDal.GetLocationByAge(location);
        }
        return await _locationDal.GetLocationsByDate(location);
    }
    public async Task<List<Location>> GetLocationsPerPatient(string id)
    {
        return await _locationDal.GetLocationsPerPatient(id);
    }
    public async Task<bool> AddLocation(Location location)
    {
        return await _locationDal.AddLocation(location);
    }
    public async Task<bool> DeleteLocation(Location location)
    {
        return await _locationDal.DeleteLocation(location);
    }
}
