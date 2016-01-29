using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.NumberAsWords
{
    class NumberAsWords
    {
        static string GetUnits(int n)
        {
            int units = n % 10;
            string[] number = new string[] {
                "zero", "one", "two", "three",
                "four", "five", "six", "seven",
                "eight", "nine" };
            return number[units];
        }
        
        static string GetTeens(int n) // Pun intended
        {
            int teens = n % 10;
            string[] number = new string[] {
                null, "eleven", "twelve", "thirteen",
                "fourteen", "fifteen", "sixteen",
                "seventeen", "eighteen", "nineteen" };
            return number[teens];
        }

        static string GetTens(int n)
        {
            int tens = (n / 10) % 10;
            string[] number = new string[] {
                null, "ten", "twenty", "thirty", "forty",
                "fifty", "sixty", "seventy", "eighty",
                "ninety" };
            return number[tens];
        }

        static string GetHundreds(int n)
        {
            int hundreds = (n / 10) / 10;
            string[] number = new string[] {
                null, "one hundred", "two hundred",
                "three hundred", "four hundred",
                "five hundred", "six hundred",
                "seven hundred", "eight hundred",
                "nine hundred" };
            return number[hundreds];
        }
        
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Integer [0,999]: ");
                int n = int.Parse(Console.ReadLine());
                while (n < 0 || n > 999)
                {
                    Console.WriteLine("Integer must be in the range [0, 999].");
                    n = int.Parse(Console.ReadLine());
                }
                
                string hundreds = GetHundreds(n);
                string tens = GetTens(n);
                string teens = GetTeens(n);
                string units = GetUnits(n);
                string result =
                    hundreds // Add the hundreds

                    + ((tens == null && units == "zero") ? null : // Check if n is of type x00
                    (hundreds != null) ? " and " : null) // If false, add "and"

                    + ((tens == "ten" && units != "zero") ? teens : tens) // Check if n is of type x1x

                    + ((tens == "ten") ? null : // Check if n is of type 1x
                    ((hundreds == null && tens == null) ? units : // If false, check if n is of type x
                    (tens != null) ? "-" + units : null)); // If false, add "-"

                // Capitalize and print
                Console.WriteLine( 
                    result.First().ToString().ToUpper() + result.Substring(1));                
            }
        }
    }
}
