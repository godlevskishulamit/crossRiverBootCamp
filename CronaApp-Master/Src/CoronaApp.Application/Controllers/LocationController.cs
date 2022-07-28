using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Dal.models;
using CoronaApp.Services;
using CoronaApp.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LocationController : ControllerBase
    {
        ILocationRepository locationRepository;
        public LocationController(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }
        // GET api/<PatientController>/5
        [HttpGet("city")]
        public async Task<ActionResult> GetByCity([FromQuery] string city)
        {
            List<Location> locations = await locationRepository.GetByCity(city);
            if (locations != null)
                return Ok(locations);
            return NoContent();
        }
        [HttpGet("patient/{id}")]
        public async Task<ActionResult> GetByPatientId(string id)
        {
            List<Location> locations = await locationRepository.GetByPatientId(id);
            if (locations != null)
                return Ok(locations);
            return NoContent();
        }
        [HttpGet("locationSearch")]
        public async Task<ActionResult> GetByLocationSearch([FromBody] LocationSearch locationSearch)
        {
            List<Location> locations = await locationRepository.GetByLocationSearch(locationSearch);
            if (locations != null)
                return Ok(locations);
            return NoContent();
        }

        // POST api/<PatientController>
        [HttpPost]
        public async Task Post([FromBody] Location location)
        {
            await locationRepository.Post(location);
        }

        // PUT api/<PatientController>/5
        [HttpPut]
        public async Task Put([FromBody] Location location)
        {
            await locationRepository.Put(location);
        }
        [HttpDelete]
        public async Task Delete([FromBody] Location location)
        {
            await locationRepository.Delete(location);
        }



    }
}
