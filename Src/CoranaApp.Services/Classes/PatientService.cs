using AutoMapper;
using CoronaApp.Dal.Classes;
using CoronaApp.Dal.Interfaces;
using CoronaApp.Dal.Models;
using CoronaApp.DTO;
using CoronaApp.Services.DTO;
using CoronaApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.Classes;

public class PatientService : IPatientService
{
    private readonly IPatientDAL _patientDal;
    IMapper mapper;
    public PatientService(IPatientDAL patientDal)
    {
        _patientDal = patientDal;
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AutoMapperProfile>();
        });
        mapper = config.CreateMapper();
    }
    public async Task<bool> AddPatient(PatientDTO patientDto)
    {
        Patient patient = mapper.Map<Patient>(patientDto);
        return await _patientDal.AddPatient(patient);
    }
}
