using System;

namespace LoggingKata
{
    public class TacoLogger : ILog
    {
        //these are placed within the app to pinpoint where it failed
        //(ie)-when initializing app, in Taco Parser Class, if csv file has less than 3 items in array
        //of current line log error will be triggered to print to console while in program class, error
        //or warning will be triggered with 0,1 or 2 items
        public void LogFatal(string log, Exception exception = null)
        {
            Console.WriteLine($"Fatal: {log}, Exception {exception}");
        }

        public void LogError(string log, Exception exception = null)
        {
            Console.WriteLine($"Error: {log}, Exception {exception}");
        }

        public void LogWarning(string log)
        {
            Console.WriteLine($"Warning: {log}");
        }

        public void LogInfo(string log)
        {
            Console.WriteLine($"Info: {log}");
        }

        public void LogDebug(string log)
        {
            Console.WriteLine($"Debug: {log}");
        }
    }
}
