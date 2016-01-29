using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum5Numbers
{
    class Sum5Numbers
    {
        static void Main(string[] args)
        {
            Console.Write("Numbers: ");
            string numbers = Console.ReadLine();
            string[] tokens = numbers.Split(' ');

            double result = 0;
            foreach (string token in tokens)
            {
                result += double.Parse(token);
            }
            Console.WriteLine(result);
        }
    }
}
