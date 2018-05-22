using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using System;

namespace LoggingCore
{
    /// <summary>
    /// Using Serilog for writing structured logdata to file
    /// </summary>
    public static class Logger
    {
        private static readonly string _productName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name.ToString();
        private static readonly string _productVersion = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
        private static readonly string _userName = Environment.UserName.GetHashCode().ToString();
        private static readonly string _clientOs = Environment.OSVersion.VersionString;

        private static readonly ILogger _logger;

        /// <summary>
        /// Setting configurations to all different loggers
        /// </summary>

        static Logger()
        {
            // We will log to the system's temp catalog, e g c:\Windows\Temp.
            var fileName =
                Environment.GetEnvironmentVariable("TEMP", EnvironmentVariableTarget.Machine)
                + "\\dirigo\\" + Environment.MachineName + "-" + DateTime.Now.ToString("yyyy-MM-dd")
                + ".json";

            _logger = new LoggerConfiguration()
                .WriteTo.File(new CompactJsonFormatter(), fileName)
                .CreateLogger();
        }

        /// <summary>
        /// Collecting usermetrics
        /// </summary>
        public static void WriteUserInteraction(string location, string recordedEvent, string recordedValue)
        {
            var informationToLog = new UserInteractionLog(_productName, _productVersion, _userName, _clientOs, location, recordedEvent, recordedValue);
            _logger.Write(LogEventLevel.Information, "{@UserInteractionLog}", informationToLog);
        }

        /// <summary>
        /// Collecting errors
        /// </summary>
        public static void WriteError(string error)
        {
            var informationToLog = new ErrorLog(_productName, _productVersion, _userName, _clientOs, error);
            _logger.Write(LogEventLevel.Error, "{@ErrorLog}", informationToLog);
        }

        /// <summary>
        /// Collecting performance
        /// </summary>
        public static void WritePerformance(int elapsedTimeInMs, string action)
        {
            var informationToLog = new PerformanceLog(_productName, _productVersion, _userName, _clientOs, elapsedTimeInMs, action);
            _logger.Write(LogEventLevel.Information, "{@PerformanceLog}", informationToLog);
        }
    }
}