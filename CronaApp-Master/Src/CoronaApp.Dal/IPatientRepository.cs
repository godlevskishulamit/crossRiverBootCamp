using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Dal
{
    public interface IPatientRepository
    {
        public Task<string> addNewPatient(Patient newPatient);

    }
}