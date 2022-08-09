using CoronaApp.Dal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Dal;
    public interface IPatientRepository
    {
        Task PostPatient(Patient patient);
        Task<List<Patient>> GetAllPatients();
        Task UpdatePatient(Patient patient);

    }

