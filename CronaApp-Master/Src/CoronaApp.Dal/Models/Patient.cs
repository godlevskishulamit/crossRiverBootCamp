using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Dal.Models
{ 
    public class Patient
    {
        public Patient(string id)
        {
            this.Id = id;
          
        }
        public Patient()
        {

        }
        public Patient(string id, string name, int? age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
           
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
}
