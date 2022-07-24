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

    private readonly CoronaContext _context;
    public PatientDal(CoronaContext coronaContext)
    {
        _context = coronaContext;
    }

  

    //A function that return locations by patintId
    public async Task<List<Location>> GetPatientLocations(string patintId)
    {
       return await _context.Locations.Where(l => l.PatientId.Equals(patintId)).ToListAsync();
    }

    //A function that add location
    public async Task<Location> PostLocation(Location location)
    {
        var l= await _context.Locations.AddAsync(location);
        await _context.SaveChangesAsync();
        return l.Entity;
    }

    //A function that delete location by patintId
    public async Task DeleteLocation(int locationId)
    {
        var locationToDelete = _context.Locations.FindAsync(locationId).Result;
        _context.Locations.Remove(locationToDelete);
        await _context.SaveChangesAsync();
    }

    //A function that add patient
    public async Task PostPatient(Patient patient)
    {
        await _context.Patients.AddAsync(patient);
        await _context.SaveChangesAsync();
    }
}
