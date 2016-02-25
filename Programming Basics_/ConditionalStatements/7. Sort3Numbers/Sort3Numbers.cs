using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Sort3Numbers
{
    class Sort3Numbers
    {
        static void Main(string[] args)
        {
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c = ");
            double c = double.Parse(Console.ReadLine());            

            if (a <= b)
            {
                if (b < c)
                    Console.WriteLine(c + " " + b + " " + a); // c b a
            }
            else if (b <= a)
            {
                if (a < c) 
                    Console.WriteLine(c + " " + a + " " + b); // c a b
            }
            else if (a <= c)
            {
                if (c < b)
                    Console.WriteLine(b + " " + c + " " + a); // b a c
            }
            else if (a >= b)
            {
                if (b > c)
                    Console.WriteLine(a + " " + b + " " + c); // a b c
            }
            else if (b >= c)
            {
                if (c > a)
                    Console.WriteLine(b + " " + c + " " + a); // b c a
            }
            else if (b <= c)
            {
                if (c < a)
                    Console.WriteLine(a + " " + c + " " + b); // c a b
            }
        }
    }
}
