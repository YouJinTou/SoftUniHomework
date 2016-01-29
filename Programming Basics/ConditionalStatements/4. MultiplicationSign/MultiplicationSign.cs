using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.MultiplicationSign
{
    class MultiplicationSign
    {
        static void Main(string[] args)
        {
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c = ");
            double c = double.Parse(Console.ReadLine());

            if (a < 0 || b < 0 || c < 0)
                Console.WriteLine("-");
            else if (a == 0 || b == 0 | c == 0)
                Console.WriteLine(0);
            else
                Console.WriteLine("+");
        }
    }
}
