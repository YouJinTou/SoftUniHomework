using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _3.CheckPlayCard
{
    class CheckPlayCard
    {
        static void Main(string[] args)
        {
            Console.Write("Card: ");
            string card = Console.ReadLine();
            string pattern = "[2-9]|[1][0]|[A]|[K]|[Q]|[J]";
            if (Regex.IsMatch(card, pattern))
                Console.WriteLine("Yes.");
            else
                Console.WriteLine("No.");            
        }
    }
}
