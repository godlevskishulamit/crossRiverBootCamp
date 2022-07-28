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
    public async Task<List<Location>> GetLocationsByLocationSearch(LocationSearch locationSearch)
    {
        if (locationSearch == null || (locationSearch.StartDate == null && locationSearch.EndDate == null && locationSearch.Age == null))
            throw new ArgumentNullException(nameof(locationSearch));
        if (locationSearch.StartDate > locationSearch.EndDate||locationSearch.EndDate>DateTime.Now)
            throw new ArgumentException("arguments of dates is worng!!");
        if (locationSearch.StartDate != null && locationSearch.EndDate == null)
            locationSearch.EndDate = DateTime.Now;
        if (locationSearch.StartDate == null && locationSearch.EndDate != null)
            locationSearch.StartDate = locationSearch.EndDate;
        if (locationSearch.StartDate != null)
        {
            return await _locationDal.GetLocationsByDate(locationSearch);
        }
        return await _locationDal.GetLocationByAge(locationSearch);
    }
    public async Task<List<Location>> GetLocationsPerPatient(string id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));
        return await _locationDal.GetLocationsPerPatient(id);
    }
    public async Task<bool> AddLocation(Location location)
    {
        if (location == null)
            throw new ArgumentNullException(nameof(location));
        return await _locationDal.AddLocation(location);
    }
    public async Task<bool> DeleteLocation(Location location)
    {
        if (location == null)
            throw new ArgumentNullException(nameof(location));
        return await _locationDal.DeleteLocation(location);
    }
}
