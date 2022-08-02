using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using Microsoft.AspNetCore.Authorization;
using CoronaApp.Services;
using CoronaApp.Services.DTOs;


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
        return res != null ? Ok(res) : NotFound();
    }



    [HttpPost("patient")]
    public async Task Post([FromBody] PatientDTO patient)
    {
         await _patientRepository.PostPatient(patient);
    }
}
