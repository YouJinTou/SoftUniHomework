using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.LongestAreaInArray
{
    class LongestAreaInArray
    {
        static string[] FillArray(int n)
        {
            string[] lines = new string[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Element: ");
                lines[i] = Console.ReadLine();
            }
            return lines;
        }

        static Dictionary<string, int> FindBiggestArea(string[] lines)
        {
            Dictionary<string, int> occurrences
                = new Dictionary<string, int>();
            foreach (string line in lines)
            {
                int count = 1;
                bool isMatch // Check if string is present in the dictionary
                    = occurrences.TryGetValue(line, out count);
                if (!isMatch)
                    occurrences.Add(line, 1); // If false, create entry
                else
                    occurrences[line]++; // If it exist, increase the count
            }
            return occurrences;
        }
        
        static void PrintBestSequence(Dictionary<string, int> occurrences)
        {
            int bestCount = occurrences.Max(key => key.Value);
            // Match the best count with the first value it finds
            var bestEntry
                = occurrences.First(key => key.Value == bestCount).Key;

            Console.WriteLine(bestCount);
            for (int i = 0; i < bestCount; i++)
            {
                Console.WriteLine(bestEntry);
            }
        }

        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            PrintBestSequence(FindBiggestArea(FillArray(n)));
        }
    }
}
