
namespace CoronaApp.Services.Functions;

public class PatientFunc : IPatientRepository
{
    private readonly IConfiguration _configuration;
    public PatientFunc(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<Patient> GetAsync(ClaimsPrincipal user)
    {
        using (CoronaContext db = new CoronaContext(_configuration))
        {
            string patientId = user.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserId", StringComparison.InvariantCultureIgnoreCase)).Value;

            return patientId == null? null : db.Patients.FirstOrDefault(p => p.Id == patientId);
        }
    }

    public async Task SaveAsync(Patient patient)
    {
        if (patient == null)
            return;
        using (CoronaContext db = new CoronaContext(_configuration))
        {
            await db.Patients.AddAsync(patient);
            await db.SaveChangesAsync();
        }
    }
}
