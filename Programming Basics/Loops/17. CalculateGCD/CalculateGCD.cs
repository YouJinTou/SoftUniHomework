using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.CalculateGCD
{
    class CalculateGCD
    {
        static int GetGCD(int a, int b)
        {
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            
            while (true)
            {
                int remainder = a % b;
                if (remainder == 0)
                    break;
                a = b;
                b = remainder;
            }
            return b;
        }

        static void Main(string[] args)
        {
            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine("GCD = {0}", GetGCD(a, b));
        }
    }
}
