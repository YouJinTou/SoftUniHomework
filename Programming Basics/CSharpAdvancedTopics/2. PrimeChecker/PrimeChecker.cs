using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.PrimeChecker
{
    class PrimeChecker
    {
        static bool IsPrime(ulong n)
        {
            if (n % 2 == 0)
                return false;
            for (ulong i = 3; i <= Math.Sqrt(n); i += 2)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            Console.Write("n = ");
            ulong n = ulong.Parse(Console.ReadLine());

            Console.WriteLine("{0} is prime: {1}", n, IsPrime(n));
        }
    }
}
