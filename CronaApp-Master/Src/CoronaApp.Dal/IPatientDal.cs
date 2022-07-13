using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal
{
    public interface IPatientDal
    {
        Task PostPatient(Patient patient);
        Task<List<Patient>> GetAllPatients();
        Task UpdatePatient(Patient patient);

    }
}
