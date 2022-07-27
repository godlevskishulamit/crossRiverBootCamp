using System.Collections.Generic;
using System.Threading.Tasks;
using CoronaApp.Services.Models;

namespace CoronaApp.Dal.Interfaces;

public interface IDalPatient
{
    Task<List<Patient>> getAllPatients();
    Task postPatient(Patient pat);
}