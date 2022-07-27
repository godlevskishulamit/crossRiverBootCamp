using CoronaApp.Dal.Classes;
using CoronaApp.Dal.Interfaces;
using CoronaApp.Dal.Models;
using CoronaApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.Classes;
public class PatientService : IPatientService
{
    private readonly IPatientDAL _patientDal;
    public PatientService(IPatientDAL patientDal)
    {
        _patientDal = patientDal;
    }
    public async Task<bool> AddPatient(Patient patient)
    {
        return await _patientDal.AddPatient(patient);
    }
}