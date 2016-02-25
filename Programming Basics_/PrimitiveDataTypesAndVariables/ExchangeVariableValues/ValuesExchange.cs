using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeVariableValues
{
    class ValuesExchange
    {
        static void Main(string[] args)
        {
            byte a = 5;
            byte b = 10;
            Console.WriteLine("Before swap:\n"
                + "a = " + a + "\nb = " + b);

            byte temp = a;
            a = b;
            b = temp;
            Console.WriteLine("\nAfter swap:\n"
                + "a = " + a + "\nb = " + b);
        }
    }
}
