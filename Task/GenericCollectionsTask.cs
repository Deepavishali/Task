using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    internal class GenericCollectionsTask
    {
        static void Main(string[] args)
        {
            // List

            Console.WriteLine("----- List -----");
            List<int> ints = new List<int> { 101, 102, 103, 104, 105 };

            foreach(var id in ints)
            {
                Console.WriteLine(id);
            }
            ints.Remove(103);
            Console.WriteLine("After removing 103: ");
            foreach(var id in ints)
            {
                Console.WriteLine(id);
            }

            Console.WriteLine();

            // Dictionary

            Console.WriteLine();

            Console.WriteLine("----- Dictionary -----");
            Dictionary<int, string> employees = new Dictionary<int, string>
            {
                { 101,"Arun" },
                {102,"Priya" },
                {103,"kumar" },
               {104,"Divya" },
                {105,"Rahul" }
            };

            foreach (KeyValuePair<int,string> kvp in employees)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
            Console.WriteLine();

            // HashSet

            Console.WriteLine();

            Console.WriteLine("----- HashSet -----");
            HashSet<string> departments = new HashSet<string>
            {
                "IT","HR","Finance","IT","HR"
            };

            foreach(var dept in departments)
            {
                Console.WriteLine(dept);
            }
            Console.WriteLine();

            //Queue

            Console.WriteLine();

            Console.WriteLine("----- Queue -----");
            Queue<string> serviceQueue = new Queue<string>();
            serviceQueue.Enqueue("Arun");
            serviceQueue.Enqueue("Priya");
            serviceQueue.Enqueue("Kumar");
            serviceQueue.Enqueue("Dvya");

            while (serviceQueue.Count > 0)
            {
                Console.WriteLine($"Processing: {serviceQueue.Dequeue()}");
            }

            Console.WriteLine();


            //stack

            Console.WriteLine();

            Console.WriteLine("----- Stack -----");
            Stack<string> pageStack = new Stack<string>();
            pageStack.Push("Login");
            pageStack.Push("Dashboard");
            pageStack.Push("Home");
            pageStack.Push("Employee List");

            string removedPage = pageStack.Pop();

            Console.WriteLine($"Current Page: {pageStack.Peek()}");
            Console.WriteLine($"Previous page: {removedPage}");


            Console.WriteLine();


            //SortedList

            Console.WriteLine();

            Console.WriteLine("----- SortedList -----");
            SortedList<int, double> employeeSalaries = new SortedList<int, double>
            {
                {103,45000 },
                {102,55000 },
                {101,40000 }
            };

            foreach(KeyValuePair<int,double> kv in employeeSalaries)
            {
                Console.WriteLine($"{kv.Key} - {kv.Value}");
            }

            Console.WriteLine();
        }
    }
}
