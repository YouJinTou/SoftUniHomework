using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyCheck
{
    class CurrencyCheck
    {
        static void Main(string[] args)
        {
            double rubles = double.Parse(Console.ReadLine());
            double dollars = double.Parse(Console.ReadLine());
            double euro = double.Parse(Console.ReadLine());
            double bLeva = double.Parse(Console.ReadLine());
            double mLeva = double.Parse(Console.ReadLine());

            double rublesInLeva = rubles / 100 * 3.5;
            double dollarsInLeva = dollars * 1.5;
            double euroInLeva = euro * 1.95;
            bLeva /= 2;

            double minFirstPair = Math.Min(rublesInLeva, dollarsInLeva);
            double minSecondPair = Math.Min(minFirstPair, euroInLeva);
            double minThirdPair = Math.Min(minSecondPair, bLeva);
            double minFinal = Math.Min(minThirdPair, mLeva);

            Console.Write("{0:0.00}", minFinal);
        }
    }
}
