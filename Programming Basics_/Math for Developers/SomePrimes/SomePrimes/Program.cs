using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomePrimes
{
    class Program
    {        
        static bool[] FindPrimes(int upperBound)
        {
            // Initialize an array with n elements,
            // where n is obtained using the Prime Number Theorem
            int n = (int)(upperBound * Math.Log(upperBound)) + upperBound;
            bool[] sieve = new bool[n];
            for (int i = 2; i < n; i++)
            {
                if (sieve[i] == false)
                {                                    
                    for (int p = (int)Math.Pow(i, 2); p < n; p += i)
                    {
                        sieve[p] = true;
                    }
                }
            }
            sieve[0] = true;
            sieve[1] = true;
            return sieve; // All that are 'false' are primes
        }

        static void FindSpecificPrime(int userInput, bool[] primes)
        {
            int countPrimes = 0;
            for (int i = 0; i < primes.Length; i++)
            {
                if (primes[i] == false)
                {
                    countPrimes++;
                    if (countPrimes == userInput)
                    {
                        Console.WriteLine(
                            "Prime #{0} is: {1}", userInput, i);
                    }
                }
            }            
        }

        static void Main(string[] args)
        {
            FindSpecificPrime(24, FindPrimes(24));
            FindSpecificPrime(101, FindPrimes(101));
            FindSpecificPrime(251, FindPrimes(251));
        }
    }
}
