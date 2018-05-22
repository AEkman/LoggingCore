using System;

namespace LoggingCore
{
    public class ErrorLog
    {

        public ErrorLog(string productName, string productVersion, string userName, string clientOs, string error)
        {
            Timestamp = DateTime.Now;

            Product = productName;
            Version = productVersion;
            UserName = userName;
            ClientOS = clientOs;
            Error = error;
        }

        public DateTime Timestamp { get; private set; }
        public string Product { get; set; }
        public string Version { get; set; }
        public string UserName { get; set; }
        public string ClientOS { get; set; }
        public string Error { get; set; }
    }
}