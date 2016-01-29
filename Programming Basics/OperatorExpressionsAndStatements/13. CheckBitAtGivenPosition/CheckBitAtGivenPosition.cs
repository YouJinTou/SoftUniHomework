using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.CheckBitAtGivenPosition
{
    class CheckBitAtGivenPosition
    {
        static void Main(string[] args)
        {
            Console.Write("n = ");
            uint n = uint.Parse(Console.ReadLine());
            Console.Write("Index: ");
            ushort p = ushort.Parse(Console.ReadLine());

            n >>= p;
            Console.WriteLine(((n & 1) == 1) ? true : false);
        }
    }
}
