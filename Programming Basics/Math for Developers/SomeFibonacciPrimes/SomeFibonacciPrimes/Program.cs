using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeFibonacciPrimes
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

        static int FindSpecificPrime(int userInput, bool[] primes)
        {
            int countPrimes = 0;
            int prime = 0;
            for (int i = 0; i < primes.Length; i++)
            {
                if (primes[i] == false)
                {
                    countPrimes++;
                    if (countPrimes == userInput)
                    {
                        Console.WriteLine(
                            "Prime #{0} is: {1}", userInput, i);
                        prime = i;
                    }
                }
            }
            return prime;
        }

        static bool CheckIfPrimeExistsInFibSequence(int targetPrime)
        {
            bool isPart = false;
            int a = 0;
            int b = 1;
            int count = 0;
            while (a <= targetPrime)
            {
                if (a > targetPrime)
                {
                    return isPart;
                }
                if (a == targetPrime)
                {
                    Console.WriteLine(
                        "{0} found at position {1} in the Fibonacci sequence.",
                        targetPrime, count);
                    isPart = true;
                    return isPart;
                }
                int temp = a;
                a = b;
                b = temp + b;
                count++;
            }
            return isPart;
        }
        
        static void Main(string[] args)
        {            
            Console.WriteLine("Prime exists in sequence. True or false? {0}\n",
                CheckIfPrimeExistsInFibSequence(FindSpecificPrime(24, FindPrimes(24))).
                ToString().ToUpper());
            Console.WriteLine("Prime exists in sequence. True or false? {0}\n",
                CheckIfPrimeExistsInFibSequence(FindSpecificPrime(101, FindPrimes(101))).
                ToString().ToUpper());
            Console.WriteLine("Prime exists in sequence. True or false? {0}\n",
                CheckIfPrimeExistsInFibSequence(FindSpecificPrime(251, FindPrimes(251))).
                ToString().ToUpper());

        }
    }
}
