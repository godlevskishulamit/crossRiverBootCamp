using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Dal.Models;
using CoronaApp.Services;
using CoronaApp.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    IPatientService _patientService;
    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet]
    public async Task<ICollection<PatientDTO>> GetAllUsers()
    {
        return await _patientService.GetAllPatient();
    }

    // POST api/<PatientController>
    [HttpPost]
    public async Task Post([FromBody] PatientDTO patient)
    {
        await _patientService.PostPatient(patient);
    }

    // PUT api/<PatientController>/5s
    [HttpPut]
    public async Task Put([FromBody] PatientDTO patient)
    {
        await _patientService.UpdatePatient(patient);
    }


}
