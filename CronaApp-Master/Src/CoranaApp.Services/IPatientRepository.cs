using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services;

public interface IPatientRepository
{
    Task<List<Patient>> Get();

    Task postPatient(Patient pat);

}
