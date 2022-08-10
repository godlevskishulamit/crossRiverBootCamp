
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Dal
{
    public class Patient
    {

        //[^[0-9]{9}$]
        [Required]
        [MinLength(8)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
    }
}
