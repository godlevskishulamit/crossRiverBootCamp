using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CoronaApp.Dal.Models;
    public class Patient
    {
        public Patient(string id)
        {
            Id = id;
          
        }
        public Patient()
        {

        }
        public Patient(string id, string name, int? age)
        {
            Id = id;
            Name = name;
            Age = age;
           
        }
        [MinLength(8)]
        [Required]
        public string Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }

    }

