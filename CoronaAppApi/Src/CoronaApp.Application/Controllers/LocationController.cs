using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Dal.Models;
using CoronaApp.Services;
using CoronaApp.Services.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CoronaApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationController : Controller
{
    ILocationRepository _service;
    public LocationController(ILocationRepository service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ICollection<Location>> GetAllAsync()
    {
           return await _service.GetAllAsync();
    }

    [Authorize]
    [HttpGet("patientId")]
    public async Task<ICollection<LocationGetByIdDto>> GetByPatientIdAsync()
    {
           return await _service.GetByPatientIdAsync(User);
    }

    [HttpGet("city")]
    public async Task<ICollection<Location>> GetByCityAsync(string? city)
    {
           return await _service.GetByCityAsync(city);
    }

    [HttpGet("range")]
    public async Task<ICollection<Location>> GetByDatesRangeAsync([FromBody] Services.Models.LocationSearch locationSearch)
    {
           return await _service.GetByDatesRangeAsync(locationSearch);
    }

    [HttpGet("age")]
    public async Task<ICollection<Location>> GetByAgeAsync([FromBody] Services.Models.LocationSearch locationSearch)
    {
        return await _service.GetByAgeAsync((int)locationSearch?.Age);
    }

    [Authorize]
    [HttpPost]
    public async Task PostAsync([FromBody] LocationPostDto location)
    {
        await _service.PostAsync(location, User);
    }
}
