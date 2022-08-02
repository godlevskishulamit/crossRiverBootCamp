using CoronaApp.Dal.Models;
using CoronaApp.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services;

public interface IPatientRepository
{
    Task<List<LocationDTO>> GetPatientLocations(string patintId);
    Task PostPatient(PatientDTO patient);
}
