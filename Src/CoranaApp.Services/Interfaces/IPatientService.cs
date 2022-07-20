using CoronaApp.Dal.Models;
using System.Threading.Tasks;

namespace CoronaApp.Services.Interfaces
{
    public interface IPatientService
    {
        Task AddPatient(Patient patient);
    }
}