using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Services;
using CoronaApp.Services.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers
{
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
        public Task<List<Location>> Get()
        {
            return il.Get();
        }

        [HttpGet("id/{id}")]
        public Task<List<Location>> GetById(string id)
        {
            return il.getLocationsById(id);
        }
        [HttpGet("city/{city}")]
        public Task<List<Location>> GetByCity(string city)
        {
            return il.getLocationByCity(city);
        }
        [HttpPost]
        public void Add([FromBody] Location loc)
        {
            il.postLocation(loc);
        }
        [HttpGet("{age}")]
        public Task<List<Location>> GetByAge(int age)
        {
            return il.GetByAge(age);
        }
        [HttpGet("date/{date}")]
        public Task<List<Location>> GetByDate(string sdate, string edate)
        {
            return il.GetByDate(Convert.ToDateTime(sdate), Convert.ToDateTime(edate));
        }

    }
}
