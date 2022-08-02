using AutoMapper;
using CoronaApp.Dal.Classes;
using CoronaApp.Dal.Interfaces;
using CoronaApp.Dal.Models;
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
        List<Location> res = await _locationDal.GetAllLocations(city);
        return mapper.Map<List<Location>, List<LocationDTO>>(res);
    }
    public async Task<List<LocationDTO>> GetLocationsByLocationSearch(LocationSearch locationSearch)
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
            return mapper.Map< List<Location>,List<LocationDTO>>(await _locationDal.GetLocationsByDate(locationSearch));
        }
        return mapper.Map<List<Location>, List<LocationDTO>>(await _locationDal.GetLocationByAge(locationSearch));
    }
    public async Task<List<LocationDTO>> GetLocationsPerPatient(string id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));
        return mapper.Map<List<Location>, List<LocationDTO>>(await _locationDal.GetLocationsPerPatient(id));
    }
    public async Task<bool> AddLocation(LocationDTO location)
    {
        if (location == null)
            throw new ArgumentNullException(nameof(location));
        return await _locationDal.AddLocation(mapper.Map<LocationDTO,Location>(location));
    }
    public async Task<bool> DeleteLocation(LocationDTO location)
    {
        if (location == null)
            throw new ArgumentNullException(nameof(location));
        return await _locationDal.DeleteLocation(mapper.Map<LocationDTO, Location>(location));
    }
}
