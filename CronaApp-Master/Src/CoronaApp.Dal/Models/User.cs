using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoronaApp.Dal.Models;
    public class User
    {
        public int Id { get; set; }

        [EmailAddress]
        [Required]
        public string Name { get; set; }

        [MinLength(8)]
        [Required]
        public string Password { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException(); 
        }

    }

