using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Calculate
{
    class Calculate1NK
    {
        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("x = ");
            int x = int.Parse(Console.ReadLine());

            double sum = 1;
            int factorial = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i == 1)
                    factorial = 1;
                else
                    factorial *= i;
                sum +=  factorial/ Math.Pow(x, i);
            }

            Console.WriteLine("Sum = {0:0.00000}", sum);
        }
    }
}
