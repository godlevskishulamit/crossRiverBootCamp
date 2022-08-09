
using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Dal;
    public class PatientRepository : IPatientRepository
    {

        public async Task PostPatient(Patient patient)
        {
            using (var _dbContext = new CoronaDBContext())
            {
                try
                {
                    _dbContext.Patients.Add(patient);
                    var x = await _dbContext.SaveChangesAsync();
                }
                catch
                {
                    throw new DbUpdateException();
                }

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
        public async Task UpdatePatient(Patient patient)
        {
            using (var _dbContext = new CoronaDBContext())
            {
                try
                {
                    _dbContext.Patients.Update(patient);
                    await _dbContext.SaveChangesAsync();
                }
                catch
                {
                    throw new DbUpdateException();
                }
           
            }
        }


    }

