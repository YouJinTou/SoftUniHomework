using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullValues
{
    class NullValues
    {
        static void Main(string[] args)
        {
            int? value1 = null;
            double? value2 = null;

            Console.WriteLine("Before...");
            Console.WriteLine(value1);
            Console.WriteLine(value2);

            value1 += 4;
            value2 += 2.13d;

            Console.WriteLine("After...");
            Console.WriteLine(value1); // Prints nothing
            Console.WriteLine(value2); // Prints nothing

        }
    }
}
