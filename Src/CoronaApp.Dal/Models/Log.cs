using Microsoft.Extensions.Logging;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal.Models;

 public class Log
{
    [Key]
    public int Id { get; set; }
    public string Message { get; set; }
    public string Level { get; set; }
    [Timestamp]
    public DateTimeKind Timestamp { get; set; }
    public  string Properties { get; set; }
    public string LogEvent { get; set; }
}
