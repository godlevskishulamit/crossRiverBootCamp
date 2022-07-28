using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal;
public  class PatientDal : IPatientDal
{

    public async Task<string> addNewPatient(Patient newPatient)
    { 
        try
        {
            using (var _CoronaAppDBContext = new CoronaAppDBContext())
            {
                await _CoronaAppDBContext.Patients.AddAsync(newPatient);
                await _CoronaAppDBContext.SaveChangesAsync();
                return newPatient.Id;
            }
        }
        catch (Exception)
        {
            throw new Exception("internal error with SaveChangesAsync function");
        }

    }

}
