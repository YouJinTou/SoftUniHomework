using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.ModifyBitAtGivenPosition
{
    class ModifyBitAtGivenPosition
    {
        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("v = ");
            int v = int.Parse(Console.ReadLine());
            Console.Write("Index: ");
            int p = int.Parse(Console.ReadLine());

            Console.WriteLine("\nBefore: " + Convert.ToString(n, 2).PadLeft(8, '0'));
            if (v == 0)         // Clearing a bit
            {                   // If n = 5 and p = 2, 00000101 & ~(00000001 << 2)
                n &= ~(1 << p); // ==> 00000101 & ~(00000100) ==> 00000101 & 11111011
            }                   // ==> 00000001, 1 in decimal
            else                // Setting a bit
            {                   // If n = 0 and p = 9, 00000000 | 000000001 << 9
                n |= 1 << p;    // ==> 00000000 | 1000000000 ==> 1000000000, 512 in decimal
            }
            Console.WriteLine("After:  " + Convert.ToString(n, 2).PadLeft(8, '0'));
        }
    }
}
