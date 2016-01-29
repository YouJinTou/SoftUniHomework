using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Rectangles
{
    class Rectangles
    {
        static void Main(string[] args)
        {
            Console.Write("Width: ");
            double w = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            double h = double.Parse(Console.ReadLine());

            double circumference = w * 2 + h * 2;
            double area = w * h;

            Console.WriteLine("Perimeter: {0}", circumference);
            Console.WriteLine("Area: {0}", area);
        }
    }
}
