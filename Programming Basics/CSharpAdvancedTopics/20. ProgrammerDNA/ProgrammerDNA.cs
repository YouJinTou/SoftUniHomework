using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20.ProgrammerDNA
{
    class ProgrammerDNA
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char gene = char.Parse(Console.ReadLine());

            int dotsUp = 3;
            int dotsDown = 0;
            int genesUp = 1;
            int genesDown = 7;
            for (int i = 1; i <= n; i++)
            {
                if (dotsUp > 0)
                {
                    Console.Write("{0}", new string('.', dotsUp));
                    for (int j = 0; j < 7 - dotsUp * 2; j++)
                    {
                        Console.Write(gene);
                        if (gene == 'G')
                            gene = 'A';
                        else
                            gene++;
                    }
                    Console.Write("{0}", new string('.', dotsUp));
                    Console.WriteLine();
                    dotsUp--;
                    genesUp += 2;
                }
                else
                {
                    Console.Write("{0}", new string('.', dotsDown));
                    for (int j = 0; j < 7 - dotsDown * 2; j++)
                    {
                        Console.Write(gene);
                        if (gene == 'G')
                            gene = 'A';
                        else
                            gene++;
                    }
                    Console.Write("{0}", new string('.', dotsDown));
                    Console.WriteLine();
                    dotsDown++;
                    genesDown -= 2;
                }

                if (i % 7 == 0)
                {
                    dotsUp = 3;
                    dotsDown = 0;
                    genesUp = 1;
                    genesDown = 7;
                }
            }
        }
    }
}
