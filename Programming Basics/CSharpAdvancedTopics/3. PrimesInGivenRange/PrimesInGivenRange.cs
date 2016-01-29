using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.PrimesInGivenRange
{
    class PrimesInGivenRange
    {
        static List<int> FindPrimesInRange(int start, int end)
        {
            if (start % 2 == 0)
                start += 1;

            List<int> primes = new List<int>();
            if (start <= 2)
            {
                start = 3;
                primes.Add(2);
                primes.Add(3);
            }                
                        
            for (int i = start; i <= end; i += 2)
            {
                for (int j = 3; j < i; j += 2)
                {
                    if (i % j == 0)
                        break;
                    if (j == i - 2)
                        primes.Add(i);
                }
            }
            return primes;
        }

        static void PrintPrimes(List<int> primes)
        {
            for (int i = 0; i < primes.Count; i++)
            {
                if (i != primes.Count - 1)
                    Console.Write(primes[i] + ", ");
                else
                    Console.Write(primes[i]);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.Write("Start: ");
            int start = int.Parse(Console.ReadLine());
            Console.Write("End: ");
            int end = int.Parse(Console.ReadLine());

            PrintPrimes(FindPrimesInRange(start, end));
        }
    }
}
