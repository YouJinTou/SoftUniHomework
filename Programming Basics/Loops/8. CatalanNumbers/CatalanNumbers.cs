using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _8.CatalanNumbers
{
    class CatalanNumbers
    {
        static BigInteger GetFactorial(int n)
        {
            if (n == 0)
                return 1;

            BigInteger result = n;
            while (n > 1)
            {
                result *= n - 1;
                n--;
            }
            return result;
        }

        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
        
            BigInteger result = GetFactorial(2 * n) /
                (GetFactorial(n + 1) * GetFactorial(n));

            Console.WriteLine("Catalan number {0} is {1}.", n, result);
        }
    }
}
