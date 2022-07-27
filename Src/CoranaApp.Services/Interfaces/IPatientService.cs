using CoronaApp.Dal.Models;
using System.Threading.Tasks;

namespace CoronaApp.Services.Interfaces;
public interface IPatientService
{
    Task<bool> AddPatient(Patient patient);
}