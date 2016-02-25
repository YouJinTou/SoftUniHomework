using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintNumberSequence
{
    class PrintNumberSequence
    {
        static void Main(string[] args)
        {
            for (int i = 2; i <= 12; i++)
            {
                if (i % 2 == 0)
                {
                    if (i == 12)
                    {
                        Console.WriteLine("{0}", i);
                        break;
                    }
                    Console.Write("{0}, ", i);
                }
                else
                {                  
                    Console.Write("{0}, ", -i);                                   
                }
            }
        }
    }
}
