using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Sunlight
{
    class Sunlight
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int length = n * 3 / 2;

            Console.WriteLine(new string('.', length)
                   + '*' + new string('.', length));
            for (int i = 0, j = 1, dots = length - 2;
                i < n - 1 ; i++, j++, dots--)
            {
                Console.Write("{0}*{1}*{1}*{0}", new string('.', j),
                    new string('.', dots));
                Console.WriteLine();
            }
            for (int i = 0; i < n; i++)
            {
                if (i != n / 2)
                {
                    Console.Write("{0}{1}{0}", new string('.', n),
                    new string('*', n));
                    Console.WriteLine();
                }
                if (i == n / 2)
                    Console.WriteLine(new string('*', 3 * n));
            }
            for (int i = n, j = n - 1, dots = n / 2;
                i > 1; i--, j--, dots++)
            {
                Console.Write("{0}*{1}*{1}*{0}", new string('.', j),
                    new string('.', dots));
                Console.WriteLine();
            }
            Console.WriteLine(new string('.', length)
                   + '*' + new string('.', length));
        }
    }
}
