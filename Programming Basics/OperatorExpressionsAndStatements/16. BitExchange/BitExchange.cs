using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.BitExchange
{
    class BitExchange
    {
        static int GetBitValue(uint n, int index)
        {
            int bit = (int)(n >> index) & 1;
            return bit;
        }

        static uint ExchangeBitValues(uint n,
            int pBit, int pIndex, int qBit, int qIndex)
        {
            uint modified = n;
            int swap = pBit;
            pBit = qBit;
            qBit = swap;
            modified ^= (uint)((-pBit ^ modified) & (1 << pIndex));
            modified ^= (uint)((-qBit ^ modified) & (1 << qIndex));
            return modified;
        }

        static bool CheckBounds(uint n, int p,
            int q, int k)
        {
            string binaryString = Convert.ToString(n, 2);
            if (p + k >= q
                || p + k > binaryString.Length
                || q + k > binaryString.Length
                || p + k < 0 || q + k < 0) 
            {
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            Console.Write("n = ");
            uint n = uint.Parse(Console.ReadLine());
            Console.Write("p = ");
            int p = int.Parse(Console.ReadLine());
            Console.Write("q = ");
            int q = int.Parse(Console.ReadLine());
            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());

            if (!CheckBounds(n, p, q, k))
            {
                uint modified = n;
                Console.WriteLine("\nBefore: " + Convert.ToString(n, 2).PadLeft(8, '0'));
                for (int i = p, j = q; i < p + k; i++, j++)
                {
                    int pBit = GetBitValue(modified, i);
                    int qBit = GetBitValue(modified, j);
                    modified = ExchangeBitValues(modified, pBit, i, qBit, j);
                }
                Console.WriteLine("\nAfter:  " + Convert.ToString(modified, 2).PadLeft(8, '0'));
                Console.WriteLine("In decimal: {0}", Convert.ToString(modified));
            }
            else
            {
                Console.WriteLine("There is overlap. Terminating...");
            }            
        }
    }
}
