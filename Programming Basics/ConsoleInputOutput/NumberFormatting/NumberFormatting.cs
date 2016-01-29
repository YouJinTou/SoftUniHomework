using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberFormatting
{
    class NumberFormatting
    {
        static void Main(string[] args)
        {            
            Console.Write("a [0, 500]: ");
            int a = int.Parse(Console.ReadLine());           
            if (a < 0 || a > 500)
            {
                throw new ArgumentOutOfRangeException("a",
                    "Integer must be in the valid range.");
            }
            Console.Write("b = ");
            float b = float.Parse(Console.ReadLine());
            Console.Write("c = ");
            float c = float.Parse(Console.ReadLine());

            int maxAB = (int)Math.Max(a, b);
            int max = (int)Math.Max(a, c);
            int padding = max.ToString().Length; // Have a constant to apply to all paddings
                                                 // Still pans out poorly, though

            Console.WriteLine(new string('_', 66 + padding));
            Console.WriteLine("|{0}|{1}|{2}|{3}|", "a".PadRight(7 + padding),
                "b".PadRight(10 + padding), "c".PadRight(7 + padding),
                "Result".PadRight(31 + padding));
            Console.WriteLine(new string('_', 66 + padding));
            Console.Write("|{0}".PadRight(10 + padding) + "|" +
                "{1}".PadRight(10 + padding) + "|{2}".PadRight(10 + padding) +
                "|", a, b, c);
            Console.Write("{0}".PadRight(8 + padding) + "|",
                a.ToString("X"));                                   // To hex
            Console.Write("{0}".PadLeft(5 + padding, '0') + "|",    // To binary
                Convert.ToString(a, 2));
            Console.Write(string.Format("{0:0.00}", b).PadLeft(6 + padding));
            Console.WriteLine("|{0:0.000}" + "|".PadLeft(1 + padding), c);
            Console.WriteLine(new string('_', 66 + padding));
            Console.WriteLine();
        }
    }
}
