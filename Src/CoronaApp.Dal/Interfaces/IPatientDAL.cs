﻿namespace CoronaApp.Dal.Interfaces;

public interface IPatientDAL
{
    Task<bool> AddPatient(Patient patient);
}