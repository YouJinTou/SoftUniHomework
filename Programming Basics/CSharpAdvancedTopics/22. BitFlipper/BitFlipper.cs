using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22.BitFlipper
{
    class BitFlipper
    {
        static ulong FlipBits(ulong number)
        {
            string bitString
                = Convert.ToString((long)number, 2).PadLeft(64, '0');
            for (int i = 0; i < bitString.Length - 2;)
            {
                if (bitString[i] == bitString[i + 1]
                    && bitString[i] == bitString[i + 2])
                {
                    number ^= (ulong)1 << 63 - i;
                    number ^= (ulong)1 << 63 - i - 1;
                    number ^= (ulong)1 << 63 - i -  2;
                    i += 3;
                    continue;
                }
                i++;              
            }
            return number;
        }

        static void Main(string[] args)
        {
            ulong number = ulong.Parse(Console.ReadLine());
            Console.WriteLine(FlipBits(number));
        }
    }
}
