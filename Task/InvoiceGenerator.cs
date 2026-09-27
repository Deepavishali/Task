using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    internal class InvoiceGenerator
    {
        static void Main()
        {
            string p1Name = "Laptop"; int p1Qty = 1; double p1Price = 50000;
            string p2Name = "Mouse"; int p2Qty = 2; double p2Price = 500;
            string p3Name = "Keyboard"; int p3Qty = 1; double p3Price = 1500;

            double t1 = p1Qty * p1Price;
            double t2 = p2Qty * p2Price;
            double t3 = p3Qty * p3Price;

            double subtotal = t1 + t2 + t3;
            double gst = subtotal * 0.18;
            double grandTotal = subtotal + gst;

            StringBuilder invoice = new StringBuilder();
            invoice.AppendLine("====================================");
            invoice.AppendLine("INVOICE");
            invoice.AppendLine("====================================");
            invoice.AppendLine("Product    Qty    Price   Amount");
            invoice.AppendLine("------------------------------------");
            invoice.AppendLine($"{p1Name,-12} {p1Qty,-5} {p1Price,-6} {t1}");
            invoice.AppendLine($"{p2Name,-12} {p2Qty,-5} {p2Price,-6} {t2}");
            invoice.AppendLine($"{p3Name,-12} {p3Qty,-5} {p3Price,-6} {t3}");
            invoice.AppendLine("------------------------------------");
            invoice.AppendLine($"SubTotal:  {subtotal}");
            invoice.AppendLine($"GST 18% :   {gst}");
            invoice.AppendLine("------------------------------------");
            invoice.AppendLine($"Grand Total : {grandTotal}");
            invoice.AppendLine("====================================");

            Console.WriteLine(invoice.ToString());
        }
    }
}
