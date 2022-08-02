using AutoMapper;
using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using CoronaApp.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public class PatientRepository:IPatientRepository
    {
        private readonly IPatientDal _patientDal;
        private readonly IMapper _mapper;

        public PatientRepository(IPatientDal patientDal)
        {
            _patientDal = patientDal;
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            _mapper= config.CreateMapper();
        }

        //A function that return locations by patintId
        public async Task<List<LocationDTO>> GetPatientLocations(string patintId)
        {
            var locations = await _patientDal.GetPatientLocations(patintId);
            return _mapper.Map<List<Location>, List<LocationDTO>>(locations);
        }


        //A function that add patient
        public async Task PostPatient(PatientDTO patient)
        {
            Patient patientFromDTO = _mapper.Map<PatientDTO, Patient>(patient);
            await _patientDal.PostPatient(patientFromDTO);
        }
    }
}
