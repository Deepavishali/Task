using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    public class  Employee1
    {
        protected string name;

        public Employee1(string empName)
        {
            name = empName;
        }

        public void DisplayName()
        {
            Console.WriteLine($"Employee Name:{name}");
        }
        //overloading
        public double CalculatedSalary(double basicSalary)
        {
            return basicSalary;
        }

        public double CalculatedSalary(double basicSalary, double bonus)
        {
            return basicSalary + bonus;
        }

        public double CalculatedSalary(double basicSalary, double bonus, double allowance)
        {
            return basicSalary + bonus + allowance;
        }

        //overridding

        public virtual void DisplayRole()
        {
            Console.WriteLine("Employee Role : General Employee");
        }
    }

    //Derived class
    public class Developer : Employee1
    {
        public Developer(string empName) : base(empName)
        {
            name = "Deepa";
        }
        public override void DisplayRole()
        {
            Console.WriteLine("Employee Role : Developer");
        }
    }

    public class Trainer : Employee1
    {
        public Trainer(string empName):base(empName)
        {
          
        }
        public override void DisplayRole()
        {
            Console.WriteLine("Employee Role : Trainer");
        }
    }

    internal class InheritanceTask
    {
        static void Main()
        {
            string empName = "Rave";
            double basicSalary = 50000;
            double bonus = 10000;
            double allowance = 5000;

            Employee1 emp = new Developer(empName);

            emp.DisplayName();

            Console.WriteLine($"Basic Salary : {emp.CalculatedSalary(basicSalary)}");
            Console.WriteLine($"Bonus : {emp.CalculatedSalary(basicSalary, bonus)}");
            Console.WriteLine($"Allowance : {emp.CalculatedSalary(basicSalary, bonus, allowance)}");

            emp.DisplayRole();
        }
    }
}
