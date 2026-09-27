using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    internal class LogMessageFormatter
    {
        static void Main()
        {
            string input = "101 | error | database connection failed";
            string[] parts = input.Split('|');
            string logId = parts[0].Trim();
            string logLevel = parts[1].Trim().ToUpper();
            string logMessage = parts[2].Trim();

            if (logMessage.Length > 0)
            {
                logMessage = char.ToUpper(logMessage[0]) + logMessage.Substring(1);

            }

            StringBuilder logBuilder = new StringBuilder();

            logBuilder.AppendLine($"Log ID : {logId}");
            logBuilder.AppendLine($"Log level : {logLevel}");
            logBuilder.AppendLine($"Log Message : {logMessage}");
            logBuilder.AppendLine($"Status : {(logLevel == "ERROR" ? "Critical" : "Normal")}");

            string result = logBuilder.ToString();
            Console.WriteLine("result :"+result);
        }
    }
}

