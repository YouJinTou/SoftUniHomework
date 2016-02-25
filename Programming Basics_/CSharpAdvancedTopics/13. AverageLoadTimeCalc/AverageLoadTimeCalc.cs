using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.AverageLoadTimeCalc
{
    class AverageLoadTimeCalc
    {
        static string[] GetTokens(string[] report, int lineIndex)
        {
            string[] tokens = report[lineIndex].Split(' ');
            return tokens;
        }

        static Dictionary<string, List<double>> AccumulateStats(string[] report)
        {
            Dictionary<string, List<double>> siteStats
                = new Dictionary<string, List<double>>();
            for (int i = 0; i < report.Length; i++)
            {
                string[] lineTokens = GetTokens(report, i);
                string URL = lineTokens[2];
                double loadTime = double.Parse(lineTokens[3]);
                List<double> loadTimes;
                if (!siteStats.TryGetValue(URL, out loadTimes))
                {
                    loadTimes = new List<double>();
                    loadTimes.Add(loadTime);
                    siteStats.Add(URL, loadTimes);
                }
                else
                    siteStats[URL].Add(loadTime);
            }
            return siteStats;
        }

        static void Main(string[] args)
        {
            string[] report = new string[]
            {
                "2014-Apr-01 02:01 http://softuni.bg 8.37725",
                "2014-Apr-01 02:05 http://www.nakov.com 11.622",
                "2014-Apr-01 02:06 http://softuni.bg 4.33",
                "2014-Apr-01 02:11 http://www.google.com 1.94",
                "2014-Apr-01 02:11 http://www.google.com 2.011",
                "2014-Apr-01 02:12 http://www.google.com 4.882",
                "2014-Apr-01 02:34 http://softuni.bg 4.885",
                "2014-Apr-01 02:36 http://www.nakov.com 10.74",
                "2014-Apr-01 02:36 http://www.nakov.com 11.75",
                "2014-Apr-01 02:38 http://softuni.bg 3.886",
                "2014-Apr-01 02:44 http://www.google.com 1.04",
                "2014-Apr-01 02:48 http://www.google.com 1.4555",
                "2014-Apr-01 02:55 http://www.google.com 1.977"
            };

            Dictionary<string, List<double>> dict = AccumulateStats(report);
            foreach (var entry in dict)
                Console.WriteLine("{0} -> {1}", entry.Key, entry.Value.Average());
        }
    }
}
