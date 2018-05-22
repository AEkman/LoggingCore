using System;

namespace LoggingCore
{
    public class UserInteractionLog
    {

        public UserInteractionLog(string productName, string productVersion, string userName, string clientOs, string location, string recordedEvent, string recordedValue)
        {
            Timestamp = DateTime.Now;

            Product = productName;
            Version = productVersion;
            UserName = userName;
            ClientOS = clientOs;
            Location = location;
            RecordedEvent = recordedEvent;
            RecordedValue = recordedValue;
        }

        public DateTime Timestamp { get; private set; }
        public string Product { get; set; }
        public string Version { get; set; }
        public string Location { get; set; }
        public string RecordedEvent { get; set; }
        public string RecordedValue { get; set; }
        public string UserName { get; set; }
        public string ClientOS { get; set; }
    }
}