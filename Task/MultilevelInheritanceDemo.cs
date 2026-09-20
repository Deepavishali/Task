using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    public class Customer
    {
        protected int customerId;
        protected string customerName;

        public Customer(int id, string name)
        {
            customerId = id;
            customerName = name;
        }
    }

    public class BankAccount : Customer
    {
        protected string accountNumber;
        protected double balance;


        public BankAccount(int id, string name, string accNumber, double initialBalance) : base(id, name)
        {
            accountNumber = accNumber;
            balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient balance for withdrawal!");
            }
        }
    }

    public class  SavingsAccount : BankAccount
    {
        private double interestRate;

        public SavingsAccount(int id, string name, string accNumber, double initialBalance,double rate):base(id,name,accNumber,initialBalance)
        {
            interestRate = rate;
        }

        public double CalculatedInterest()
        {
            return balance * interestRate / 100;
        }

        public void DisplayAccountDetails(double depositedAmount, double withdrawnAmount, double initialBalanceTracker)
        {
            Console.WriteLine($"Customer Id : {customerId}");
            Console.WriteLine($"Customer Name : {customerName}");
            Console.WriteLine($"Account Number : {accountNumber}");
            Console.WriteLine($"Initial Balance : {initialBalanceTracker}");
            Console.WriteLine($"Deposited Amount : {depositedAmount}");
            Console.WriteLine($"Withdrawn Amount : {withdrawnAmount}");
            Console.WriteLine($"Current Balance : {balance}");
            Console.WriteLine($"Interest Rate : {CalculatedInterest()}");
        }
        
    }
    internal class MultilevelInheritanceDemo
    {
       static void Main()
        {
            int customerId = 101;
            string customerName = "Deepa";
            string accountNumber = "SA123";
            double initialBalance = 1000;
            double depositAmount = 500;
            double withdrawAmount = 200;
            double interestRate = 5;


            SavingsAccount account = new SavingsAccount(customerId, customerName, accountNumber, initialBalance, interestRate);
            {
                account.Deposit(depositAmount);
                account.Withdraw(withdrawAmount);

                account.DisplayAccountDetails(depositAmount, withdrawAmount, initialBalance);
            }
        }
    }
}
