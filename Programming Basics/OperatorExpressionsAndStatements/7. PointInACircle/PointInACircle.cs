using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.PointInACircle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("X coordinate: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Y coordinate: ");
            double y = double.Parse(Console.ReadLine());

            Console.WriteLine(
                ((Math.Pow(x, 2) + Math.Pow(y, 2) <=
                Math.Pow(2, 2))) ? true : false);
        }
    }
}
