using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal.models;

public class LocationSearch
{
    [DataType(DataType.DateTime)]
    public DateTime? StartDate { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime? EndDate { get; set; }

    [Range(0, 120)]

    public int? Age { get; set; }
}

