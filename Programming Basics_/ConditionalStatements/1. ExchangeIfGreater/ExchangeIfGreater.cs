using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.ExchangeIfGreater
{
    class ExchangeIfGreater
    {
        static void Main(string[] args)
        {
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());

            if (a > b)
            {
                double swap = a;
                a = b;
                b = swap;
            }
            Console.WriteLine(a + " " + b);
        }
    }
}
