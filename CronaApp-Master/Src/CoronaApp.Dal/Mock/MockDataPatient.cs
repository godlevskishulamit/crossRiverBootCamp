using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Services.Models;

namespace CoronaApp.Dal.Mock
{
    class MockDataPatient : IMockDalPatient
    {
        public List<Patient> patients { get; set; } = new List<Patient>{
            new Patient{ Id="111111111",name="first",age=1},
            new Patient{ Id="222222222",name="second",age=2},
            new Patient{ Id="333333333",name="theared",age=3},
        };

        public List<Patient> getAllPatients()
        {
            return patients;
        }

        public void postPatient(Patient pat)
        {
            this.patients.Add(pat);
        }

    }
}
