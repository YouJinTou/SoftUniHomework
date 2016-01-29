using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.ZeroSubset
{
    class ZeroSubset
    {
        static int FindSubsets(int[] set, int sum)
        {
            int currentSum = 0;
            int count = 0;
            int bound = (int)Math.Pow(2, set.Length);
            for (int i = 1; i < bound; i++)
            {
                currentSum = 0;
                List<int> list = new List<int>();
                for (int j = 0; j < set.Length; j++)
                {
                    int bit = (i >> j) & 1; // Check the value of bit j
                    if (bit == 1)
                    {
                        currentSum += set[j];
                        list.Add(set[j]);                        
                    }
                }
                if (currentSum == sum)
                {
                    count++;
                    foreach (int num in list)
                        Console.Write(num + " ");
                    Console.WriteLine();
                }
            }
            return count;
        }

        static void Main(string[] args)
        {
            Console.Write("Size of set: ");
            int size = int.Parse(Console.ReadLine());
            int[] set = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.Write("Element: ");
                set[i] = int.Parse(Console.ReadLine());
            }
            Console.Write("\nWhat sum are we looking for? ");
            int sum = int.Parse(Console.ReadLine());

            Console.WriteLine("Total count: " + FindSubsets(set, sum));
        }
    }
}
