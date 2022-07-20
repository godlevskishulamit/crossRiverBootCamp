using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Dal.Models;
using CoronaApp.Dal.Services;
using CoronaApp.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository repo;
        public LocationController(ILocationRepository _repo)
        {
            repo=_repo;
        }

        // GET: api/<LocationController>
        [HttpGet]
        //public IEnumerable<string> Get([FromQuery] Services.Models.LocationSearch locationSearch)
        //{
        //    return new string[] { "value1", "value2" };
        //}


        [HttpGet("getAllLocations")]
        public ActionResult<List<Location>> getAllLocations()
        {
            
            return Ok(repo.getAllLocations());
        }
        [HttpGet("getByCity/{city}")]
        public ActionResult<List<Location>> getByCity(string city)
        {
            return Ok(repo.getByCity(city));
        }
        [HttpGet("getByUserId/{id}")]
        public ActionResult<List<Location>> getByUserId(int id)
        {
            return Ok(repo.getByUserId(id));
        }

        [HttpPost("addExposure/{id}")]
        public IActionResult addExposure(int id, [FromBody] Location location)
        {
           repo.postExposure(id,location);
            return Ok();
        }

        [HttpGet("getByDate/{startDate}/{endDate}")]
        public ActionResult<List<Location>> getByDate(DateTime startDate, DateTime endDate)
        {
            return Ok(repo.getByDate(startDate,endDate));
        }

        [HttpGet("getByAge/{age}")]
        public ActionResult<List<Location>> getByAge(int age)
        {
            return Ok(repo.getByAge(age));
        }

    }
}
