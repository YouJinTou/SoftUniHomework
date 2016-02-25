using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleProperties
{
    class CircleProperties
    {
        static void Main(string[] args)
        {
            Console.Write("Radius: ");
            float r = float.Parse(Console.ReadLine());
            float perimeter = (float)(2 * Math.PI * r);
            float area = (float)(Math.Pow(r, 2) * Math.PI);

            Console.WriteLine("Perimeter: {0:0.00}", perimeter);
            Console.WriteLine("Area: {0:0.00}", area);
        }
    }
}
