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
        public async Task<List<Patient>> GetAllPatients()
        {
            return await patientdl.GetAllPatients();
        }
        public async Task<Patient> GetById(int id)
        {
            return await patientdl.GetById(id);
        }
        public async Task AddNewPatient(Patient patient)
        {
            await patientdl.AddNewPatient(patient);
        }
        public async Task EditPatient(Patient patient)
        {
            await patientdl.EditPatient(patient);
        }
    }
}
