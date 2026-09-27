using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    internal class TextReportGenerator
    {
        static void Main()
        {
            string empId = "101";
            string empName = "Arun Kumar";
            string department = "IT";
            double monthSalary = 45000;
            double annualSalary = monthSalary * 12;
            string city = "Chennai";

            StringBuilder report = new StringBuilder();
            report.AppendLine("=======================================");
            report.AppendLine("    EMPLOYEE REPORT     ");
            report.AppendLine("=======================================");
            report.AppendLine($"Employee ID : {empId}");
            report.AppendLine($"Employee Name : {empName}");
            report.AppendLine($"Department : {department}");
            report.AppendLine($"Monthly Salary : {monthSalary}");
            report.AppendLine($"Annual Salary : {annualSalary}");
            report.AppendLine($"City : {city}");
            report.AppendLine("=======================================");

            Console.WriteLine(report.ToString());

        }
    }
}
