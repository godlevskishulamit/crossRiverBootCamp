using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoronaApp.Dal.Models;
using CoronaApp.Dal;
using CoronaApp.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationController : ControllerBase
{
    private readonly ILocationRepository _locationRepository;

    public LocationController(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }        
    //get all locations
    // GET: api/<LocationController>
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var res = await _locationRepository.GetAllLocations();
        if (res == null)
        {
            return NotFound();
        }
        return Ok(res);
    }

    //get locations by city
    // GET api/<LocationController>/5
    
    [HttpGet("city")]
    public async Task<ActionResult> Get([FromQuery] string city)
    {
        var res = await _locationRepository.GetLocationsByCity(city);
        if (res == null)
        {
            return NotFound();
        }
        return Ok(res);   
    }

    //filter by date
    [HttpGet("GetLocationsByDate")]
    public async Task<ActionResult> Get([FromBody] LocationSearch locationSearch)
    {
        var res = await _locationRepository.GetLocationsByDate(locationSearch);
        if (res == null)
        {
            return NotFound();
        }
        return Ok(res);
    }

    //filter by age
    [HttpGet("GetLocationsByAge")]
    public async Task<ActionResult> GetByAge([FromBody] LocationSearch locationSearch)
    {
        var res = await _locationRepository.GetLocationsByAge(locationSearch);
        if (res == null)
        {
            return NotFound();
        }
        return Ok(res);
    }
}
