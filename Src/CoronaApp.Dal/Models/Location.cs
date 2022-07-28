using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CoronaApp.Dal;
public class Location
{
    public int Id { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime StartDate { get; set; }
   
    [DataType(DataType.DateTime)]
    public DateTime EndDate { get; set; }

    [MinLength(3)]
    public string City { get; set; }

    [MinLength(3)]
    public string Address { get; set; }

    [Display(Name = "Patient")]
    public virtual string PatientId { get; set; }

    [JsonIgnore]
    [ForeignKey("PatientId")]
    public virtual Patient Patient { get; set; }
}

