using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal.models;

    public class LocationSearch
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Age { get; set; }
    }

