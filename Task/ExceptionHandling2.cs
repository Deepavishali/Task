using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{

    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message):base(message)
        {

        }
    }

    public class BankAccount3
    {
        public string AccountNumber { get; }
        public string AccountHolderName { get; }

        public double Balance { get; private set; }

        public BankAccount3(string accountNumber, string accountHolderName, double balance)
        {
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            Balance = balance;
        }

        public void Withdraw(double amount)
        {
            if(amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than 0");
            }
            if(amount > Balance)
            {
                throw new Exception("Insufficient balance for the withdrawal");
            }
            Balance -= amount;
            Console.WriteLine("Withdrawal Successful.");
            Console.WriteLine($"Remaining Balance ${Balance}");
        }
    }
    internal class ExceptionHandling2
    {
        static void Main(string[] args)
        {
            BankAccount3 account = new BankAccount3("AC12345","DEEPA",68279);

            Console.WriteLine($"Account Holder: {account.AccountHolderName}");
            Console.WriteLine($"Balance:{account.Balance}");
            Console.WriteLine("Enter the Withdrawal Amount:");
            if (double.TryParse(Console.ReadLine(), out double withdrawalAmount))
            {
                try
                {
                    account.Withdraw(withdrawalAmount);
                }
                catch (InsufficientBalanceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Invalid Input:{ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid numeric amount");
            }
                Console.ReadLine();
            }

        }
    }

