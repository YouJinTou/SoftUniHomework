/// Spaghetti Code Incoming
///
///
///
///

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketBattle
{
    class BasketBattle
    {
        static void Main(string[] args)
        {
            string F = Console.ReadLine();
            int N = int.Parse(Console.ReadLine());
            int simeonPoints = 0;
            int nakovPoints = 0;
            string winner = null;
            int roundCount = 0;
            int losersPoints = 0;

            int switchTurns = (F == "Nakov") ? 1 : 0;
            for (int round = 1; round <= N; round++)
            {                
                switch (switchTurns)
                {
                    case 0:
                        {
                            switch ("Simeon")
                            {
                                case "Simeon":
                                    {
                                        int P = int.Parse(Console.ReadLine());
                                        string I = Console.ReadLine();
                                        if (I == "success")
                                        {
                                            simeonPoints += P;
                                        }
                                        if (simeonPoints == 500)
                                        {
                                            winner = "Simeon";
                                            roundCount = round;
                                            losersPoints = nakovPoints;
                                            break;
                                        }
                                        else if (simeonPoints > 500)
                                        {
                                            simeonPoints -= P;
                                        }
                                        goto case "Nakov";
                                    }
                                case "Nakov":
                                    {
                                        int P = int.Parse(Console.ReadLine());
                                        string I = Console.ReadLine();
                                        if (I == "success")
                                        {
                                            nakovPoints += P;
                                        }
                                        if (nakovPoints == 500)
                                        {
                                            winner = "Nakov";
                                            roundCount = round;
                                            losersPoints = simeonPoints;
                                            break;
                                        }
                                        else if (nakovPoints > 500)
                                        {
                                            nakovPoints -= P;
                                        }
                                        break;
                                    }
                            }
                            break;
                        }
                    case 1:
                        {
                            switch ("Nakov")
                            {
                                case "Nakov":
                                    {
                                        int P = int.Parse(Console.ReadLine());
                                        string I = Console.ReadLine();
                                        if (I == "success")
                                        {
                                            nakovPoints += P;
                                        }
                                        if (nakovPoints == 500)
                                        {
                                            winner = "Nakov";
                                            roundCount = round;
                                            losersPoints = simeonPoints;
                                            break;
                                        }
                                        else if (nakovPoints > 500)
                                        {
                                            nakovPoints -= P;
                                        }
                                        goto case "Simeon";
                                    }
                                case "Simeon":
                                    {
                                        int P = int.Parse(Console.ReadLine());
                                        string I = Console.ReadLine();
                                        if (I == "success")
                                        {
                                            simeonPoints += P;
                                        }
                                        if (simeonPoints == 500)
                                        {
                                            winner = "Simeon";
                                            roundCount = round;
                                            losersPoints = nakovPoints;
                                            break;
                                        }
                                        else if (simeonPoints > 500)
                                        {
                                            simeonPoints -= P;
                                        }
                                        break;
                                    }
                            }
                            break;
                        }                        
                }
                if (winner != null)
                {
                    break;
                }

                if (switchTurns == 0)
                {
                    switchTurns++;
                }
                else
                {
                    switchTurns = 0;
                }
            }
            if (winner != null)
            {
                Console.WriteLine(winner);
                Console.WriteLine(roundCount);
                Console.WriteLine(losersPoints);
            }
            else if (winner == null && nakovPoints == simeonPoints)
            {
                Console.WriteLine("DRAW");
                Console.WriteLine(nakovPoints);
            }
            else if (winner == null && nakovPoints != simeonPoints)
            {
                if (nakovPoints > simeonPoints)
                {
                    Console.WriteLine("Nakov");
                }
                else
                {
                    Console.WriteLine("Simeon");
                }                
                Console.WriteLine(
                    Math.Max(nakovPoints, simeonPoints)
                    - Math.Min(nakovPoints, simeonPoints));
            }
        }
    }
}