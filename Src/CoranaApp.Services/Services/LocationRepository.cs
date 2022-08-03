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
using AutoMapper;

namespace CoronaApp.Services.Services;

public class LocationRepository : ILocationRepository
{
    public IDalLocation idl;
    private readonly IMapper _mapper;
    public LocationRepository(IDalLocation idl,IMapper mapper)
    {
        this.idl = idl;
        this._mapper = mapper;
    }
    public async Task<List<LocationDTO>> Get()
    {
        return _mapper.Map<List<Location>,List<LocationDTO>>(await idl.getAllLocations());
    }
    public async Task<List<LocationDTO>> getLocationsById(string id)
    {
        return _mapper.Map<List<Location>, List<LocationDTO>>(await idl.getLocationsById(id));
    }
    public async Task postLocation(Location loc)
    {

        await idl.postLocation(loc);
    }
    public async Task<List<LocationDTO>> getLocationByCity(string city)
    {
        return _mapper.Map<List<Location>, List<LocationDTO>>(await idl.getLocationByCity(city));
    }
    public async Task<List<LocationDTO>> GetByAge(int age)
    {
        return _mapper.Map<List<Location>, List<LocationDTO>>(await idl.getByAge(age));
    }
    public async Task<List<LocationDTO>> GetByDate(DateTime sdate, DateTime edate)
    {
        return  _mapper.Map<List<Location>, List<LocationDTO>>(await idl.getByDate(sdate, edate));
    }
}
