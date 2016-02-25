using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.MinMaxSumAverage
{
    class MinMaxSumAverage
    {
        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Element = ");
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("\nMin: " + numbers.Min());
            Console.WriteLine("Max: " + numbers.Max());
            Console.WriteLine("Sum: " + numbers.Sum());
            Console.WriteLine("Average: {0:0.00}", numbers.Average());
        }
    }
}
