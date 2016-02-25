using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _14.PetarsGame
{
    class PetarsGame
    {
        static ulong GetSum(ulong start, ulong end)
        {
            ulong sum = 0;
            for (ulong i = start; i < end; i++)
            {
                if (i % 5 == 0)
                    sum += i;
                else
                    sum += i % 5;
            }            
            return sum;
        }

        static string ReplaceDigits(ulong sum, string replace)
        {
            string result = null;
            string pattern;
            if (sum % 2 == 0)
            {
                pattern = sum.ToString().First().ToString();
                result = 
                    Regex.Replace(sum.ToString(), pattern, replace);
            }
            else
            {
                pattern = sum.ToString().Last().ToString();
                result =
                   Regex.Replace(sum.ToString(), pattern, replace);
            }
            return result;
        }

        static void Main(string[] args)
        {
            ulong start = ulong.Parse(Console.ReadLine());
            ulong end = ulong.Parse(Console.ReadLine());
            string replacement = Console.ReadLine();

            Console.WriteLine(
                ReplaceDigits(GetSum(start, end), replacement));
        }
    }
}
