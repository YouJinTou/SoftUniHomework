using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateHypotenuse
{
    class Program
    {
        static double ComputeHypotenuse(double cathetusA, double cathetusB)
        {
            double hypotenuse = Math.Sqrt((Math.Pow(cathetusA, 2)
                + Math.Pow(cathetusB, 2)));
            return hypotenuse;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("First triangle's hypotenuse: {0}",
                ComputeHypotenuse(3, 4));
            Console.WriteLine("Second triangle's hypotenuse: {0}",
                ComputeHypotenuse(10, 12));
            Console.WriteLine("Third triangle's hypotenuse: {0}",
                ComputeHypotenuse(100, 250));
        }
    }
}
