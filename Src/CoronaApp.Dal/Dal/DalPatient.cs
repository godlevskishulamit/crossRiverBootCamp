using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Dal.Interfaces;
using CoronaApp.Services.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoronaApp.Dal.Dal;

public class DalPatient : IDalPatient
{
    public IConfiguration _configuration;
    public DalPatient(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<List<Patient>> getAllPatients()
    {
        using (var context = new CoronaDbContext(_configuration))
        {
            return await context.Patients.ToListAsync();
        }
    }
    public async Task postPatient(Patient pat)
    {
        using (var context = new CoronaDbContext(_configuration))
        {
              await context.Patients.AddAsync(pat);
              await context.SaveChangesAsync();
        }
    }

}
