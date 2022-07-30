
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CoronaApp.Dal.Models
{
    public class User
    {
        public int ID { get; set; }

        [EmailAddress]
        public string Name { get; set; }

        [MinLength(3)]
        public string Password { get; set; }


    }
}
