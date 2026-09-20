using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    public class Employee
    {
        private int id;
        private string name;
        private string department;
        private double salary;

        //Default constructor

        public Employee()
        {
            id = 0;
            name = "Unknown";
            department = "Unknown";
            salary = 0.0;
        }

        //Parameterized constructor

        public Employee(int empId, string empName, string empDept, double empSal)
        {
            id = empId;
            name = empName;
            department = empDept;
            salary = empSal;
        }

        //copy constructor

        public Employee(Employee existingEmp)
        {
            id = existingEmp.id;
            name = existingEmp.name;
            department = "Management";
            salary = existingEmp.salary * 2.25;
        }
        public void DisplayDetails()
        {
            Console.WriteLine($"Id : {id}");
            Console.WriteLine($"Name : {name}");
            Console.WriteLine($"Department : {department}");
            Console.WriteLine($"Salary : {salary}");
        }

    }

    internal class ConstructorClass
    {
        static void Main()
        {
            Console.WriteLine("Default constructor");
            Employee emp1 = new Employee();
            emp1.DisplayDetails();

            Console.WriteLine("parametrized constructor");
            Employee emp2 = new Employee(1, "Deepa" , "IT", 50000);
            emp2.DisplayDetails();

            Console.WriteLine("copy constructor");
            Employee emp3 = new Employee(emp2);
            emp3.DisplayDetails();

            Console.WriteLine("Original Employee details");
            emp1.DisplayDetails();
        }
    }
}
