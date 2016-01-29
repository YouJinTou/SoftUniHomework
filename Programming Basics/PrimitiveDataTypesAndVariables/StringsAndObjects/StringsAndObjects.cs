using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsAndObjects
{
    class StringsAndObjects
    {
        static void Main(string[] args)
        {
            string str1 = "Hello";
            string str2 = "World";
            object concat = str1 + " " + str2;
            string str3 = (string)concat;

            Console.WriteLine(concat);
            Console.WriteLine(str3);
        }
    }
}
