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
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public ICollection<Location>? Locations { get; set; }
    }
}
