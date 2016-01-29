using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciNumbers
{
    class FibonacciNumbers
    {
        static ulong[] intergalacticalStorageDevice;

        static ulong GetFibonacci(int n)
        {
            if (intergalacticalStorageDevice[n] == 0)
            {
                intergalacticalStorageDevice[n] =
                    GetFibonacci(n - 1) + GetFibonacci(n - 2);
            }
            return intergalacticalStorageDevice[n];
        }

        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            intergalacticalStorageDevice = new ulong[n + 2]; // Or we go out of bounds
            intergalacticalStorageDevice[1] = 1; // Memoization to avoid visiting duplicates in the tree   
            intergalacticalStorageDevice[2] = 1;
            GetFibonacci(n);
                       
            for (int i = 0; i < n; i++)
            {
                if (i == n - 1)
                {
                    Console.WriteLine(intergalacticalStorageDevice[i]);
                    break;
                }
                Console.Write(intergalacticalStorageDevice[i] + ", ");               
            }            
        }
    }
}
