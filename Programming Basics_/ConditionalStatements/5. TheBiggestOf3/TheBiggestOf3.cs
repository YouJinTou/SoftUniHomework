using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.TheBiggestOf3
{
    class TheBiggestOf3
    {
        static void Main(string[] args)
        {
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c = ");
            double c = double.Parse(Console.ReadLine());

            double max = Math.Max(a, b);
            double maxFinal = Math.Max(max, c);
            Console.WriteLine(maxFinal);
        }
    }
}
