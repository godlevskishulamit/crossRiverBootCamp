﻿using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace CoronaApp.Dal
{
    public class User
    {
        [MaxLength(9)]
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}