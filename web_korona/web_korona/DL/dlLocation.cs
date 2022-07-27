using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using web_korona.Entities;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace web_korona.DL
{
    public class dlLocation : IdlLocation
    {
        public List<Patient> patientsList { get; set; }
        public List<Location> locationsList { get; set; } = new List<Location>();
        private static string fileName = "../web_korona/Data/DBJson.json";
        public List<Patient> toRead()
        {
            StreamReader r = new StreamReader(fileName);
            string patientsString = r.ReadToEnd();
            List<Patient> patients = JsonConvert.DeserializeObject<List<Patient>>(patientsString);
            r.Close();
            return patients;
        }
        //public List<Patient> toWrite()
        //{
        //    StreamWriter r = new StreamWriter(fileName);
        //    string patientsString = r.ReadToEnd();
        //    List<Patient> patients = JsonConvert.DeserializeObject<List<Patient>>(patientsString);
        //    r.Close();
        //    return patients;
        //}
        public void WriteData(List<Patient> patients)
        {
            File.WriteAllText(fileName, System.Text.Json.JsonSerializer.Serialize(patients));
        }
        public List<Location> getAllLocations()
        {
            locationsList.Clear();
            patientsList = toRead();
            patientsList.ForEach(p => p.locations.ForEach(l => locationsList.Add(l)));
            return locationsList;
        }
        public List<Location> getLocationByCity(string city)
        {

            locationsList.Clear();
            patientsList = toRead();
            patientsList.ForEach(p => p.locations.ForEach(l => locationsList.Add(l)));
            return locationsList.Where(l => l.city.Contains(city)).ToList();
        }
        public void postLocation(string id, Location loc)
        {
            locationsList.Clear();
            patientsList = toRead();
            Patient p = patientsList.Find(u => u.patientId == id);
            if (p != null)
                p.locations.Add(loc);
            else
            {
                List<Location> l = new List<Location>();
                l.Add(loc);
                patientsList.Add(new Patient(id, l));

            }
            WriteData(patientsList);
        }
        public List<Location> getLocationsById(string id)
        {
            locationsList.Clear();
            patientsList = toRead();
            Patient p = patientsList.First(p => p.patientId == id);
            if (p != null)
            {
                return p.locations;
            }
            return null;
        }
        public void deleteLocation(string id, DateTime startDate)
        {
            locationsList.Clear();
            patientsList = toRead();
            Patient p = patientsList.First(p => p.patientId == id);
            Location l = p.locations.First(l => l.startDate == startDate);
            p.locations.Remove(l);
            WriteData(patientsList);
        }
    }
}
