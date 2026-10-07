using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Task
{
    internal class ListTask
    {
        public class Employee
        {
            public int EmployeeId { get; }
            public string EmployeeName { get; }

            public int Age { get; }
            public double Salary { get; }
            public string Department { get; }
            public string Role { get; }

            public Employee(int employeeId, string employeeName, int age, double salary, string department, string role)
            {
                EmployeeId = employeeId;
                EmployeeName = employeeName;
                Age = age;
                Salary = salary;
                Department = department;
                Role = role;
            }

            public void DisplayDetails()
            {
                Console.WriteLine($"Name : {EmployeeName}");
                Console.WriteLine($"Age : {Age}");
                Console.WriteLine($"Salary : {Salary}");
                Console.WriteLine($"Department : {Department}");
                Console.WriteLine($"Role : {Role}");
            }
        }

        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee(101,"Arun",25,35000,"IT","Developer"),
                new Employee(102,"Priya",28,45000,"HR","Manager"),
                new Employee(103,"Kumar",30,55000,"IT","Senior Developer"),
                new Employee(104,"Divya",24,30000,"Finance","Analyst"),
                new Employee(105,"Karthik",32,60000,"HR","Director"),
                new Employee(106,"Suresh",35,65000,"IT","Tech Lead"),
                new Employee(107,"Anitha",26,40000,"Finance","Accountant"),
                new Employee(108,"Rahul",29,48000,"IT","Tester"),


            };

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("--------- ");
                Console.WriteLine("1. Insert Employee");
                Console.WriteLine("2. Display All Employees");
                Console.WriteLine("3. Search Employee");
                Console.WriteLine("4. Filter Employees");
                Console.WriteLine("5. Sort Employees");
                Console.WriteLine("6. Delete Employee");
                Console.WriteLine("7. Show Counts");
                Console.WriteLine("8. Exit");
                Console.WriteLine("Choose an option: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Employee ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Name:");
                        string name = Console.ReadLine();
                        Console.Write("Enter Age: ");
                        int age = int.Parse(Console.ReadLine());
                        Console.Write("Enter Salary");
                        double salary = double.Parse(Console.ReadLine());
                        Console.Write("Enter Department: ");
                        string department = Console.ReadLine();
                        Console.Write("Enter Role: ");
                        string role = Console.ReadLine();

                        employees.Add(new Employee(id, name, age, salary,department, role));
                        Console.WriteLine("Employee added successfully.");
                        break;

                    case "2":
                        Console.WriteLine($"{"ID",-6} {"Name",-12} {"Age",-4} {"Salary",-8} {"Department",-10} {"Role",-12}");
                        Console.WriteLine(new string('-', 60));
                        foreach (var emp in employees)
                        {
                            Console.WriteLine($"{emp.EmployeeId,-6} {emp.EmployeeName,-12} {emp.Age,-6} {emp.Salary,-10} {emp.Department,-12} {emp.Role}");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Enter Employee ID or Name to Search: ");
                        string searchTerm = Console.ReadLine();
                        var foundEmp = employees.FirstOrDefault(e => e.EmployeeId.ToString() == searchTerm || e.EmployeeName.Equals(searchTerm, StringComparison.OrdinalIgnoreCase));

                        if(foundEmp != null)
                        {
                            Console.WriteLine("Employee Found:");
                            foundEmp.DisplayDetails();
                        }
                        else
                        {
                            Console.WriteLine("Employee not found");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Filter Options:");
                        Console.WriteLine("1. IT Department");
                        Console.WriteLine("2. Salary > 50000");
                        Console.WriteLine("3.Age >25");
                        Console.Write("Select filter:");
                        string filterChoice = Console.ReadLine();

                        if(filterChoice == "1")
                        {
                            var itEmps = employees.Where(e => e.Department.Equals("IT", StringComparison.OrdinalIgnoreCase));
                            Console.WriteLine("IT Employees:");
                            foreach (var e in itEmps)
                                Console.WriteLine($"{e.EmployeeId} - {e.EmployeeName,-12} - {e.Salary} ");
                        }
                        else if (filterChoice == "2")
                        {
                            var highEarners = employees.Where(e => e.Salary > 50000);
                            Console.WriteLine("Employees with Salary > 50000:");
                            foreach (var e in highEarners) Console.WriteLine($"{e.EmployeeId} - {e.EmployeeName} - {e.Salary}");

                        }
                        else if (filterChoice == "3")
                        {
                            var olderEmps = employees.Where(e => e.Age > 25);
                            Console.WriteLine("Employees whose age is greater than 25 :");
                            foreach (var e in olderEmps) Console.WriteLine($"{e.EmployeeId} - {e.EmployeeName} - {e.Age}");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Sort Options:");
                        Console.WriteLine("1. Name Ascending");
                        Console.WriteLine("2. Salary Ascending");
                        Console.WriteLine("3. Salary Descending");
                        Console.WriteLine("4. Age Ascending");
                        Console.WriteLine("Select Sort Credentials");
                        string sortChoice = Console.ReadLine();

                        IEnumerable<Employee> sortedList = employees;
                        if (sortChoice == "1") sortedList = employees.OrderBy(e => e.EmployeeName);
                        if (sortChoice == "2") sortedList = employees.OrderBy(e => e.Salary);
                        if (sortChoice == "3") sortedList = employees.OrderByDescending(e => e.Salary);
                        if (sortChoice == "4") sortedList = employees.OrderBy(e => e.Age);

                        Console.WriteLine("Sorted Employees:");
                        foreach(var e in sortedList)
                        {
                            Console.WriteLine($"{e.EmployeeName,12} {e.Salary}");
                        }
                        break;

                    case "6":
                        Console.Write("Enter Employee ID to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        var targetEmp = employees.FirstOrDefault(e => e.EmployeeId == deleteId);

                        if(targetEmp != null)
                        {
                            employees.Remove(targetEmp);
                            Console.WriteLine("Employee Deleted Successfully.");
                        }
                        else
                        {
                            Console.WriteLine("EMployee not found.");
                        }
                        break;

                    case "7":
                        int totalCount = employees.Count;
                        int itCount = employees.Count(e => e.Department.Equals("IT", StringComparison.OrdinalIgnoreCase));
                        int highSalaryCount = employees.Count(e => e.Salary > 50000);

                        Console.WriteLine($"Total Employees: {totalCount}");
                        Console.WriteLine($"IT Employees: {itCount}");
                        Console.WriteLine($"EMployees with Salary > 50000 : {highSalaryCount}");
                        break;

                    case "8":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
 