using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _4.DifferenceBetweenDates
{
    class DifferenceBetweenDates
    {
        static void Main(string[] args)
        {
            Console.Write("Date 1 (dd.MM.yyyy): ");
            string firstDate = Console.ReadLine();
            string format = "d.MM.yyyy";
            DateTime date1 = DateTime.ParseExact(
                firstDate, format, CultureInfo.InvariantCulture);
            Console.Write("Date 2 (dd.MM.yyyy): ");
            string secondDate = Console.ReadLine();
            DateTime date2 = DateTime.ParseExact(
                secondDate, format, CultureInfo.InvariantCulture);
            TimeSpan difference = date2 - date1;
            Console.WriteLine(difference.TotalDays);
        }
    }
}
