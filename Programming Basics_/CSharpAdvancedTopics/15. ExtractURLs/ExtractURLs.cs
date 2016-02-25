using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _15.ExtractURLs
{
    class ExtractURLs
    {
        static void Main(string[] args)
        {
            string text = "The site nakov.com can be accessed from "
                + "http://nakov.com or www.nakov.com. It has "
                + "subdomains like mail.nakov.com and svetlin."
                + "nakov.com. Please check https://blog.nakov.com "
                + "for more information.";

            string pattern = "(https?://|www.)([da-z.-]+)\\.([a-z]{2,6})";
            MatchCollection matches = Regex.Matches(text, pattern);
            foreach (Match match in matches)
                Console.WriteLine(match.Value);
        }
    }
}
