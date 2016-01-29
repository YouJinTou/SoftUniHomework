using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWand
{
    class MagicWand
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = 3 * n + 2;

            #region Top
            int dots = width / 2;
            int middleDots = 0;
            for (int i = 0; i <= ((n - 5) / 2) + 5; i++)
            {
                if (i == (((n - 5) / 2) + 5) - 1)
                {
                    Console.Write(new string('*', n)
                        + new string('.', n + 2)
                        + new string('*', n ));
                    break;
                }

                Console.Write(new string('.', dots) +
                    new string('*', 1) + new string('.', middleDots)
                    + new string('*', (middleDots == 0) ? 0 : 1)
                    + new string('.', dots));
                Console.WriteLine();
                dots--;
                if (middleDots == 0)
                    middleDots++;
                else
                    middleDots += 2;                
            }
            #endregion

            Console.WriteLine();
            for (int i = 1; i < n / 2 + 1; i++)
            {
                Console.Write(new string('.', i)
                    + '*' + new string('.', width - 2 * i - 2)
                    + '*' + new string('.', i));
                Console.WriteLine();
            }

            for (int i = n/2 - 1, j = 0; i > 0; i--, j++)
            {
                Console.Write(new string('.', i)
                    + '*' + new string('.', n/2)
                    + "*" + new string('.', j) + '*'
                    + new string('.', n)+ "*"
                    + new string('.', j) + '*'
                    + new string('.', n/2)
                    + '*' + new string('.', i));
                Console.WriteLine();
            }
            
            for (int i = 0; i < 2; i++)
            {
                if (i == 1)
                {
                    Console.Write(new string('*', n / 2 + 1)
                        + new string('.', n / 2) + '*'
                        + new string('.', n) + '*'
                        + new string('.', n / 2) +
                        new string('*', n / 2 + 1));
                    break;
                }
                Console.Write('*'
                    + new string('.', n / 2)
                    + '*' + new string('.', n / 2 - 1)
                    + '*' + new string('.', n)
                    + '*' + new string('.', n / 2 - 1)
                    + '*' + new string('.', n / 2) + '*');
                Console.WriteLine();
            }

            Console.WriteLine();
            for (int i = 0; i < n + 1; i++)
            {
                if (i == n)
                {
                    Console.Write(new string('.', n)
                       + new string('*', n + 2)
                       + new string('.', n));
                    break;
                }
                Console.Write(
                    new string('.', n)
                    + '*' + new string('.', n)
                    + '*' + new string('.', n));
                Console.WriteLine();
            }
        }
    }
}
