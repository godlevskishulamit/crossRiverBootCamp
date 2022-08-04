using CoronaApp.Dal.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.Functions
{
    public class PatientFunc : IPatientRepository
    {
        private readonly IConfiguration _configuration;
        public PatientFunc(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Patient> GetAsync(ClaimsPrincipal user)
        {
            await using (CoronaContext db = new CoronaContext(_configuration))
            {
                string id = user.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserId", StringComparison.InvariantCultureIgnoreCase)).Value;

                return id==null? null : db.Patients.FirstOrDefault(p => p.Id == id);
            }
        }

        public async Task SaveAsync(Patient patient)
        {
            if (patient == null)
                return;
            await using (CoronaContext db = new CoronaContext(_configuration))
            {
                await db.Patients.AddAsync(patient);
                await db.SaveChangesAsync();
            }
        }
    }
}
