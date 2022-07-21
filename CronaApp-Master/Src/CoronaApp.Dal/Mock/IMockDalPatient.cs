using System.Collections.Generic;
using System.Threading.Tasks;
using CoronaApp.Services.Models;

namespace CoronaApp.Dal.Mock
{
   public interface IMockDalPatient
    {
        List<Patient> getAllPatients();
        void postPatient(Patient pat);
    }
}