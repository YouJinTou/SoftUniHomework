using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumNNumbers
{
    class SumNNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            double[] numbers = new double[n];
            for (int i = 0; i < n; i++)
            {
                double k = double.Parse(Console.ReadLine());
                numbers[i] = k;
            }
            Console.WriteLine("The sum of all nubmers is {0}.", numbers.Sum());
        }
    }
}
