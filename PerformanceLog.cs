using System;

namespace LoggingCore
{
    public class PerformanceLog
    {

        public PerformanceLog(string productName, string productVersion, string userName, string clientOs, int elapsedTimeInMs, string action)
        {
            Timestamp = DateTime.Now;

            Product = productName;
            Version = productVersion;
            UserName = userName;
            ClientOS = clientOs;
            Action = action;
            ElapsedTimeInMs = elapsedTimeInMs;
        }

        public DateTime Timestamp { get; private set; }
        public string Product { get; set; }
        public string Version { get; set; }
        public string UserName { get; set; }
        public string ClientOS { get; set; }
        public string Action { get; set; }
        public int ElapsedTimeInMs { get; set; }
    }
}