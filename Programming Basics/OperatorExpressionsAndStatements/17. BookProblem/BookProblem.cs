using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.BookProblem
{
    class BookProblem
    {
        static void Main(string[] args)
        {
            int totalPages = int.Parse(Console.ReadLine());
            int campingDays = int.Parse(Console.ReadLine());
            int pagesReadDaily = int.Parse(Console.ReadLine());

            int readingDays = 30 - campingDays;
            int pagesPerMonth = readingDays * pagesReadDaily;
            double monthsNeeded = (double)totalPages / pagesPerMonth;
            double months = Math.Ceiling(monthsNeeded % 12);
            int years = (int)monthsNeeded / 12;              
            
            if (months > 0)
            {
                Console.WriteLine("{0} years {1} months", years, months);
            }
            else
            {
                Console.WriteLine("never");
            }
        }
    }
}
