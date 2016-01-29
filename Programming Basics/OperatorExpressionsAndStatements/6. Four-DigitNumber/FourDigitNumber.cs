using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.FourDigitNumber
{
    class Program
    {
        static int SumDigits(int n)
        {
            int sum = 0;
            foreach (char ch in n.ToString())
            {
                int digit =
                    (int)char.GetNumericValue(ch);
                sum += digit;
            }
            return sum;
        }

        static void ReverseNumber(int n)
        {
            char[] digitArray =
                n.ToString().ToCharArray();

            Array.Reverse(digitArray);
            Console.Write("Reversed number: ");          
            foreach (char digit in digitArray)
            {
                Console.Write(digit);
            }
            Console.WriteLine();
        }

        static void SwapDigits(int n,
            int digit1, int digit2)
        {
            string numberString = n.ToString();
            char[] number =
                new char[n.ToString().Length];
            for (int j = 0; j < number.Length; j++)
            {
                number[j] = numberString[j];
            }
            char swap = number[digit1 - 1];
            number[digit1 - 1] = number[digit2 - 1];
            number[digit2 - 1] = swap;
                        
            foreach (char digit in number)
            {
                Console.Write(digit);
            }
            Console.WriteLine("");
        }

        static int EnqueueLastDigit(int n)
        {
            string numberString = n.ToString();
            StringBuilder builder = new StringBuilder();

            builder.Append(numberString[numberString.Length - 1]);
            int count = 0;
            foreach (char digit in numberString)
            {
                if (count == numberString.Length - 1)
                    break;
                builder.Append(digit);
                count++;
            }

            int result = int.Parse(builder.ToString());
            return result;
        }

            static void Main(string[] args)
        {
            Console.Write("Integer: ");
            int n = int.Parse(Console.ReadLine());

            int sum = SumDigits(n);
            Console.WriteLine("Calculating sum... " + sum);
            ReverseNumber(n);
            Console.WriteLine("Putting last digit in front... {0}",
                EnqueueLastDigit(n));
            Console.Write("Swapping digits 2 and 3... ");
            SwapDigits(n, 2, 3);
        }
    }
}
