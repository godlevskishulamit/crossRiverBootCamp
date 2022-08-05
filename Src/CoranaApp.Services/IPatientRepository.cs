using CoronaApp.Dal;
using System.Threading.Tasks;

namespace CoronaApp.Services;
public interface IPatientRepository
{
     Task<string> addNewPatient(Patient newPatient);
}
