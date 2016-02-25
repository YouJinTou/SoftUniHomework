using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.RandomizeNumbers1N
{
    class RandomizeNumbers1N
    {
        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            List<int> numbers = new List<int>(); // Initialize a list with numbers 1 thru n
            for (int i = 1; i <= n; i++)
            {
                numbers.Add(i);
            }

            Random rand = new Random();
            for (int i = 1; i <= 1000; i++)
            {
                if (numbers.Count == 0)
                    break;

                int chance = rand.Next(0, n);
                Console.Write(numbers[chance] + " ");
                numbers.RemoveAt(chance);
                n--;
            }
        }
    }
}
