
namespace CoronaApp.Services;

public interface IPatientRepository
{
    public Task<Patient> GetAsync(ClaimsPrincipal user);
    public Task SaveAsync(Patient patient);

}
