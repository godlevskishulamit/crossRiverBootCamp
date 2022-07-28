using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoronaApp.Dal.Models
{
    public class Location
    {
        public int LocationId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        public string Address { get; set; }
        public string City { get; set; }

        [ForeignKey("Patient")]
        [Required]
        public string PatientId { get; set; }
        public virtual Patient Patient { get; set; }

    }
}
