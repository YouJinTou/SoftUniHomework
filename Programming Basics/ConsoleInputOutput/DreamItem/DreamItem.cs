// This solution only receives 80 points,
// and I don't know why
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DreamItem
{
    class DreamItem
    {
        static string[] GetData(string info)
        {
            string[] tokens = info.Split('\\');
            return tokens;
        }

        static double GetMonthlyIncome(string[] tokens)
        {
            string month = tokens[0];
            double wage = double.Parse(tokens[1]);
            int hours = int.Parse(tokens[2]);
            double income = 0;

            switch (tokens[0])
            {
                case "Jan":
                    income = 21 * wage * hours;
                    break;
                case "Feb":
                    income = 18 * wage * hours;
                    break;
                case "Mar":
                    income = 21 * wage * hours;
                    break;
                case "Apr":
                    income = 20 * wage * hours;
                    break;
                case "May":
                    income = 21 * wage * hours;
                    break;
                case "June":
                    income = 20 * wage * hours;
                    break;
                case "July":
                    income = 21 * wage * hours;
                    break;
                case "Aug":
                    income = 21 * wage * hours;
                    break;
                case "Sept":
                    income = 20 * wage * hours;
                    break;
                case "Oct":
                    income = 21 * wage * hours;
                    break;
                case "Nov":
                    income = 20 * wage * hours;
                    break;
                case "Dec":
                    income = 21 * wage * hours;
                    break;
            }
            if (income > 700)
            {
                income += 0.1 * income;
            }
            return income;
        }

        static void CheckBalance(double income, string[] data)
        {
            double itemPrice = double.Parse(data[3]);
            if (income >= itemPrice)
            {
                Console.WriteLine("Money left = {0:0.00} leva.",
                    income - itemPrice);
            }
            else
            {
                Console.WriteLine("Not enough money. {0:0.00} leva needed.",
                    itemPrice - income);
            }
        }

        static void Main(string[] args)
        {
            string info = Console.ReadLine();           
            CheckBalance(GetMonthlyIncome(GetData(info)), GetData(info));              
        }
    }
}
