using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.Models
{
    public class PatientDTO
    {
        public PatientDTO()
        {

        }
        public PatientDTO(string id)
        {
            Id = id;

        }
        public string Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
    }
}
