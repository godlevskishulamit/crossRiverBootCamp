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
    public async Task<ActionResult<List<Location>>> getAllLocation()
    {
        var result =  await _LocationRepository.getAllLocation();
        if (result == null)
        {
            return StatusCode(404, "not found");
        }
        if (!result.Any())
        {
            return StatusCode(204, "no content");
        }
        return Ok(result);
    }

    // GET:
    [HttpGet("{id}")]
    public async Task<ActionResult<List<Location>>> getLocationsByPatientId(string id)
    {
        var result = await _LocationRepository.getLocationsByPatientId(id);
        if (result == null)
        {
            return StatusCode(404, "not found");
        }
        if (!result.Any())
        {
            return StatusCode(204, "no content");
        }
        return Ok(result);
    }

    // GET:
    [HttpGet ("city")]
    public async Task<ActionResult<List<Location>>> getAllLocationByCity([FromQuery] string city)
    {
        var result = await _LocationRepository.getAllLocationByCity(city);
        if (result == null)
        {
            return StatusCode(404, "not found");
        }
        if (!result.Any())
        {
            return StatusCode(204, "no content");
        }
        return Ok(result);
    }

    // GET:
    [HttpPost("dates")]
    public async Task<ActionResult<List<Location>>> getAllLocationBetweenDates([FromBody] LocationSearch dates)
    {
        var result = await _LocationRepository.getAllLocationBetweenDates(dates);
        if (result == null)
        {
            return StatusCode(404, "not found");
        }
        if (!result.Any())
        {
            return StatusCode(204, "no content");
        }
        return Ok(result);
    }

    // GET:
    [HttpPost("age")]
    public async Task<ActionResult<List<Location>>> getAllLocationByAge([FromBody] LocationSearch age)
    {
        var result = await _LocationRepository.getAllLocationByAge(age); if (result == null)
        {
            return StatusCode(404, "not found");
        }
        if (!result.Any())
        {
            return StatusCode(204, "no content");
        }
        return Ok(result);
    }

    // POST:
    [HttpPost]
    public async Task<ActionResult<int>> addNewLocation([FromBody] Location newLocation)
    {
        var result = await _LocationRepository.addNewLocation(newLocation);
        if (result == null)
        {
            return StatusCode(404, "not found");
        }
        if (result==0)
        {
            return StatusCode(204, "no content");
        }
        return Ok(result);
    }


}


