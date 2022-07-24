using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Dal;

public interface IPatientRepository
{
    Patient Get(string id);

    void Save(Patient patient);
}
