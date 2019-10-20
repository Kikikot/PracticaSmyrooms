using System;

namespace ExternalLibraries.LoggSystem
{
    public interface ILogger
    {
        void Log(string message, Exception e = null);
    }
}
