using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Dal;
using CoronaApp.Dal.Interfaces;
using CoronaApp.Services.Interfaces;
using CoronaApp.Services.Models;

namespace CoronaApp.Services.Services;

public class LocationRepository : ILocationRepository
{
    public IDalLocation idl;
    public LocationRepository(IDalLocation idl)
    {
        this.idl = idl;
    }
    public async Task<List<Location>> Get()
    {
        return await idl.getAllLocations();
    }
    public async Task<List<Location>> getLocationsById(string id)
    {
        return await idl.getLocationsById(id);
    }
    public async Task postLocation(Location loc)
    {
        await idl.postLocation(loc);
    }
    public async Task<List<Location>> getLocationByCity(string city)
    {
        return await idl.getLocationByCity(city);
    }
    public async Task<List<Location>> GetByAge(int age)
    {
        return await idl.getByAge(age);
    }
    public async Task<List<Location>> GetByDate(DateTime sdate, DateTime edate)
    {
        return await idl.getByDate(sdate, edate);
    }
}
