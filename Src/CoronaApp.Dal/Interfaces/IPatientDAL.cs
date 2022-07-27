using CoronaApp.Dal.Models;
using System.Threading.Tasks;

namespace CoronaApp.Dal.Interfaces;
public interface IPatientDAL
{
    Task<bool> AddPatient(Patient patient);
}