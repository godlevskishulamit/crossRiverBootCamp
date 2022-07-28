using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoronaApp.Services.Models;

    public class Location
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]

        public virtual Patient Patient { get; set; }


    }
