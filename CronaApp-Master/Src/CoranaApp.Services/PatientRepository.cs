using CoronaApp.Dal;
using CoronaApp.Services.DTO;
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
        public async Task<List<PatientDTO>> GetAllPatients()
        {
            List<Patient> patients= await patientdl.GetAllPatients();
            List<PatientDTO> patientsDto = patients.Select(p => new PatientDTO(p.Id,p.IdNumber,p.Name,DateTime.Now.Year- p.DateOfBirth.Year)).ToList();
            return patientsDto;
        }
        //public async Task<PatientDTO> GetById(int id)
        //{

        //    Patient patient = await patientdl.GetById(id);

        //    return
        //}
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
