namespace CoronaApp.Dal.Models;

public class Patient
{
    [Key]
    [StringLength(9)]
    public string Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}