using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.CountOfLetters
{
    class CountOfLetters
    {
        static SortedDictionary<char, int> GetCount(string line)
        {
            SortedDictionary<char, int> occurrencesCount
                = new SortedDictionary<char, int>();
            foreach (char letter in line)
            {
                if (letter == ' ')
                    continue;
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
            Console.Write("Letters: ");
            string line = Console.ReadLine();

            SortedDictionary<char, int> dict = GetCount(line);
            foreach (var entry in dict)
                Console.WriteLine("{0} -> {1}", entry.Key, entry.Value);
        }
    }
}