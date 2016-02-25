using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisibleNumbersInInterval
{
    class DivisibleNumbersInInterval
    {
        static void Main(string[] args)
        {
            Console.Write("Start: ");
            int start = int.Parse(Console.ReadLine());
            Console.Write("End: ");
            int end = int.Parse(Console.ReadLine());

            int count = 0;
            for (int i = start; i <= end; i++)
            {
                if (i % 5 == 0)
                {
                    count++;
                }
            }
            Console.WriteLine("Numbers in range divisible by 5: {0}", count);
        }
    }
}
