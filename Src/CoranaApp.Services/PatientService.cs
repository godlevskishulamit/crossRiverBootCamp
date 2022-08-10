using CoronaApp.Dal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public class PatientService : IPatientService
    {
        IPatientRepository _PatientDal;
        public PatientService(IPatientRepository PatientDal)
        {
            _PatientDal = PatientDal;
        }
        public async Task<string> addNewPatient(Patient newPatient)
        {
            return await _PatientDal.addNewPatient(newPatient);
        }

    }
}
