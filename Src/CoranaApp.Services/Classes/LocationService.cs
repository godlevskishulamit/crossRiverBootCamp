using AutoMapper;
using CoronaApp.Dal.Classes;
using CoronaApp.Dal.Interfaces;
using CoronaApp.Dal.Models;
using CoronaApp.DTO;
using CoronaApp.Services.DTO;
using CoronaApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.Classes;

public class LocationService : ILocationService
{
    private readonly ILocationDAL _locationDal;
    IMapper mapper;
    public LocationService(ILocationDAL locationDal)
    {
        _locationDal = locationDal;

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AutoMapperProfile>();
        });
        mapper = config.CreateMapper();
    }
    public async Task<List<LocationDTO>> GetAllLocations(string city = "")
    {
        List<Location> locations = await _locationDal.GetAllLocations(city);
        return mapper.Map<List<LocationDTO>>(locations);
    }
    public async Task<List<LocationDTO>> GetLocationsByLocationSearch(LocationSearch location)
    {
        List<Location> locations = new List<Location>();
        if (location.Age != null)
        {
            locations = await _locationDal.GetLocationByAge(location);
        }
        if (location.StartDate != null && location.EndDate != null)
        {
            locations = await _locationDal.GetLocationsByDate(location);
        }
        return mapper.Map<List<LocationDTO>>(locations);
    }
    public async Task<List<LocationDTO>> GetLocationsPerPatient(string id)
    {
        List<Location> locations = await _locationDal.GetLocationsPerPatient(id);
        return mapper.Map<List<LocationDTO>>(locations);
    }
    public async Task<bool> AddLocation(AddLocationDTO locationDto)
    {
        Location location = mapper.Map<Location>(locationDto);
        return await _locationDal.AddLocation(location);
    }
    public async Task<bool> DeleteLocation(LocationDTO locationDto)
    {
        Location location = mapper.Map<Location>(locationDto);
        return await _locationDal.DeleteLocation(location);
    }
}
