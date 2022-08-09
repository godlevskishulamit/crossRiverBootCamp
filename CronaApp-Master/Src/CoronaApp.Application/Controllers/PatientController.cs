using CoronaApp.Services;
using System.Threading.Tasks;
using CoronaApp.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<ActionResult<ICollection<PatientDTO>>> GetAllUsers()
    {
        try
        {
            ICollection<PatientDTO> patientDTOs = await _patientService.GetAllPatient();
            if (patientDTOs == null)
                return NotFound();
            if (patientDTOs.Count == 0)
                return NoContent();
            return Ok(patientDTOs);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);

        }
    }

    // POST api/<PatientController>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] PatientDTO patient)
    {
        if (patient == null)
            return BadRequest();
        try
        {
            await _patientService.PostPatient(patient);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // PUT api/<PatientController>/5s
    [HttpPut]
    public async Task<ActionResult> Put([FromBody] PatientDTO patient)
    {
        if (patient == null)
            return BadRequest();
        try
        {
            await _patientService.UpdatePatient(patient);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }


}
