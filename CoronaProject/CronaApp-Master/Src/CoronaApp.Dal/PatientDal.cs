using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

public class PatientDal : IPatientDal
{

    //private readonly CoronaContext _context;
    public PatientDal(/*CoronaContext coronaContext*/)
    {
        //_context = coronaContext;
    }



    //A function that return locations by patintId
    public async Task<List<Location>> GetPatientLocations(string patintId)
    {
        
        using (CoronaContext context = new CoronaContext())
        {
            return await context.Locations.Where(l => l.PatientId.Equals(patintId)).ToListAsync();
        }
    }

   

    //A function that add patient
    public async Task PostPatient(Patient patient)
    {

        using (CoronaContext context = new CoronaContext())
        {
            await context.Patients.AddAsync(patient);
            try
            {
                await context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Failed to save changes");
            }
        }
        
    }
}
