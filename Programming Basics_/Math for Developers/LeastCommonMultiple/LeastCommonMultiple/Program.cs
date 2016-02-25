using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeastCommonMultiple
{
    class Program
    {
        static int FindLeastCommonMultiple(int a, int b)
        {
            int LCM = 0;
            int max = Math.Max(a, b);
            int min = Math.Min(a, b);

            for (int i = 1; i <= max; i++)
            {
                if ((min * i) % max == 0)
                {
                    LCM = min * i;
                    return LCM;
                }
            }
            return max;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("The LCM of (12, 18) is {0}.", FindLeastCommonMultiple(1234, 3456));
        }
    }
}
