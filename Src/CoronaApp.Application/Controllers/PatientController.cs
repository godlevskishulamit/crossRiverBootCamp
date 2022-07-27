using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Dal;
using CoronaApp.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    IPatientRepository _PatientRepository;
    public PatientController(IPatientRepository PatientRepository)
    {
        _PatientRepository = PatientRepository;
    }

    // POST:
    [HttpPost]
    public async Task<ActionResult<string>> Post([FromBody] Patient newPatient)
    {
        var result = await _PatientRepository.addNewPatient(newPatient);
        if (result == null)
        {
            return StatusCode(404, "not found");
        }
        if (!result.Any())
        {
            return StatusCode(204, "no content");
        }
        return Ok(result);
    } 
}
