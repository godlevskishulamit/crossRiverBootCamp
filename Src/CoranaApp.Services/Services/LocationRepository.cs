using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Dal;
using CoronaApp.Dal.DTO;
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
    public async Task<List<LocationDTO>> Get()
    {
        return (await idl.getAllLocations()).Select((loc)=>new LocationDTO(loc.LocaionId,loc.StartDate,loc.EndDate,loc.City,loc.Address)).ToList();
    }
    public async Task<List<LocationDTO>> getLocationsById(string id)
    {
        return await idl.getLocationsById(id);
    }
    public async Task postLocation(LocationDTO loc)
    {
        await idl.postLocation(loc);
    }
    public async Task<List<LocationDTO>> getLocationByCity(string city)
    {
        return await idl.getLocationByCity(city);
    }
    public async Task<List<LocationDTO>> GetByAge(int age)
    {
        return await idl.getByAge(age);
    }
    public async Task<List<LocationDTO>> GetByDate(DateTime sdate, DateTime edate)
    {
        return await idl.getByDate(sdate, edate);
    }
}
