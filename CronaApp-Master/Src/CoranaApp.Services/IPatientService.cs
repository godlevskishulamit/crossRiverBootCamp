
using CoronaApp.Dal;
using CoronaApp.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface IPatientService
    {
         Task<string> addNewPatient(Patient newPatient);

    }
}
