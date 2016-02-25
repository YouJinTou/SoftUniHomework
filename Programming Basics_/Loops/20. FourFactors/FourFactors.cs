using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20.FourFactors
{
    class FourFactors
    {
        static void Main(string[] args)
        {
            long FG = int.Parse(Console.ReadLine());
            long FGA = int.Parse(Console.ReadLine());
            long threeP = int.Parse(Console.ReadLine());
            long TOV = int.Parse(Console.ReadLine());
            long ORB = int.Parse(Console.ReadLine());
            long OppDRB = int.Parse(Console.ReadLine());
            long FT = int.Parse(Console.ReadLine());
            long FTA = int.Parse(Console.ReadLine());
                        
            double EFG = (FG + 0.5 * threeP) / FGA;
            double TPF = (TOV / (FGA + 0.44 * FTA + TOV));
            double ORBF = (ORB / (double)(ORB + OppDRB));
            double FTF = (double)FT / FGA;

            Console.WriteLine("eFG% {0:0.000}", EFG);
            Console.WriteLine("TOV% {0:0.000}", TPF);
            Console.WriteLine("ORB% {0:0.000}", ORBF);
            Console.WriteLine("FT% {0:0.000}", FTF);
        }
    }
}
