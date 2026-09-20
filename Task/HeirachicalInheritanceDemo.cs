using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    public class Payment
    {
        protected string paymentId;
        protected string customerName;
        protected double amount;

        public Payment(string id,string customer,double amt)
        {
            paymentId = id;
            customerName = customer;
            amount = amt;
        }

        public void DisplayPaymentDetails()
        {
            Console.WriteLine($"Payment Id : {paymentId}");
            Console.WriteLine($"Customer Name : {customerName}");
            Console.WriteLine($"Amount : {amount}");
        }
    }

    public class CreditCardPayment : Payment
    {
        private string cardNumber;
        public CreditCardPayment(string id ,string customer,double amt, string cardNum):base(id,customer,amt)
        {
            cardNumber = cardNum;
        }

        public void ProcessPayment()
        {
            double processingFee = amount * 0.02;
            double finalAmount = amount + processingFee;

            DisplayPaymentDetails();
            Console.WriteLine("Payment Type : Credit Card");
            Console.WriteLine($"Processing Fee : {processingFee}");
            Console.WriteLine($"Final Amount : {finalAmount}");
            Console.WriteLine("Payment Status : Successful");
        }
    }

    public class  UPIPayment : Payment
    {
        private string upiId;

        public UPIPayment(string id,string customer, double amt, string upi):base(id,customer,amt)
        {
            upiId = upi;
        }

        public void ProcessPayment()
        {
            double processingFee = amount * 0.01;
            double finalAmount = amount + processingFee;

            DisplayPaymentDetails();
            Console.WriteLine("Payment Type : UPI");
            Console.WriteLine($"Processing Fee : {processingFee}");
            Console.WriteLine($"Final Amount : {finalAmount}");
            Console.WriteLine("Payment Status : Successful");
        }
    }
    internal class HeirachicalInheritanceDemo
    {
        static void Main()
        {
            Console.WriteLine("--- Credit Card Payment ---");
            CreditCardPayment ccpay = new CreditCardPayment("CCP001", "Alice", 1000.0, "1234-5678-9012");
            ccpay.ProcessPayment();

            Console.WriteLine();

            Console.WriteLine("---UPI Payment");
            UPIPayment upipay = new UPIPayment("CCUPI001", "Bob", 500.0, "bob@upi");
            upipay.ProcessPayment();
        }
    }
}
