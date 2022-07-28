using CoronaApp.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

    public interface IPatientDal
    {
        Task<List<Patient>> Get();
        Task<Patient> GetById(int id);
        Task Post(Patient patient);
        Task Put(Patient patient);
    }
