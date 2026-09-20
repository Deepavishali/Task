using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    public class Employee2
    {
        protected int employeeId;
        protected string name;
        protected double basicSalary;

        public Employee2(int id,string empName, double salary)
        {
            employeeId = id;
            name = empName;
            basicSalary = salary;
        }

        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"Employee Id : {employeeId}");
            Console.WriteLine($"Employee Name : {name}");
            Console.WriteLine($"Employee Salary : {basicSalary}");
        }
    }

    public class  Payroll : Employee2
    {
      public Payroll(int id, string empName, double salary) : base(id, empName, salary)
        {

        }

        public double CalculateHRA()
        {
            return basicSalary * 0.20;
        }

        public double CalculateDA()
        {
            return basicSalary * 0.10;
        }
        
        public double CalculateGrossSalary()
        {
            return basicSalary + CalculateHRA() + CalculateDA();
        }

        public void DisplayPayroll()
        {
            DisplayEmployeeDetails();
            Console.WriteLine($"HRA:{CalculateHRA()}");
            Console.WriteLine($"DA:{CalculateDA()}");
            Console.WriteLine($"Gross Salary:{CalculateGrossSalary()}");
        }
    }
    internal class SingleInheritance
    {
        public static void main()
        {
            int id = 1;
            string name = "vishali";
            double basicSalary = 50000;

            Payroll employeePayroll = new Payroll(id, name, basicSalary);

            employeePayroll.DisplayPayroll();
        }
    }
}
