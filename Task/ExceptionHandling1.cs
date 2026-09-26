using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException(string message) : base(message)
        {

        }
    }

    public class PasswordValidator
    {
        public void Validate(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 6)
            {
                throw new InvalidPasswordException("Password must have a minimum of 6 characters.");
            }
            if (password.Any(char.IsWhiteSpace))
            {
                throw new InvalidPasswordException("Password cannot contain whitespace");
            }
            if (!password.Any(char.IsLower))
            {
                throw new InvalidPasswordException("Password must contain at least one lowercase character");
            }
            if (!password.Any(char.IsUpper))
            {
                throw new InvalidPasswordException("Password must contain atleast one uppercase character");
            }
            if (!password.Any(ch => char.IsLetterOrDigit(ch)))
            {
                throw new
                    ("Password must contain at least one letter or digit");
            }
            Console.WriteLine("Password is valid.");
        }
    }
    internal class ExceptionHandling1
    {
        static void Main(string[] args)
        {
            PasswordValidator validator = new PasswordValidator();
            Console.WriteLine("Enter a password to validate:");
            string password = Console.ReadLine();
            try
            {
                validator.Validate(password);
                Console.WriteLine("Password validation successful.");
            }
            catch (InvalidPasswordException ex)
            {
                Console.WriteLine($"Password validation failed: {ex.Message}");

                Console.WriteLine();
            }
        }
    }

}
