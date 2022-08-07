using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using CoronaApp.Services;
using CoronaApp.Services.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        ILocationService _LocationService;

        public LocationController(ILocationService LocationService)
        {
            _LocationService = LocationService;
        }

        // GET:
        [HttpGet]
        public async Task<ActionResult<List<Location>>> getAllLocation()
        {
            try
            {
                List<Location> locations = await _LocationService.getAllLocation();
                if (locations == null)
                {
                    return StatusCode(404, "not found");
                }
                if (!locations.Any())
                {
                    return StatusCode(204, "no content");
                }
                return Ok(locations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET:
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Location>>> getLocationsByPatientId(string id)
        {
            if (id == null)
                return StatusCode(400, "bad request");
            try
            {
                List<Location> locations = await _LocationService.getLocationsByPatientId(id);
                if (locations == null)
                {
                    return StatusCode(404, "not found");
                }
                if (!locations.Any())
                {
                    return StatusCode(204, "no content");
                }
                return Ok(locations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET:
        [HttpGet("city")]
        public async Task<ActionResult<List<Location>>> getLocationsByCity([FromQuery] string city)
        {
            if (city == null)
                return StatusCode(400, "bad request");
            try
            {
                List<Location> locations = await _LocationService.getLocationsByCity(city);
                if (locations == null)
                {
                    return StatusCode(404, "not found");
                }
                if (!locations.Any())
                {
                    return StatusCode(204, "no content");
                }
                return Ok(locations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET:
        [HttpPost("filter")]
        public async Task<ActionResult<List<Location>>> getLocationsByLocationSaerch([FromBody] LocationSearch locationSearch)
        {
            if (locationSearch == null)
                return StatusCode(400, "bad request");
            try
            {
                List<Location> locations = await _LocationService.getLocationsByLocationSaerch(locationSearch);

                if (locations == null)
                {
                    return StatusCode(404, "not found");
                }
                if (!locations.Any())
                {
                    return StatusCode(204, "no content");
                }
                return Ok(locations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        // POST:
        [HttpPost]
        public async Task<ActionResult<int>> addNewLocation([FromBody] PostLocationDTO newLocation)
        {
            if (newLocation == null)
                return StatusCode(400, "bad request");
            try
            {
                return await _LocationService.addNewLocation(newLocation);
            }
            catch (Exception ex)
            {
               return StatusCode(500, ex.Message);
            }
        }


    }

}

