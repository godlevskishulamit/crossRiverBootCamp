using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoronaApp.Dal.Models
{
    public class User
    {
        public string  UserId { get; set; }

        [Required] 
        public string  Password { get; set; }
        [Required] 
        public string UserName { get; set; }

        public User()
        {
        }
    }
}

