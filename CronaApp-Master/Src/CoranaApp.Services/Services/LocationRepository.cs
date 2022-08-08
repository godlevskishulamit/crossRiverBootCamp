using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoronaApp.Dal;
using CoronaApp.Dal.DTO;
using CoronaApp.Dal.Interfaces;
using CoronaApp.Services.Interfaces;
using CoronaApp.Services.Mappers;
using CoronaApp.Services.Models;

namespace CoronaApp.Services.Services;

public class LocationRepository : ILocationRepository
{
    public IDalLocation idl;
    public IMapper _mapper;
    public LocationRepository(IDalLocation idl)
    {
        this.idl = idl;
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<LocationProfile>();
        });
        _mapper = config.CreateMapper();
    }
    public async Task<List<Location>> Get()
    {
        return await idl.getAllLocations();
    }
    public async Task<List<Location>> getLocationsById(string id)
    {
        return await idl.getLocationsById(id);
    }
    public async Task<LocationDTO> postLocation(LocationDTO loc)
    {
        Location location = _mapper.Map<Location>(loc);
        Location newLocation = await idl.postLocation(location);
        LocationDTO newLocationDTO = _mapper.Map<LocationDTO>(newLocation);
        return newLocationDTO;
    }
    public async Task<List<Location>> getLocationByCity(string city)
    {
        return await idl.getLocationByCity(city);
    }
    public async Task<List<Location>> GetByFilteredData(LocationSearch location)
    {
        return await idl.getByFilteredData(location);
    }
}
