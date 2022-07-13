using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal
{
    public class PatientDal : IPatientDal
    {
        CoronaDBContext _dbContext;
        public PatientDal(CoronaDBContext DBContext)
        {
            this._dbContext = DBContext;
        }
        public async Task PostPatient(Patient patient)
        {
           this._dbContext.Patients.Add(patient);
            var x=await this._dbContext.SaveChangesAsync();

        }

        public async Task<List<Patient>> GetAllPatients()
        {
            var a = await this._dbContext.Patients.ToListAsync();
            return a;
        }
        public async Task UpdatePatient(Patient patient) {
            this._dbContext.Patients.Update(patient);
            await this._dbContext.SaveChangesAsync();
        }


    }
}
