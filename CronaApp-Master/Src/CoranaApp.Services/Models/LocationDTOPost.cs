﻿using System;

namespace CoronaApp.Services.Models
{
    public class LocationDTOPost
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string PatientId { get; set; }
    }
}
