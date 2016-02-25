using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.BinaryToDecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            string bin = Console.ReadLine();

            int currentPower = 0;
            int result = 0;
            for (int i = bin.Length - 1; i >= 0; i--)
            {
                if (bin[i] == '1')
                {
                    result += (int)Math.Pow(2, currentPower);
                    currentPower++;
                }
                else
                {
                    currentPower++;
                }
            }
            Console.WriteLine("{0} in decimal is: {1}", bin, result);
        }
    }
}
