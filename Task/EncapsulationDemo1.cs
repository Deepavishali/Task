using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    public class BankAccountBalance
    {
        private decimal balance;

        public BankAccountBalance(decimal initialBalance)
        {
            if(initialBalance < 500)
            {
                throw new ArgumentException("Initial balance must be at least 500");
            }
            balance = initialBalance;
        }

        public decimal GetBalance()
        {
            return balance;
        }

        public void Deposit(decimal amount)
        {
            if(amount <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Deposit amount must be greater than zero");
                Console.ResetColor();
                return;
            }
            balance += amount;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Successfully deposited {amount}");
            Console.ResetColor();
        }

        public void Withdraw(decimal amount)
        {
         if(amount <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error : Withdrawal amount must be greater  than 0");
                Console.ResetColor();
                return;
            }
         if(amount > balance)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Insufficient balance available.");
                Console.ResetColor();
                return;
            }
            balance -= amount;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Successfully withdrew {amount}");
            Console.ResetColor();
        }
    }
    internal class EncapsulationDemo1
    {
     public static void Main()
        {
            try
            {
                BankAccountBalance account = new BankAccountBalance(1000);
                Console.WriteLine("----Account Balance Management----");
                Console.WriteLine($"Current Balance: {account.GetBalance()}");

                Console.WriteLine("Enter amount to deposit");
                string depositInput = Console.ReadLine();
                decimal depositAmount = Convert.ToDecimal(depositInput);
                account.Deposit(depositAmount);
                Console.WriteLine($"New Balance : {account.GetBalance()}");

                Console.WriteLine("Enter amount to withdraw");
                string withdrawInput = Console.ReadLine();
                decimal withdrawamount = Convert.ToDecimal(withdrawInput);
                account.Withdraw(withdrawamount);
                Console.WriteLine($"New Balance : {account.GetBalance()}");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"Initialization Error: {ex.Message}");
            }
            catch(FormatException)
            {
                Console.WriteLine("Input Error: Please enter a valid numeric value.");
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }
    }
}
