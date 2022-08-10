
using CoronaApp.Dal;
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
