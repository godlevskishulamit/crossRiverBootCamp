using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

public class PatientRepository : IPatientRepository
{
    public PatientRepository()
    {
    }
    public async Task<string> addNewPatient(Patient newPatient)
    {

        using (var _CoronaAppDBContext = new CoronaAppDBContext())
        {
            try
            {
                await _CoronaAppDBContext.Patients.AddAsync(newPatient);
                await _CoronaAppDBContext.SaveChangesAsync();
                return newPatient.Id;
            }
            catch(Exception)
            {
                throw new DbUpdateException();
            }
        }
    }
}
