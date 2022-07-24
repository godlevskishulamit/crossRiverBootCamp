using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Dal
{
    public class LogMessage
    {
       
            public int ThreadId { get; set; }
            public string Message { get; set; }
            public DateTimeOffset Timestamp { get; set; }
    }
}
