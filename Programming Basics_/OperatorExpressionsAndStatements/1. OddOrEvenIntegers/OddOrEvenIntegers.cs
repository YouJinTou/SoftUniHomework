using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.OddOrEvenIntegers
{
    class OddOrEvenIntegers
    {
        static void Main(string[] args)
        {
            Console.Write("Integer to check: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine((n % 2 == 0) ? "Even" : "Odd");
        }
    }
}
