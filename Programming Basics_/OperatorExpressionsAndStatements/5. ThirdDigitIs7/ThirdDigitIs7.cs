using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.ThirdDigitIs7
{
    class ThirdDigitIs7
    {
        static void Main(string[] args)
        {
            Console.Write("Integer to check: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(
                ((((n / 10) / 10) % 10) == 7) ? true : false);
        }
    }
}
