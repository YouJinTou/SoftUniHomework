using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.LongestWordInText
{
    class LongestWordInText
    {
        static void Main(string[] args)
        {
            string text = "The C# Basics- .course? --is an awesome" +
                " start in programming ?with C# and Visual Studio.";
            char[] separators = { ' ', ',', '!', '?', '-', '.', '@' };
            string[] tokens = text.Split(separators
                , StringSplitOptions.RemoveEmptyEntries);

            string longestWord
                = tokens.OrderByDescending(w => w.Length).First();
            Console.WriteLine(longestWord);
        }
    }
}
