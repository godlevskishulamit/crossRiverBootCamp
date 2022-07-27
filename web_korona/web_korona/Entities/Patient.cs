using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_korona.Entities
{
    public class Patient
    {
        public string patientId { get; set; }
        public List<Location> locations { get; set; }

        public Patient(string id, List<Location> locations)
        {
            this.patientId = id;
            this.locations = locations;
        }
    }
}
