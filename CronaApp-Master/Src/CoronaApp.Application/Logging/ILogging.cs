using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CoronaApp.Api.Logging
{
    public interface ILoggerService
    {
        void Log(LogLevel logLevel, string message);
    }
}

