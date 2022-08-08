using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Dal.DTO;
using CoronaApp.Services.Interfaces;
using CoronaApp.Services.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationController : ControllerBase
{
    ILocationRepository il;
    public LocationController(ILocationRepository il)
    {
        this.il = il;
    }
    // GET: api/<LocationController>
    [HttpGet]
    public async Task<ActionResult<List<Location>>> Get()
    {
        try
        {
            List<Location> listLoc = await il.Get();
            if(listLoc == null)
            {
                return StatusCode(404);
            }
            if (!listLoc.Any())
            {
                return StatusCode(204);
            }
            return Ok(listLoc);
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
        
    }

    [HttpGet("id/{id}")]
    public async Task<ActionResult<List<Location>>> GetById(string id)
    {
        if (id == null || id.Length != 9)
        {
            return StatusCode(400, "bad request");
        }
        try
        {
            List<Location> listLoc = await il.getLocationsById(id);
            if (listLoc == null)
            {
                return StatusCode(404);
            }
            if (!listLoc.Any())
            {
                return StatusCode(204);
            }
            return Ok(listLoc);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpGet("city/{city}")]
    public async Task<ActionResult<List<Location>>> GetByCity(string city)
    {
        if(city == null)
        {
            return StatusCode(400);
        }
        try
        {
            List<Location> listLoc = await il.getLocationByCity(city);
            if (listLoc == null)
            {
                return StatusCode(404);
            }
            if (!listLoc.Any())
            {
                return StatusCode(204);
            }
            return Ok(listLoc);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpPost]
    public async Task<ActionResult<LocationDTO>> Add([FromBody] LocationDTO loc)
    {
        if (!ModelState.IsValid)
        {
           return StatusCode(400, ModelState);
        }
        try
        {
          var location = await il.postLocation(loc);
            return location;
        }
        catch(Exception ex)
        {
           return StatusCode(500, ex.Message);
        }
    }
   

    [HttpGet("filter")]
    public async Task<ActionResult<List<Location>>> GetByFilteredData([FromBody] LocationSearch ls)
    {
        try
        {
            List<Location> listLoc = await il.GetByFilteredData(ls);
            if (listLoc == null)
            {
                return StatusCode(404);
            }
            if (!listLoc.Any())
            {
                return StatusCode(204);
            }
            return Ok(listLoc);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
