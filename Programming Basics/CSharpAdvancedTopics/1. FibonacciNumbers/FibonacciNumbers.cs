using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.FibonacciNumbers
{
    class FibonacciNumbers
    {
        static ulong[] fib;
        static ulong GetFibonacci(int n)
        {
            if (fib[n] == 0)
                return GetFibonacci(n - 1) + GetFibonacci(n - 2);
            return fib[n];
        }
        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            fib = new ulong[n + 2];
            fib[0] = 1;
            fib[1] = 1;

            Console.WriteLine("Fibonacci #{0}: {1}", n, GetFibonacci(n));
        }
    }
}
