using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services;

public interface IPatientRepository
{
    Task<List<Location>> GetPatientLocations(string patintId);
    Task PostLocation(Location location);
    Task DeleteLocation(int locationId);
    Task PostPatient(Patient patient);
}
