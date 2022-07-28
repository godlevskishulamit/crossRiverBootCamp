using CoronaApp.Dal.Interfaces;
using CoronaApp.Dal.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal.Functions
{
    public class PatientDal : IPatientDal
    {
        private readonly IConfiguration _configuration;
        public PatientDal(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    
        public async Task<Patient> GetAsync(ClaimsPrincipal user)
        {
            await using(CoronaContext db=new CoronaContext(_configuration))
            {
                string id = user.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserId", StringComparison.InvariantCultureIgnoreCase)).Value;
                return id==null?null:db.Patients.FirstOrDefault(p=>p.PatientId.Equals(id));
            }

            
        }

        public async Task SaveAsync(Patient patient)
        {
            if (patient == null)
                return;
            await using (CoronaContext db= new CoronaContext(_configuration))
            {
                await db.Patients.AddAsync(patient);
                await db.SaveChangesAsync();
            }
        }
    }
}
