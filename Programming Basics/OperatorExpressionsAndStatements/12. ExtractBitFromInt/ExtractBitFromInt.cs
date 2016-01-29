using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.ExtractBitFromInt
{
    class ExtractBitFromInt
    {
        static void Main(string[] args)
        {
            Console.Write("n = ");
            uint n = uint.Parse(Console.ReadLine());
            Console.Write("Index: ");
            ushort p = ushort.Parse(Console.ReadLine());

            n >>= p;
            Console.WriteLine("The bit at index {0} is {1}.", p,
                ((n & 1) == 1) ? 1 : 0);
        }
    }
}
