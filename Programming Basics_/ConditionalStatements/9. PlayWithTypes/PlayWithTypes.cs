using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.PlayWithTypes
{
    class PlayWithTypes
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please choose a type: ");
            Console.WriteLine("1 --> int");
            Console.WriteLine("2 --> double");
            Console.WriteLine("3 --> string");
            int type = int.Parse(Console.ReadLine());
            
            switch (type)
            {
                case 1:
                    Console.Write("Enter an integer: ");
                    int i = int.Parse(Console.ReadLine());
                    i++;
                    Console.WriteLine("Result: " + i);
                    break;
                case 2:
                    Console.Write("Enter a double: ");
                    double d = double.Parse(Console.ReadLine());
                    d++;
                    Console.WriteLine("Result: " + d);
                    break;
                case 3:
                    Console.Write("Enter a string: ");
                    string s = Console.ReadLine();
                    string sAsterisk = s + "*";
                    Console.WriteLine("Result: " + sAsterisk);
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }
    }
}
