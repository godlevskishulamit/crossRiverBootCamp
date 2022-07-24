using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoronaApp.Services.Models
{
    public class Location
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]

        public virtual Patient Patient { get; set; }


    }
}