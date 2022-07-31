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
        public async Task<List<Patient>> GetAllPatients()
        {
            using (var context = new CoronaAppContext())
            {
                List<Patient> patientList;
                try
                {
                     patientList = await context.Patients.ToListAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Server error when trying to read data from db");
                }
                return patientList;
            }

        }
        public async Task<Patient> GetById(int id)
        {
            using (var context = new CoronaAppContext())
            {
                Patient patient;
                try { 
                patient = await context.Patients.Where(p => p.Id == id).FirstOrDefaultAsync();
                }
                catch(Exception ex)
                {
                    throw new Exception("Server error when trying to read data from db");
                }
                return patient;
            }
        }
        public async Task AddNewPatient(Patient patient)
        {
            using (var context = new CoronaAppContext())
            {
                try
                {
                    await context.Patients.AddAsync(patient);
                    await context.SaveChangesAsync();
                }
                catch(Exception e)
                {
                    throw new Exception("Failed to save changes in db");
                }
            }

        }
        public async Task EditPatient(Patient patient)
        {
            using (var context = new CoronaAppContext())
            {
                Patient patientToUpdate = await context.Patients.Where(p => p.Id == patient.Id).FirstOrDefaultAsync();
                if (patientToUpdate == null)
                    return;
                context.Entry(patientToUpdate).CurrentValues.SetValues(patient);
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw new Exception("Failed to save changes in db");
                }
            }
        }
    }
}
