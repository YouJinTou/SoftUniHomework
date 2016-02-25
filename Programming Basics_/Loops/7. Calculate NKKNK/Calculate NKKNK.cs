using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _7.Calculate_NKKNK
{
    class Program
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
            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());

            BigInteger result = GetFactorial(n) / (GetFactorial(k) * GetFactorial(n - k));

            Console.WriteLine(result);
        }
    }
}
