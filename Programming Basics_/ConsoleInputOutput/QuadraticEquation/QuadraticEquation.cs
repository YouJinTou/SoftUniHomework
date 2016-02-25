using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation
{
    class QuadraticEquation
    {
        static double CalculatePositiveDiscriminant(double a,
            double b, double c)
        {
            double positiveDiscriminant =
                (-b + Math.Sqrt(Math.Pow(b, 2) - 4 * a * c))
                / (2 * a);
            return positiveDiscriminant;
        }

        static double CalculateNegativeDiscriminant(double a,
            double b, double c)
        {
            double negativeDiscriminant =
                (-b - Math.Sqrt(Math.Pow(b, 2) - 4 * a * c))
                / (2 * a);
            return negativeDiscriminant;
        }

        static void Main(string[] args)
        {
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c = ");
            double c = double.Parse(Console.ReadLine());

            double root1 = CalculatePositiveDiscriminant(a, b, c);
            double root2 = CalculateNegativeDiscriminant(a, b, c);
            
            Console.WriteLine("Root 1: {0}", root1);
            Console.WriteLine("Root 2: {0}", root2);
        }
    }
}
