using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace SomeFactorials
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("n: ");
            int n = int.Parse(Console.ReadLine());
            BigInteger factorial = 1;
            while (n > 0)   
            {
                factorial *= n;
                n--;
            }

            Console.WriteLine("n! = " + factorial);

        }
    }
}
