using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateFutureAge
{
    class FutureAge
    {
        static void Main(string[] args)
        {
            Console.Write("Input your birthday in the mm/dd/yyyy format: ");
            string birthday = Console.ReadLine();
            DateTime birthdate = DateTime.Parse(birthday);
            Console.WriteLine("Your age in ten years will be: "
                + (DateTime.Now.Year - birthdate.Year + 10));
        }
    }
}
