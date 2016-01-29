using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.RandomNumbersInRange
{
    class RandomNumbersInRange
    {
        static void Main(string[] args)
        {
            Console.Write("Number of integers: ");
            int n = int.Parse(Console.ReadLine());
            int min = int.MaxValue;
            int max = int.MinValue;
            for (int i = 1; i <= n; i++)
            {
                Console.Write("Element {0}: ", i);
                int k = int.Parse(Console.ReadLine());
                if (k < min)
                    min = k;
                if (k > max)
                    max = k;
            }

            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                Console.Write(rand.Next(min, max + 1) + " ");
            }
        }
    }
}
