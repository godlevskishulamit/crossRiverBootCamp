using System;
using System.Collections.Generic;
using web_korona.Entities;

namespace web_korona.DL
{
    public interface IdlLocation
    {
        List<Location> locationsList { get; set; }
        List<Patient> patientsList { get; set; }

        List<Location> getAllLocations();
        List<Location> getLocationByCity(string city);
        void postLocation(string id, Location loc);
        List<Location> getLocationsById(string id);
        void deleteLocation(string id, DateTime startDate);
    }
}