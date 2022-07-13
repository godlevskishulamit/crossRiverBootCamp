using System;
using System.Collections.Generic;
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
        public string Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }

    }
}
