using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.Mocks
{
    public class PatientMock : IPatientRepository
    {
        public Task<Patient> GetAsync(ClaimsPrincipal user)
        {
            return null;
        }

        public Task SaveAsync(Patient patient)
        {
            return null;
        }
    }
}
