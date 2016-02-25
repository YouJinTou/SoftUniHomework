using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ExtractBit3
{
    class ExtractBit3
    {
        static void Main(string[] args)
        {
            Console.Write("n = ");
            uint n = uint.Parse(Console.ReadLine());
            Console.WriteLine("Before: " + Convert.ToString(n, 2).PadLeft(8, '0'));
            n >>= 3;
            Console.WriteLine("After: " + Convert.ToString(n, 2).PadLeft(8, '0'));
            Console.WriteLine("The third bit is {0}.",
                ((n & 1) == 1) ? 1 : 0);
        }
    }
}
