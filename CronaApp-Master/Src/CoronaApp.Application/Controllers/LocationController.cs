using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using CoronaApp.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        ILocationRepository _LocationRepository;

        public LocationController(ILocationRepository LocationRepository)
        {
            _LocationRepository = LocationRepository;
        }

        // GET:
        [HttpGet]
        public async Task<List<Location>> getAllLocation()
        {
            return await _LocationRepository.getAllLocation();
        }

        // GET:
        [HttpGet("{id}")]
        public async Task<List<Location>> getLocationsByPatientId(string id)
        {
            return await _LocationRepository.getLocationsByPatientId(id);
        }

        // GET:
        [HttpGet ("city")]
        public async Task<List<Location>> getAllLocationByCity([FromQuery] string city)
        {
            return await _LocationRepository.getAllLocationByCity(city);
        }

        // GET:
        [HttpGet("filter")]
        public async Task<List<Location>> getFilterdLocation([FromBody] LocationSearch locationSearch)
        {
            return await _LocationRepository.getFilterdLocation(locationSearch);
        }
        // POST:
        [HttpPost]
        public async Task<int> addNewLocation([FromBody] Location newLocation)
        {
            return await _LocationRepository.addNewLocation(newLocation);
        }


    }

}

