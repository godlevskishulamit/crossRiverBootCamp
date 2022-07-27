using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using Microsoft.AspNetCore.Authorization;
using CoronaApp.Services;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly IPatientRepository _patientRepository;
    public PatientController(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    // GET api/<PatientController>/5
    [HttpGet("{patintId}")]   
    public async Task<ActionResult> Get(string patintId)
    {
        var res = await _patientRepository.GetPatientLocations(patintId);
        if (res == null)
        {
            return NotFound();
        }
        return Ok(res);
    }

    // POST api/<PatientController>
    [HttpPost]
    public async Task Post([FromBody] Location location)
    {
         await _patientRepository.PostLocation(location);
    }

    [HttpPost("patient")]
    public async Task Post([FromBody] Patient patient)
    {
         await _patientRepository.PostPatient(patient);
    }

    // DELETE api/<PatientController>
    [HttpDelete("{locationId}")]
    public async Task Delete(int locationId)
    {
        await _patientRepository.DeleteLocation(locationId);
    }
}
