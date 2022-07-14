﻿using System;

namespace CoronaApp.Services.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Address { get; set; }
        public string City { get; set; }

        public int PatientId { get; set; }

    }
}