using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Calculate_N_K
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            int result = 0;
            int factorialN = 0;
            int factorialK = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i == 1)
                {
                    factorialN = 1;
                    factorialK = 1;
                }
                else
                {
                    if (i <= k)
                    {
                        factorialN *= i;
                        factorialK *= i;
                    }
                    else
                        factorialN *= i;
                }                
            }
            result = factorialN / factorialK;

            Console.WriteLine("N!/K! = " + result);
        }
    }
}
