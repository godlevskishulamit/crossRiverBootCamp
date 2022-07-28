using System.Collections.Generic;
using System.Threading.Tasks;
using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using CoronaApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoronaApp.Api.Controllers;

[Authorize]
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

    // PUT:
    [HttpGet("dates")]
    public async Task<List<Location>> getAllLocationBetweenDates([FromBody] LocationSearch dates)
    {
        return await _LocationRepository.getAllLocationBetweenDates(dates);
    }

    // PUT:
    [HttpPut("age")]
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


