using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22.SummerTime
{
    class SummerTime
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(new string(' ', n / 2)
                + new string('*', n + 1)
                + new string(' ', n / 2));            
            for (int i = 0; i < n/2 + 1; i++)
            {
                Console.Write("{0}*{1}*{0}",
                    new string(' ', n / 2),
                    new string(' ', n - 1));
                Console.WriteLine();
            }
            for (int j = n / 2 - 1, q = n + 1; j > 0; j--, q += 2)
            {
                Console.Write("{0}*{1}*{0}", new string(' ', j),
                    new string(' ', q));
                Console.WriteLine();
            }
            for (int i = 0; i < 2 * n; i++)
            {
                if (i < n)
                {
                    Console.Write("*{0}*", new string('.', 2 * n - 2));
                    Console.WriteLine();
                }                 
                else
                {
                    Console.Write("*{0}*", new string('@', 2 * n - 2));
                    Console.WriteLine();
                }
            }
            Console.WriteLine(new string('*', 2 * n));               
        }
    }
}
