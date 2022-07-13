using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public class PatientRepository : IPatientRepository
    {
        IPatientDal PatientDal;
        public PatientRepository(IPatientDal patientDal)
        {
            this.PatientDal = patientDal;
        }
        public async Task<ICollection<Patient>> GetAllPatient()
        {
            return await this.PatientDal.GetAllPatients();
        }
        public async Task PostPatient(Patient patient)
        {
           await this.PatientDal.PostPatient(patient);
        }
        public async Task UpdatePatient(Patient patient)
        {
            await this.PatientDal.UpdatePatient(patient);
           
        }


    }
}
