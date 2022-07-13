using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Dal;
using CoronaApp.Services.Models;

namespace CoronaApp.Services
{
   public class PatientRepository : IPatientRepository
    {
        public IDalPatient idp;
        public PatientRepository(IDalPatient idp)
        {
            this.idp = idp;
        }
        public async Task<List<Patient>> Get()
        {
            return await idp.getAllPatients();
        }
        public void postPatient(Patient pat)
        {
            idp.postPatient(pat);
        }
    }
}
