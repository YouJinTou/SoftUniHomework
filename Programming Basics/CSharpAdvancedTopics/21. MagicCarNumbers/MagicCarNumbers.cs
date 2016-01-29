using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21.MagicCarNumbers
{
    class MagicCarNumbers
    {
        static List<int> GetLettersSum()
        {
            int[] letters = new int[]
            {
                10, 20, 30, 50, 80, 110, 130, 160, 200, 240
            };
            List<int> lettersSum = new List<int>();
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    lettersSum.Add(
                        30 + 10 + letters[i] + letters[j]);
            return lettersSum;
        }

        static List<int> GetDigitsSum()
        {
            List<int> digitsSum = new List<int>();
            for (int i = 1; i <= 3; i++)
            {
                switch (i)
                {
                    case 1: // aaaa
                        for (int a = 0; a < 10; a++)
                            digitsSum.Add(4 * a);
                        break;
                    case 2: // abbb and aaab
                        for (int q = 1; q <= 2; q++)
                            for (int a = 0; a < 10; a++)
                                for (int b = 0; b < 10; b++)
                                    if (a != b) // We get repeats from the other cases otherwise
                                        digitsSum.Add(a + (3 * b));
                        break;
                    case 3: // aabb, abab and abba
                        for (int j = 1; j <= 3; j++)
                            for (int a = 0; a < 10; a++)
                                for (int b = 0; b < 10; b++)
                                    if (a != b)
                                        digitsSum.Add(2 * a + 2 * b);
                        break;
                }
            }
            return digitsSum;
        }

        static int GetCarTally(List<int> lettersSum,
            List<int> digitsSum, int magicWeight)
        {
            int count = 0;
            for (int i = 0; i < lettersSum.Count; i++)
                for (int j = 0; j < digitsSum.Count; j++)
                    if (lettersSum[i] + digitsSum[j] == magicWeight)
                        count++;
            return count;
        }

        static void Main(string[] args)
        {
            int magicWeight = int.Parse(Console.ReadLine());
            Console.WriteLine(GetCarTally(GetLettersSum(), GetDigitsSum(), magicWeight));
        }
    }
}
