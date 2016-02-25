using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _10.BeerTime
{
    class BeerTime
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Time for a beer (hh:mm tt)? ");
            string time = Console.ReadLine();
            string format = "h:mm tt";
            try
            {
                DateTime beerTime = DateTime.ParseExact(time, format,
               CultureInfo.InvariantCulture);
                DateTime noon = DateTime.ParseExact("1:00 PM", format,
                    CultureInfo.InvariantCulture);
                DateTime night = DateTime.ParseExact("3:00 AM", format,
                    CultureInfo.InvariantCulture);

                if (beerTime < night || beerTime >= noon)
                {
                    Console.WriteLine("Beer time.");
                }
                else
                    Console.WriteLine("Non-beer time.");
            }
            catch
            {
                Console.WriteLine("Invalid time.");
            }
        }
    }
}
