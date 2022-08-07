using AutoMapper;
using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public class PatientService : IPatientService
    {
        IPatientRepository _patientRepository;
        IMapper _mapper;
        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }
        public async Task<ICollection<PatientDTO>> GetAllPatient()
        {

            List<Patient> patients = await _patientRepository.GetAllPatients();
            List<PatientDTO> patientsDTO = new List<PatientDTO>();
            foreach (Patient pat in patients)
                patientsDTO.Add(_mapper.Map<PatientDTO>(pat));
            return patientsDTO;

        }
        public async Task PostPatient(PatientDTO patientDTO)
        {
            Patient patient = _mapper.Map<Patient>(patientDTO);
            await _patientRepository.PostPatient(patient);
        }
        public async Task UpdatePatient(PatientDTO patientDTO)
        {
            Patient patient = _mapper.Map<Patient>(patientDTO);
            await _patientRepository.UpdatePatient(patient);

        }


    }
}
