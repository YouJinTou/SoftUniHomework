using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.RemoveNames
{
    class RemoveNames
    {
        static void Main(string[] args)
        {
            Console.Write("First list: ");
            string firstNamesList = Console.ReadLine();            
            Console.Write("Second list: ");
            string secondNamesList = Console.ReadLine();

            string[] firstTokens = firstNamesList.Split(' ');
            string[] secondTokens = secondNamesList.Split(' ');

            HashSet<string> firstNames = new HashSet<string>();
            foreach (string token in firstTokens)
                firstNames.Add(token);

            HashSet<string> secondNames = new HashSet<string>();
            foreach (string token in secondTokens)
                secondNames.Add(token);

            firstNames.ExceptWith(secondNames);
            foreach (string name in firstNames)
                Console.Write(name + " ");
            Console.WriteLine();
        }
    }
}
