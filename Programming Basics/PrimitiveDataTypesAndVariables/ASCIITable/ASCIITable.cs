using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIITable
{
    class ASCIITable
    {
        static void Main(string[] args)
        {            
            for (int i = 33; i <= 255; i++)
            {
                char c = (char)i;
                Console.WriteLine(c);
            }           
        }
    }
}
