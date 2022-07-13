using System.Collections.Generic;
using System.Threading.Tasks;
using CoronaApp.Services.Models;

namespace CoronaApp.Dal
{
   public interface IDalPatient
    {
        Task<List<Patient>> getAllPatients();
        void postPatient(Patient pat);
    }
}