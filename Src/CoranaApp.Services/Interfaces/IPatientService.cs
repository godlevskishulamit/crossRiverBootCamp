namespace CoronaApp.Services.Interfaces;

public interface IPatientService
{
    Task<bool> AddPatient(PatientDTO patient);
}