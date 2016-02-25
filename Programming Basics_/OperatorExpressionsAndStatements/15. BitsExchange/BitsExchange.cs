using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.BitsExchange
{
    class BitsExchange
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
        
        static void Main(string[] args)
        {
            Console.Write("n = ");
            uint n = uint.Parse(Console.ReadLine());
            uint modified = n;

            Console.WriteLine("\nBefore: " + Convert.ToString(n, 2).PadLeft(8, '0'));
            for (int i = 3, j = 24; i < 6; i++, j++)
            {
                int pBit = GetBitValue(modified, i);
                int qBit = GetBitValue(modified, j);
                modified = ExchangeBitValues(modified, pBit, i, qBit, j);
            }           
            Console.WriteLine("\nAfter:  " + Convert.ToString(modified, 2).PadLeft(8, '0'));

        }
    }
}
