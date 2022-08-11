namespace CoronaApp.Dal.Models;
public class Patient
{
    [Required]
    [RegularExpression("^[0-9]{9}$")]
    public string Id { get; set; }
    [Required]
    [MinLength(2)]
    public string Name { get; set; }
    [Required]
    [Range(0,120)]
    public int Age { get; set; }
}