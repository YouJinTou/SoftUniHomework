using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.JoinLists
{
    class JoinLists
    {
        static void Main(string[] args)
        {
            Console.Write("First list: ");
            string firstNumberList = Console.ReadLine();
            Console.Write("Second list: ");
            string secondNumberList = Console.ReadLine();

            string[] firstTokens = firstNumberList.Split(' ');
            string[] secondTokens = secondNumberList.Split(' ');

            SortedSet<int> firstNumbers = new SortedSet<int>();
            foreach (string number in firstTokens)
                firstNumbers.Add(int.Parse(number));

            SortedSet<int> secondNumbers = new SortedSet<int>();
            foreach (string number in secondTokens)
                secondNumbers.Add(int.Parse(number));

            firstNumbers.UnionWith(secondNumbers);
            foreach (int number in firstNumbers)
                Console.Write(number + " ");
            Console.WriteLine();
        }
    }
}
