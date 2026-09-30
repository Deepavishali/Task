using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    public delegate double SalaryCalculator(double monthlySalary);
    public delegate void NotifyUser(string username);



    internal class DelegateTask1
    {
        public static double CalculateAnnualSalary(double monthlySalary)
        {
            return monthlySalary * 12;
        }

        public static void SendEmail(string username)
        {
            Console.WriteLine($"Email Notification sent to {username}");
        }

        public static void SendSMS(string username)
        {
            Console.WriteLine($"SMS Notification sent to {username}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Employee salary calculation");
            double monthlySalary = 3000;

            // assigning the method to the delegate
            SalaryCalculator salaryDelegate = CalculateAnnualSalary;

            //invoking delegate
            double annualSalary = salaryDelegate(monthlySalary);
            Console.WriteLine($"Annual Salary : {annualSalary}");

            Console.WriteLine("Notification System");
            string username = "Ajith";

            NotifyUser notificationDelegate = SendEmail;
            notificationDelegate(username);

            notificationDelegate = SendSMS;
            notificationDelegate(username);

        }

    }
}
