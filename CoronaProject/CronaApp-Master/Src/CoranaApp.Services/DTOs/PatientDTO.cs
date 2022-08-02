using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.DTOs
{
    public record PatientDTO
    {
        [MaxLength(9)]
        [Required]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
