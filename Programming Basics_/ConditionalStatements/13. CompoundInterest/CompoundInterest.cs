using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.CompoundInterest
{
    class CompoundInterest
    {
        static void Main(string[] args)
        {
            double price = double.Parse(Console.ReadLine());
            int years = int.Parse(Console.ReadLine());
            double interest = double.Parse(Console.ReadLine());
            double friendsInterest = double.Parse(Console.ReadLine());

            double bankFV = price * Math.Pow((1 + interest), years);
            double friendFV = price * (1 + friendsInterest);
            double bestOption;
            string lender;
            if (friendFV <= bankFV)
            {
                bestOption = friendFV;
                lender = "Friend";
            }
            else
            {
                bestOption = bankFV;
                lender = "Bank";
            }

            Console.WriteLine("{0:0.00} {1}", bestOption, lender);
        }
    }
}
