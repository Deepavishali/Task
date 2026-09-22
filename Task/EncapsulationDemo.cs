using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    public class BankAccountPin
    {
        private string pin;

        public BankAccountPin(string initialPin)
        {
            SetPin(initialPin);
        }

        private void SetPin(string newPin)
        {
            if (string.IsNullOrEmpty(newPin) || newPin.Length != 4 || !newPin.All(char.IsDigit))
            {
                throw new ArgumentException("Pin must contain exacty 4 digits");
            }
            pin = newPin;
        }
        public bool ValidatePin(string inputPin)
        {
            return pin == inputPin;
        }

        public void DisplayAccountInfo()
        {
            Console.WriteLine("---- Account Information ----");
            Console.WriteLine("Account Owner : Deepa");
            Console.WriteLine("Account Status: Active");
            Console.WriteLine("PIN Status : Masked(****)");
        }

    }
    internal class EncapsulationDemo
    {
        public static void Main()
        {


            try
            {
                BankAccountPin account = new BankAccountPin("1298");

                account.DisplayAccountInfo();
                Console.WriteLine("ENter your PIN");
                string userInput = Console.ReadLine();

                bool isAunthenticated = account.ValidatePin(userInput);

                if (isAunthenticated)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Access Granted");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Access Denied");
                    Console.ResetColor();
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Initialization Error : {ex.Message}");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
