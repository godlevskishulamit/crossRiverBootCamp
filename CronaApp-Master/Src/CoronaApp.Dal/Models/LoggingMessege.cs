using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Api.Logging
{
	public class LoggingMessege
	{
		[Key]
        public int Id { get; set; }
        public string ThreadId { get; set; }
		public string Message { get; set; }
		public string Level { get; set; }
		public DateTimeOffset Timestamp { get; set; }
        public string Properties { get; set; }
		public string LogEvent { get; set; }
	}
}
