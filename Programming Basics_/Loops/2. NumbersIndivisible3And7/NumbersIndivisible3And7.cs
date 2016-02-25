using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.NumbersIndivisible3And7
{
    class NumbersIndivisible3And7
    {
        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 != 0 && i % 7 != 0)
                    Console.Write(i + " ");
            }
        }
    }
}
