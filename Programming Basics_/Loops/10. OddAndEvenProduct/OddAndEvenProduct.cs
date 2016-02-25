using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.OddAndEvenProduct
{
    class OddAndEvenProduct
    {
        static void Main(string[] args)
        {
            Console.Write("Integers separated by an interval: ");
            string integers = Console.ReadLine();
            string[] numbers = integers.Split(' ');
            int oddProduct = 1;
            int evenProduct = 1;

            for (int i = 1, j = 0; i <= numbers.Length; i++, j++)
            {
                if (i % 2 != 0)
                    oddProduct *= int.Parse(numbers[j]);
                else
                    evenProduct *= int.Parse(numbers[j]);
            }

            if (oddProduct == evenProduct)
                Console.WriteLine("Yes. \nProduct: " + oddProduct);
            else
                Console.WriteLine(
                    "No. \nOdd product: {0} \nEven product: {1}",
                    oddProduct, evenProduct);
        }
    }
}
