using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using CoronaApp.Services;
using Microsoft.AspNetCore.Mvc;


namespace CoronaApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationController : ControllerBase
{
    ILocationRepository _LocationRepository;

    public LocationController(ILocationRepository LocationRepository)
    {
        _LocationRepository = LocationRepository;
    }

    // GET:
    [HttpGet]
    public async Task<List<Location>> getAllLocation()
    {
        return await _LocationRepository.getAllLocation();
    }

    // GET:
    [HttpGet("{id}")]
    public async Task<List<Location>> getLocationsByPatientId(string id)
    {
        return await _LocationRepository.getLocationsByPatientId(id);
    }

    // GET:
    [HttpGet ("city")]
    public async Task<List<Location>> getAllLocationByCity([FromQuery] string city)
    {
        return await _LocationRepository.getAllLocationByCity(city);
    }

    // GET:
    [HttpPost("dates")]
    public async Task<List<Location>> getAllLocationBetweenDates([FromBody] LocationSearch dates)
    {
        return await _LocationRepository.getAllLocationBetweenDates(dates);
    }

    // GET:
    [HttpPost("age")]
    public async Task<List<Location>> getAllLocationByAge([FromBody] LocationSearch age)
    {
        return await _LocationRepository.getAllLocationByAge(age);
    }

    // POST:
    [HttpPost]
    public async Task<int> addNewLocation([FromBody] Location newLocation)
    {
        return await _LocationRepository.addNewLocation(newLocation);
    }


}


