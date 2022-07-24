using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Api.Logging
{
    interface ILoggerSrevice
    {
        void Log(LogLevel logLevel, string message);
    }
}
