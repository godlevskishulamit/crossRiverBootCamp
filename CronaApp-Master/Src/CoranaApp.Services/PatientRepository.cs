using CoronaApp.Dal;
using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public class PatientRepository : IPatientRepository
    {
        IPatientDal patientdl;
        public PatientRepository(IPatientDal patientdl)
        {
            this.patientdl = patientdl;
        }
        public async Task<List<Patient>> Get()
        {
            return await patientdl.Get();
        }
        public async Task<Patient> GetById(int id)
        {
            return await patientdl.GetById(id);
        }
        public async Task Post(Patient patient)
        {
            await patientdl.Post(patient);
        }
        public async Task Put(Patient patient)
        {
            await patientdl.Put(patient);
        }
    }
}
