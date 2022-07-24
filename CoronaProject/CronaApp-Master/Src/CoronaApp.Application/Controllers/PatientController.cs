using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoronaApp.Dal;
using CoronaApp.Dal.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly IPatientDal _patientDal;
    public PatientController(IPatientDal patientDal)
    {
        _patientDal = patientDal;
    }

    // GET api/<PatientController>/5
    [HttpGet("{patintId}")]
    public async Task<ActionResult<List<Location>>> Get(string patintId)
    {
        var res = await _patientDal.GetPatientLocations(patintId);
        if (res == null)
        {
            return NotFound();
        }
        return res;

    }

    // POST api/<PatientController>
    [HttpPost]
    public async Task<ActionResult<Location>> Post([FromBody] Location location)
    {
        return await _patientDal.PostLocation(location);
    }
    [HttpPost("patient")]
    public async Task Post([FromBody] Patient patient)
    {
         await _patientDal.PostPatient(patient);
    }

    // DELETE api/<PatientController>
    [HttpDelete("{locationId}")]
    public async Task Delete(int locationId)
    {
        await _patientDal.DeleteLocation(locationId);
    }
}
