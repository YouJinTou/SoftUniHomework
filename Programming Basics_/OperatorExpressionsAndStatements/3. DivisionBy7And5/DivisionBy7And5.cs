using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.DivisionBy7And5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Integer to check: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(
            (n % 5 == 0 && n % 7 == 0) ? true : false);
        }
    }
}
