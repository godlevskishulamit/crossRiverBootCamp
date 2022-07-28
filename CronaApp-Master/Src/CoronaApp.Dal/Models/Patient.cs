using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoronaApp.Dal.Models
{
    public class Patient
    {
        [MaxLength(9)]
        [Required]
        public string PatientId { get; set; }
   
        public string PatientName { get; set; }
       
        public int Age { get; set; } 

    }
}
