using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    internal class SingletonPattern
    {
        public sealed class Logger
        {
            private static readonly Logger instance = new Logger();

            private Logger() { }

            public static Logger GetInstance()
            {
                return instance;
            }

            // Method to log messages
            public void Log(string message)
            {
                Console.WriteLine($"[LOG] {message}");
            }
        }

        class Program
        {
            static void Main()
            {
                // Obtaining references using GetInstance()
                Logger logger1 = Logger.GetInstance();
                Logger logger2 = Logger.GetInstance();

                // Logging messages
                logger1.Log("Application Started");
                logger1.Log("User Logged In");
                logger2.Log("Data Saved Successfully");

                Console.WriteLine();

                // Checking if both references point to the same object
                bool isSame = ReferenceEquals(logger1, logger2);
                Console.WriteLine($"Are logger1 and logger2 the same object? {isSame}");
            }
        }
    }
}
