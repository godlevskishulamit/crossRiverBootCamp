using CoronaApp.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

    public interface IPatientDal
    {
        Task<List<Patient>> GetAllPatients();
        Task<Patient> GetById(int id);
        Task AddNewPatient(Patient patient);
        Task EditPatient(Patient patient);
    }
