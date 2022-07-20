using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoronaApp.Dal
{
    public class Location
    {
        public int Id { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        // public string PatientId { get; set; }
        [ForeignKey("Patient")]
        public string PatientId { get; set; }

        [JsonIgnore]
        public  virtual Patient Patient { get; set; }
    }

}
