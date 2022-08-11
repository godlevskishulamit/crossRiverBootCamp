﻿namespace CoronaApp.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;
    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    // POST api/<PatientController>/AddPatient
    [HttpPost]
    [Route("AddPatient")]
    public async Task<IActionResult> AddPatient([FromBody] PatientDTO patientDto)
    {
        try
        {
            if (patientDto.Id == null || patientDto.Name == null)
                return StatusCode(406, "this patient is not acceptable");
            bool res = await _patientService.AddPatient(patientDto);
            if (res)
                return Ok("adding patient succesed!");
            return BadRequest("adding patient failed");

        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
