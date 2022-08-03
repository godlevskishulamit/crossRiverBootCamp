using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Dal;
using CoronaApp.Dal.Interfaces;
using CoronaApp.Services.Interfaces;
using CoronaApp.Services.Models;

namespace CoronaApp.Services.Services;

public class PatientRepository : IPatientRepository
{
    public IDalPatient idp;
    public PatientRepository(IDalPatient idp)
    {
        this.idp = idp;
    }
    public async Task<List<Patient>> Get()
    {
        return await idp.getAllPatients();
    }
    public async Task postPatient(Patient pat)
    {
        await idp.postPatient(pat);
    }
}
