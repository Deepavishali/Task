using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    public interface IOnlineBanking
    {
        void TransferMoney(double amount, string receiver);
    }

    public abstract class BankAccount1 : IOnlineBanking
    {
        protected string accountNumber;
        protected string holderNmae;
        protected double balance;

        public BankAccount1(string accNumber,string name)
        {
            accountNumber = accNumber;
            holderNmae = name;
            balance = 0;
        }

        public void Deposit(double amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited : {amount}");
            Console.WriteLine($"Current Balance: {balance}");
        }

        public abstract void Withdraw(double amount);
        public abstract double CalculateInterest();

        public abstract void TransferMoney(double amount, string receiver);

        public void DisplayBasicDetails()
        {
            Console.WriteLine($"Account Number:{accountNumber}");
            Console.WriteLine($"Holder Name:{holderNmae}");
            Console.WriteLine("Initial Balance: 0");
        }

    }

    //Derived class1

    public class SavingsAccount1 : BankAccount1
    {
        public SavingsAccount1(string accNumber,string name) : base(accNumber, name)
        {
        }

        public override void Withdraw(double amount)
        {
            if(amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Withdrawn: {amount}");
                Console.WriteLine($"Current Balance: {balance}");
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
                Console.WriteLine($"Current Balance : {balance}");
            }
        }

        public override double CalculateInterest()
        {
            return balance * 4 / 100;
        }

        public override void TransferMoney(double amount, string receiver)
        {
            if(amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Transferred {amount} to {receiver}");
                Console.WriteLine($"Remaining Balance : {balance}");
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
                Console.WriteLine($"Current Balance : {balance}");
            }
        }
    }

    //Derived class2

    public class CurrentAccount : BankAccount1
    {
        public CurrentAccount(string accNumber, string name) : base(accNumber, name) { }

        public override void Withdraw(double amount)
        {
            if ((balance-amount) >= 1000)
            {
                balance -= amount;
                Console.WriteLine($"Withdrawal :{amount}");
                Console.WriteLine($"Current Balance : {balance}");
            }
            else
            {
                Console.WriteLine("Insufficient Balance(Must have 100 minimum balance)");
                Console.WriteLine($"Current Balance:{balance}");
            }
        }

        public override double CalculateInterest()
        {
            return 0;
        }

        public override void TransferMoney(double amount, string receiver)
        {
            if ((balance - amount) >= 1000)
            {
                balance -= amount;
                Console.WriteLine($"Transferred {amount} to {receiver}");
                Console.WriteLine($"Remaining Balance : {balance}");
            }
            else
            {
                Console.WriteLine("Transfer failed. Must maintain ₹1,000 minimum balance.");
                Console.WriteLine($"Current Balance : {balance}");
            }
        }
    }

    internal class AbstractionDemo
    {
        static void Main()
        {
            
            Console.WriteLine("Enter Account Type:");
            Console.WriteLine("1. Savings");
            Console.WriteLine("2. Current");
            Console.Write("Choice: ");

            
            int choice = Convert.ToInt32(Console.ReadLine());

            string accountNumber = "1001";
            string holderName = "Ajith";
            double depositAmount = 20000;
            double withdrawalAmount = 5000;
            double transferAmount = 3000;
            string receiver = "Vinoth";

            BankAccount1 account = null;

            if (choice == 1)
            {
                Console.WriteLine("Savings Account");
                account = new SavingsAccount1(accountNumber, holderName);
            }
            else if (choice == 2)
            {
                Console.WriteLine("Current Account");
                account = new CurrentAccount(accountNumber, holderName);
            }

            if(account != null)
            {
                account.DisplayBasicDetails();
                account.Deposit(depositAmount);
                account.Withdraw(withdrawalAmount);

                double interest = account.CalculateInterest();
                Console.WriteLine($"Interest : ₹{interest}");

                account.TransferMoney(transferAmount, receiver);
            }
        }
    }
}
