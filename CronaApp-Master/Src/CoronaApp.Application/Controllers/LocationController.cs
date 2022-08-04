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
        List<LocationDTO> locations = await _locationService.GetLocations(locationSearch);
        if (locations == null)
            return NotFound();
        return Ok(locations);
    }
    [HttpGet("city")]
    public async Task<ActionResult<List<LocationDTO>>> GetLocationsByCity([FromQuery] string city)
    {
        try
        {
           List<LocationDTO> locations =await _locationService.GetLocationsByCity(city);
            
          return Ok(locations);
        }
        catch (Exception ex) {
        return BadRequest(ex.Message);
        }

       
    }
    [HttpGet("patientId")]
    public async Task<ActionResult<List<Location>>> GetLocationsByPatientId(/*string patientId*/)
    {
        // var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
       var Claims = User.Claims.ToList();
        //Filter specific claim    
        string patientId = Claims?.FirstOrDefault(x => x.Type.Equals("UserId", StringComparison.OrdinalIgnoreCase))?.Value;
        
        List<LocationDTO> locations= await _locationService.GetLocationsByPatientId(patientId);
        if(locations == null) { 
            return StatusCode(404, "No Such Patient"); 
        }
        return Ok(locations);
    }

    [HttpPost]
    public async Task PostLocation(LocationDTOPost location)
    {
        await _locationService.PostLocation(location);
    }
    [HttpDelete("{patientId}/{locationId}")]
    public async Task Delete(string patientId, int locationId)
    {
        await _locationService.Delete(patientId, locationId);
    }




}
