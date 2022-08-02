using CoronaApp.Dal.Models;
using CoronaApp.Services.DTO;
using System.Threading.Tasks;

namespace CoronaApp.Services.Interfaces;
public interface IPatientService
{
    Task<bool> AddPatient(PatientDTO patient);
}