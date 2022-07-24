using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoronaApp.Dal;
public class Location
{
    [RegularExpression("^[0-9]{9}$")]
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

    [ForeignKey("PatientId")]
    public virtual Patient Patient { get; set; }
}

