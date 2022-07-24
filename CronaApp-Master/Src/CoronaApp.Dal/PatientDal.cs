using CoronaApp.Dal.models;
using CoronaApp.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal
{
    public class PatientDal : IPatientDal
    {
        CoronaAppContext ct;
        public PatientDal(CoronaAppContext ct)
        {
            this.ct = ct;
        }
        public async Task<List<Patient>> Get()
        {
            //using (var context = new CoronaAppContext())
            {
                List<Patient> patientList = await ct.Patients.ToListAsync();
                return patientList;
            }
           
        }
        public async Task<Patient> GetById(int id)
        {
            using (var context = new CoronaAppContext())
            {
                Patient patient = await context.Patients.Where(p => p.Id == id).FirstOrDefaultAsync();
                return patient;
            }
        }
        public async Task Post(Patient patient)
        {
            using (var context = new CoronaAppContext())
            {
                await context.Patients.AddAsync(patient);
                await context.SaveChangesAsync();
            }
               
        }
        public async Task Put(Patient patient)
        {
            using (var context = new CoronaAppContext())
            {
                Patient patientToUpdate = await context.Patients.Where(p => p.Id == patient.Id).FirstOrDefaultAsync();
                if (patientToUpdate == null)
                    return;
                context.Entry(patientToUpdate).CurrentValues.SetValues(patient);
                await context.SaveChangesAsync();
            }
        }
    }
}
