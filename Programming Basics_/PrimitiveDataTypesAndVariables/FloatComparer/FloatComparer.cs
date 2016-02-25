using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloatComparer
{
    class FloatComparer
    {
        private const double EPS = 0.000001d;

        static void Main(string[] args)
        {
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());
            double difference = Math.Abs(a - b);

            if (difference < EPS)
            {
                Console.WriteLine("The numbers are equal.");
            }
            else
            {
                Console.WriteLine("The numbers are NOT equal.");
            }
        }
    }
}
