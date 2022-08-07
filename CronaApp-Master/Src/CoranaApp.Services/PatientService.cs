using AutoMapper;
using CoronaApp.Dal;
using CoronaApp.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public class PatientService : IPatientService
    {
        IPatientRepository _PatientDal;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository PatientDal,IMapper mapper)
        {
            _PatientDal = PatientDal;
            _mapper = mapper;
        }
        public async Task<string> addNewPatient(Patient newPatient)
        {
           // Patient patient = _mapper.Map<Patient>(newPatient);
            return await _PatientDal.addNewPatient(newPatient);
        }

    }
}
