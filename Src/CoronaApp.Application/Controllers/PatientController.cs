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
    public async Task<IActionResult> AddPatient([FromBody] PatientDTO patient)
    {
        try
        {
            bool success= await _patientService.AddPatient(patient);
            return !success ? BadRequest("Adding patient failed! try again later...") : Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
