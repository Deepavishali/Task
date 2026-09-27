using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    internal class PasswordAnalyser
    {
        static void Main()
        {
            Console.Write("Enter Password :");
            string password = Console.ReadLine() ?? string.Empty;

// ?? -> It is called null coalescing operator , it returns "" to the password so that ensures that password is not null

            int length = password.Length;
            bool hasUpper = password.Any(char.IsUpper);
            bool hasLower = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecial = password.Any(ch => !char.IsLetterOrDigit(ch));

            Console.WriteLine($"Password Length : {length}");
            Console.WriteLine($"Uppercase: {(hasUpper ? "yes":"no")}");
            Console.WriteLine($"Lowercase : {(hasLower ? "yes":"no")}");
            Console.WriteLine($"Digit:{(hasDigit ? "yes":"no")}");
            Console.WriteLine($"Special Character:{(hasSpecial ? "yes":"no")}");

            int metCriteria = (hasUpper ? 1 : 0) + (hasLower ? 1 : 0) + (hasDigit ? 1 : 0) + (hasSpecial ? 1 : 0);
            string strength = length >= 8 && metCriteria == 4 ? "Strong" : (metCriteria >= 2 ? "Medium" : "Weak");

            Console.WriteLine($"\nStrength : {strength}");

            if(metCriteria < 4)
            {
                Console.WriteLine("Missing Requirement : ");
                if (!hasUpper) Console.Write("Uppercase ,");
                if (!hasLower) Console.Write("LowerCase ,");
                if (!hasDigit) Console.Write("Digit ,");
                if (!hasSpecial) Console.Write("Special Character");
                Console.WriteLine();
            }
        }
       

    }
}
