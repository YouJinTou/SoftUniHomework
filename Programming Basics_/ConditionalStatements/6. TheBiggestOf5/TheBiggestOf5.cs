using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.TheBiggestOf5
{
    class TheBiggestOf5
    {
        static void Main(string[] args)
        {
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c = ");
            double c = double.Parse(Console.ReadLine());
            Console.Write("d = ");
            double d = double.Parse(Console.ReadLine());
            Console.Write("e = ");
            double e = double.Parse(Console.ReadLine());
            double max;
            if (a > b && a > c && a > d && a > e)
                max = a;
            else if (b > c && b > d && b > e)
                max = b;
            else if (c > d && c > e)
                max = c;
            else if (d > e)
                max = d;
            else
                max = e;
            Console.WriteLine(max);
        }
    }
}
