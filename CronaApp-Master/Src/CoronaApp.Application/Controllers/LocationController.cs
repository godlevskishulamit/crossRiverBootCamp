using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Services;
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
                return StatusCode(404, "not found");
            }
            if (!listLoc.Any())
            {
                return StatusCode(204, "no content");
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
        try
        {
            List<Location> listLoc = await il.getLocationsById(id);
            if (listLoc == null)
            {
                return StatusCode(404, "not found");
            }
            if (!listLoc.Any())
            {
                return StatusCode(204, "no content");
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
        try
        {
            List<Location> listLoc = await il.getLocationByCity(city);
            if (listLoc == null)
            {
                return StatusCode(404, "not found");
            }
            if (!listLoc.Any())
            {
                return StatusCode(204, "no content");
            }
            return Ok(listLoc);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpPost]
    public void Add([FromBody] Location loc)
    {
        try
        {
            il.postLocation(loc);
        }
        catch(Exception ex)
        {
             StatusCode(500, ex.Message);
        }
    }
    [HttpGet("age")]
    public async Task<ActionResult<List<Location>>> GetByAge([FromBody] LocationSearch ls)
    {
        try
        {
            List<Location> listLoc = await il.GetByAge(ls.Age);
            if (listLoc == null)
            {
                return StatusCode(404, "not found");
            }
            if (!listLoc.Any())
            {
                return StatusCode(204, "no content");
            }
            return Ok(listLoc);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpGet("date")]
    public async Task<ActionResult<List<Location>>> GetByDate([FromBody] LocationSearch ls)
    {
        try
        {
            List<Location> listLoc = await il.GetByDate(Convert.ToDateTime(ls.StartDate), Convert.ToDateTime(ls.EndDate));
            if (listLoc == null)
            {
                return StatusCode(404, "not found");
            }
            if (!listLoc.Any())
            {
                return StatusCode(204, "no content");
            }
            return Ok(listLoc);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

}
