using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace CoronaApp.Dal;

public class DalPatient : IDalPatient
{
    public CoronaDbContext context;
    public DalPatient(CoronaDbContext context)
    {
        this.context = context;
    }
    public async Task<List<Patient>> getAllPatients()
    {
        return await context.Patients.ToListAsync();
    }
    public async Task postPatient(Patient pat)
    {
        await Task.Run(() =>
        {
            context.Patients.Add(pat);
            context.SaveChanges();
        });
    }

}
