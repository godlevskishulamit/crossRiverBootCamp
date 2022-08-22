namespace CoronaApp.Services.Mocks;

public class PatientMock : IPatientRepository
{
    public Task<Patient> GetAsync(ClaimsPrincipal user)
    {
        return null;
    }

    public Task SaveAsync(Patient patient)
    {
        return null;
    }
}
