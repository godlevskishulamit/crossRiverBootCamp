using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Dal.Models;
using CoronaApp.Dal.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {


        // GET: api/<LocationController>
        [HttpGet]
        public IEnumerable<string> Get([FromQuery] Services.Models.LocationSearch locationSearch)
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet("getAllLocations")]
        public ActionResult<List<Location>> getAllLocations()
        {
            
            return Ok(LocationServices.getAllLocations());
        }
        [HttpGet("getByCity/{city}")]
        public ActionResult<List<Location>> getByCity(string city)
        {
            return Ok(LocationServices.getByCity(city));
        }
        [HttpGet("getByUserId/{id}")]
        public ActionResult<List<Location>> getByUserId(int id)
        {
            return Ok(LocationServices.getByPatientId(id));
        }

        [HttpPost("addExposure/{id}")]
        public IActionResult addExposure(int id, [FromBody] Location location)
        {
            LocationServices.postExposure(location, id);
            return Ok();
        }

        [HttpGet("getByDate/{startDate}/{endDate}")]
        public ActionResult<List<Location>> getByDate(DateTime startDate, DateTime endDate)
        {
            return Ok(LocationServices.getByDate(startDate,endDate));
        }

        [HttpGet("getByAge/{age}")]
        public ActionResult<List<Location>> getByAge(int age)
        {
            return Ok(LocationServices.getByAge(age));
        }

    }
}
