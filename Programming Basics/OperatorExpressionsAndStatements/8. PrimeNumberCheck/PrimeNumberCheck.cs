using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.PrimeNumberCheck
{
    class PrimeNumberCheck
    {
        static bool CheckPrime(int n)
        {
            int upperBound = (int)Math.Sqrt(n);
            for (int i = 3; i < upperBound; i += 2)
            {
                if (n % 2 == 0) return false;
                if (n % i == 0) return false; 
                if (n == 0 || n == 1) return false;
                if (n == 2) return true;
            }
            return true;
        }

        static void Main(string[] args)
        {
            Console.Write("Integer to check [0, 100]: ");            
            short integer = short.Parse(Console.ReadLine());
            if (integer < 0 || integer > 100)
            {
                throw new ArgumentOutOfRangeException(
                    "Integer", "Integer out of range.");
            }

            Console.WriteLine("Checking... " + CheckPrime(integer));
        }
    }
}
