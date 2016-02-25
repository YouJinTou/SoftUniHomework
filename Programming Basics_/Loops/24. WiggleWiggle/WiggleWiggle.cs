using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24.WiggleWiggle
{
    class WiggleWiggle
    {
        static long[] numbers;
        static string[] binaries;

        static void ParseNumbers(string line)
        {
            string[] tokens = line.Split(' ');
            numbers = new long[tokens.Length];
            for (int i = 0; i < tokens.Length; i++)
            {
                numbers[i] = long.Parse(tokens[i]);
            }
        }

        static void ToggleBits()
        {
            for (int i = 0; i < numbers.Length; i += 2)
            {
                for (int j = 0; j <= 63; j += 2)
                {
                    long bit1 = (numbers[i] >> j) & 1;
                    long bit2 = (numbers[i + 1] >> j) & 1;
                    if (bit1 != bit2)
                    {
                        numbers[i] ^= ((long)1 << j);
                        numbers[i + 1] ^= ((long)1 << j);
                    }
                }                
            }
        }

        static void ReverseBits()
        {
            binaries = new string[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = ~numbers[i];
                numbers[i] = numbers[i] & ~((long)1 << 63); // Get rid of the sign
                string binString = Convert.ToString(numbers[i], 2).PadLeft(63, '0'); // This little fucker here
                binaries[i] = binString;
            }
        }

        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            ParseNumbers(line);
            ToggleBits();
            ReverseBits();
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine("{0} {1}", numbers[i], binaries[i]);
            }        
        }
    }
}
