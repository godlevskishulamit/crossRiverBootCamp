using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_korona.Entities;
using web_korona.DL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_korona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        IdlLocation idl;

        public LocationController(IdlLocation idl)
        {
            this.idl = idl;
        }

        // GET: api/<LocationController>
        [HttpGet]
        public List<Location> Get()
        {
            return idl.getAllLocations();
        }

        // GET api/<LocationController>/5
        [HttpGet("city/{city}")]
        public List<Location> GetByCity(string city)
        {
            return idl.getLocationByCity(city);
        }

        // POST api/<LocationController>
        [HttpPost("/{id}")]
        public void Post(string id, [FromBody] Location loc)
        {
            idl.postLocation(id, loc);
        }

        [HttpGet("id/{id}")]
        public List<Location> GetById(string id)
        {
            return idl.getLocationsById(id);
        }
        [HttpDelete("/{id}")]
        public void DeleteById(string id, [FromBody]  DateTime startDate)
        {
            idl.deleteLocation(id,startDate);
        }
    }
}
