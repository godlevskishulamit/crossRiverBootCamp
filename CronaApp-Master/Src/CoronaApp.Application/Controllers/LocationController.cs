using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CoronaApp.Dal.Models;
using CoronaApp.Services;
using CoronaApp.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoronaApp.Api.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class LocationController : ControllerBase
{
    ILocationService _locationService;
    IMapper _mapper;
    public LocationController(ILocationService locationService, IMapper mapper)
    {
        this._locationService = locationService;
        this._mapper = mapper;
    }
    [HttpGet]
    public async Task<ActionResult<ICollection<Location>>> GetLocations([FromQuery] LocationSearch locationSearch)
    {
        try
        {
            List<LocationDTO> locations = await _locationService.GetLocations(locationSearch);
            if (locations == null)
                return NotFound();
            if (locations.Count == 0)
                return NoContent();
            return Ok(locations);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpGet("city")]
    public async Task<ActionResult<List<LocationDTO>>> GetLocationsByCity([FromQuery] string city)
    {
        if (city == null)
            return BadRequest();
        try
        {
            List<LocationDTO> locationDTOs = await _locationService.GetLocationsByCity(city);
            if (locationDTOs == null)
                return NotFound();
            if (locationDTOs.Count == 0)
                return NoContent();
            return Ok(locationDTOs);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }


    }
    [HttpGet("patientId")]
    public async Task<ActionResult<List<Location>>> GetLocationsByPatientId()
    {
        var Claims = User.Claims.ToList();
        //Filter specific claim    
        string patientId = Claims?.FirstOrDefault(x => x.Type.Equals("UserId", StringComparison.OrdinalIgnoreCase))?.Value;
        try
        {
            List<LocationDTO> locationDTOs = await _locationService.GetLocationsByPatientId(patientId);
            if (locationDTOs == null)

                return NotFound();
            if (locationDTOs.Count == 0)
                return StatusCode(204, "No Such Patient");
            return Ok(locationDTOs);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> PostLocation(LocationDTOPost location)
    {
        if (location == null)
            return BadRequest();
        try
        {
            await _locationService.PostLocation(location);
            return Ok();

        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpDelete("{patientId}/{locationId}")]
    public async Task<ActionResult> Delete(string patientId, int locationId)
    {
        if (patientId == null || locationId == null)
            return BadRequest();
        try
        {
            await _locationService.Delete(patientId, locationId);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }

    }




}
