using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal
{
    public class PatientRepository : IPatientRepository
    {
       
        public async Task PostPatient(Patient patient)
        {
            using (var _dbContext = new CoronaDBContext())
            {
                _dbContext.Patients.Add(patient);
                var x = await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Patient>> GetAllPatients()
        {
            using (var _dbContext = new CoronaDBContext())
            {
                var a = await _dbContext.Patients.ToListAsync();
                return a;
            }
        }
        public async Task UpdatePatient(Patient patient) {
            using (var _dbContext = new CoronaDBContext())
            {
                _dbContext.Patients.Update(patient);
                await _dbContext.SaveChangesAsync();
            }
        }


    }
}
