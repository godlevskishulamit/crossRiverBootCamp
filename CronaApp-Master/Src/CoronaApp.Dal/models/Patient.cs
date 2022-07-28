using System;
using System.ComponentModel.DataAnnotations;

namespace CoronaApp.Services.Models;

    public class Patient
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [MaxLength(9)]
        public string IdNumber { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

    }
