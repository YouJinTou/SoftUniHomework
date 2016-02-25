using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _18.TrailingZeroesInN_
{
    class Program
    {
        static BigInteger GetFact(int n) // Yes
        {
            BigInteger result = n;
            while (n > 1)
            {
                result *= n - 1;
                n--;
            }
            return result;
        }

        static int GetZeroes(BigInteger factorial)
        {
            int zeroes = 0;
            string factorialString = factorial.ToString();
            int length = factorialString.Length - 1;                 
            for (int i = length; i >= 0; i--)
            {
                if (factorialString[i] == '0')
                    zeroes++;
                else
                    break;
            }
            return zeroes;
        }

        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Zeroes: {0}", GetZeroes(GetFact(n)));
        }
    }
}
