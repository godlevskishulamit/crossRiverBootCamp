namespace CoronaApp.Api.Controllers;

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
            bool res = await _patientService.AddPatient(patientDto);
            if (res)
                return Ok("adding patient failed!");
            return BadRequest();

        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
