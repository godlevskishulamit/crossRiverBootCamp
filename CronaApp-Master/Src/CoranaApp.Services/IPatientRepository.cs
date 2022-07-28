﻿using CoronaApp.Dal.Models;

using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface IPatientRepository
    {
        Task<Patient> GetAsync(ClaimsPrincipal user);
        Task SaveAsync(Patient patient);
    }
}
