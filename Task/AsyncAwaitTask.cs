using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace Task
{
    internal class AsyncAwaitTask
    {
        class Program
        {
            public static void TakeOrder(string customer, string food)
            {
                Console.WriteLine($"Customer {customer}: Orders {food}");
                Console.WriteLine($"Waiter: Took order from Customer {customer}");
            }

            public static void SendToKitchen(string customer, string food)
            {
                Console.WriteLine($"Waiter: Sent {food} order to kitchen");
            }

            public static async System.Threading.Tasks.Task PrepareFoodAsync(string food, int delaySeconds)
            {
                Console.WriteLine($"Kitchen: {food} preparation started...");
                await System.Threading.Tasks.Task.Delay(delaySeconds * 1000);
                Console.WriteLine($"Kitchen: {food} is ready!");
            }

            public static void ServeFood(string customer, string food)
            {
                Console.WriteLine($"Waiter: Serving {food} to Customer {customer}");
            }

            public static async System.Threading.Tasks.Task ProcessOrderAsync(string customer, string food, int delaySeconds)
            {
                await PrepareFoodAsync(food, delaySeconds);
                ServeFood(customer, food);
            }

            static async System.Threading.Tasks.Task Main(string[] args)
            {
                Console.WriteLine("----- Restaurant System -----");

                TakeOrder("1", "Pasta");
                SendToKitchen("1", "Pasta");
                System.Threading.Tasks.Task task1 = ProcessOrderAsync("1", "Pasta", 5);

                TakeOrder("2", "Fried Rice");
                SendToKitchen("2", "Fried Rice");
                System.Threading.Tasks.Task task2 = ProcessOrderAsync("2", "Fried Rice", 3);

                TakeOrder("3", "Sushi");
                SendToKitchen("3", "Sushi");
                System.Threading.Tasks.Task task3 = ProcessOrderAsync("3", "Sushi", 7);

                TakeOrder("4", "Burger");
                SendToKitchen("4", "Burger");
                System.Threading.Tasks.Task task4 = ProcessOrderAsync("4", "Burger", 2);

                await System.Threading.Tasks.Task.WhenAll(task1, task2, task3, task4);

                Console.WriteLine("All customers have been served. Kitchen closing!");
                Console.WriteLine();
            }
        }
    }
}
