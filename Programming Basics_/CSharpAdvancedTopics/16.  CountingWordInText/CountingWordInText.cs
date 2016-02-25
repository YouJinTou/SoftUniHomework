using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _16.CountingWordInText
{
    class CountingWordInText
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = "Hidden networks say “Hi” only to Hitachi devices. Hi, said Matuhi. HI!";

            string pattern = "\\b(?i)" + word + "\\b";
            int count = Regex.Matches(text, pattern).Count;
            Console.WriteLine(count);
        }
    }
}
