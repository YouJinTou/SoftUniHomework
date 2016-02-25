using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReformatCode
{
    class ReadableCode
    {
        static void Main()
        {
            Console.WriteLine("Hi, I am finely formatted program.");
            Console.WriteLine("\nNumbers and squares:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i + " --> " + i * i);
            }
        }
    }
}
