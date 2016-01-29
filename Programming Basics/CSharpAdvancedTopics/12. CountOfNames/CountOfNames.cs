using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.CountOfNames
{
    class CountOfNames
    {
        static SortedDictionary<string, int> GetCount(string[] tokens)
        {
            SortedDictionary<string, int> occurrencesCount
               = new SortedDictionary<string, int>();
            foreach (string letter in tokens)
            {
                int count;
                if (!occurrencesCount.TryGetValue(letter, out count))
                {
                    count = 1;
                    occurrencesCount.Add(letter, count);
                }
                else
                    occurrencesCount[letter]++;
            }
            return occurrencesCount;
        }

        static void Main(string[] args)
        {
            Console.Write("Names: ");
            string line = Console.ReadLine();
            string[] tokens = line.Split(' ');

            SortedDictionary<string, int> dict = GetCount(tokens);
            foreach (var entry in dict)
                Console.WriteLine("{0} -> {1}", entry.Key, entry.Value);
        }
    }
}
