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
        if (newPatient == null)
        {
            throw new ArgumentNullException("newPatient");
        }
        else
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
            catch (Exception e)
            {
                throw new Exception("internal error with SaveChangesAsync function");
            }

        }
    }

}
