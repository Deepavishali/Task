using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    public delegate void SalaryAction(ref double salary);
    internal class DelegateTask2
    {
        public static void AddAllowance(ref double salary)
        {
            salary += 8000 + 3000;
            Console.WriteLine($"After Allowance : {salary}");
        }

        public static void ApplyDeductions(ref double salary)
        {
            salary -= (4000 + 2000);
            Console.WriteLine($"After deductions : {salary}");
        }

        static void Main(string[] args)
        {
            double basicSalary = 40000;
            Console.WriteLine($"Basic Salary: {basicSalary}");

            SalaryAction salaryactiondelegate = AddAllowance;
            // by using += we are assigning another method also to delegate and make it multicast delegate
            salaryactiondelegate += ApplyDeductions;
            //invoke delegate
            salaryactiondelegate(ref basicSalary);

            Console.WriteLine($"Final Monthly Salary : {basicSalary}");
            double annualCTC = basicSalary * 12;
            Console.WriteLine($"Annual CTC : {annualCTC}");
        }
    }
}
