using System;
using System.Diagnostics;

namespace LoggingCore
{
    /// <summary>
    /// Tracking time in elasped miliseconds, stop tracker with Stop() method.
    /// </summary>
    public class PerformanceTracker
    {
        private readonly Stopwatch _stopWatch;
        private readonly String _action;

        /// <summary>
        /// Creating a Performance Tracker, remember to Stop() it.
        /// </summary>
        public PerformanceTracker(string action)
        {
            _stopWatch = Stopwatch.StartNew();
            _action = action;
        }

        /// <summary>
        /// Stop tracking performance
        /// </summary>
        public void Stop()
        {
            _stopWatch.Stop();
            Logger.WritePerformance((int)_stopWatch.ElapsedMilliseconds, _action);
        }
    }
}