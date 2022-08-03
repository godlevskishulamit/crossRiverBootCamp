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
            List<LocationDTO> listLoc = await il.Get();
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
    public async Task<ActionResult<List<LocationDTO>>> GetById(string id)
    {
        if (id == null || id.Length != 9)
        {
            return StatusCode(400, "bad request");
        }
        try
        {
            List<LocationDTO> listLoc = await il.getLocationsById(id);
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
    public async Task<ActionResult<List<LocationDTO>>> GetByCity(string city)
    {
        if(city == null)
        {
            return StatusCode(400);
        }
        try
        {
            List<LocationDTO> listLoc = await il.getLocationByCity(city);
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
    // bad request if dont get all Location object?
    [HttpPost]
    public async Task Add([FromBody] Location loc)
    {
        try
        {
          await il.postLocation(loc);
        }
        catch(Exception ex)
        {
             StatusCode(500, ex.Message);
        }
    }
    [HttpGet("age")]
    public async Task<ActionResult<List<LocationDTO>>> GetByAge([FromBody] LocationSearch ls)
    {
        try
        {
            List<LocationDTO> listLoc = await il.GetByAge((int)ls.Age);
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
    [HttpGet("date")]
    public async Task<ActionResult<List<LocationDTO>>> GetByDate([FromBody] LocationSearch ls)
    {
        try
        {
            List<LocationDTO> listLoc = await il.GetByDate(Convert.ToDateTime(ls.StartDate), Convert.ToDateTime(ls.EndDate));
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
