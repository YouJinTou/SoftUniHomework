using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.KingOfThieves
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char gem = char.Parse(Console.ReadLine());
            int mid = n / 2 + 1;
            int dashCount = n / 2;
            int gemCount = 1;

            for (int i = 0, j = 0; i < mid; i++, j += 2)
            {
                Console.Write("{0}{1}{0}",
                    new string('-', dashCount - i),
                    new string(gem, gemCount + j));
                Console.WriteLine();
            }
            for (int i = 0, j = 0; i < mid - 1; i++, j += 2)
            {
                Console.Write("{0}{1}{0}",
                    new string('-', 1 + i),
                    new string(gem, n - 2 - j));
                Console.WriteLine();
            }
        }
    }
}
