using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 2, b = 4;
            Swap(a, b);
        }
        static void Swap(int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine("swapped values : a = " + a + " b = " + b);
        }
       
    }
}
 