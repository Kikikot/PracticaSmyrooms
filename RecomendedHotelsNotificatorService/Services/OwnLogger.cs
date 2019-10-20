using System;
using System.Collections.Generic;
using ExternalLibraries.LoggSystem;

namespace RecomendedHotelsNotificatorService.Services
{
    public class OwnLogger : ILogger
    {
        public static readonly List<Tuple<string, Exception>> AllLogs = new List<Tuple<string, Exception>>();

        public void Log(string message, Exception e = null)
        {
            AllLogs.Add(new Tuple<string, Exception>(message, e));
        }
    }
}
