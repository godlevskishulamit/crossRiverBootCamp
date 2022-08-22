
namespace CoronaApp.Api.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{

    IPatientRepository _service;
    public PatientController(IPatientRepository service)
    {
        _service = service;
    }

    [HttpGet("id")]
    public async Task<Patient> GetAsync()
    {
        return await _service.GetAsync(User);
    }

    [HttpPost]
    public async Task<bool> SaveAsync([FromBody]Patient patient)
    {
        try
        {
            await _service.SaveAsync(patient);
            return true;
        }
        catch
        {
            throw new("Server Err: couldn't save data.");
        }
    }

}
