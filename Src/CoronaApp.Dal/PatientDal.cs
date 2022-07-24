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
    CoronaAppDBContext _CoronaAppDBContext;
    public PatientDal(CoronaAppDBContext CoronaAppDBContext)
    {
        _CoronaAppDBContext =CoronaAppDBContext;
    }
    public async Task<string> addNewPatient(Patient newPatient)
    {
        await _CoronaAppDBContext.Patients.AddAsync(newPatient);
        await _CoronaAppDBContext.SaveChangesAsync();
        return newPatient.Id;
    }

}
