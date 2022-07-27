using CoronaApp.Dal.Interfaces;
using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal.Classes;
public class PatientDAL : IPatientDAL
{
    //private readonly CoronaContext _context;
    //public PatientDAL(CoronaContext context)
    //{
    //    _context = context;
    //}
    public async Task<bool> AddPatient(Patient patient)
    {

        try
        {
            using (var _context = new CoronaContext())
            {
                await _context.Patient.AddAsync(patient);
                await _context.SaveChangesAsync();
            }
            return true;
        }
        catch
        {
            return false;
        }
    }
}