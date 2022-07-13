using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoronaApp.Dal.Models
{
    public class Location
    {
       
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string PatientId { get; set; }
        [ForeignKey("PatientId")]
        [JsonIgnore]
        public virtual Patient Patient { get; set; }
    }
}
