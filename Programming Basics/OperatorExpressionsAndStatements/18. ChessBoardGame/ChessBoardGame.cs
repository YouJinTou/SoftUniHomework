using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.ChessBoardGame
{
    class ChessBoardGame
    {
        static int scoreWhite = 0;
        static int scoreBlack = 0;
                 
        static int[] ConvertStringToAscii(string str, int n)
        {
            int[] values = new int[n * n];
            int i = 0;
            foreach (char ch in str)
            {
                if (i >= n * n)
                {
                    break;
                }
                if (char.IsDigit(ch) || char.IsLetter(ch))
                {
                    values[i] = ch;
                }                
                i++;
            }
            return values;
        }

        static int[,] FillChessBoard(int n, int[] values)
        {
            int[,] chessBoard = new int[n, n];
            int count = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    chessBoard[row, col] = values[count];
                    count++;
                }
            }
            return chessBoard;
        }

        static void CalculateScore(int[,] chessBoard, byte team)
        {
            // Zero is black, one is white
            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                // Column logic on each row
                int startCol = 0;
                if (team == 0)
                {
                    startCol = (row % 2 == 0) ? 0 : 1;
                }
                else
                {
                    startCol = (row % 2 == 0) ? 1 : 0;
                }
                for (int col = startCol; col < chessBoard.GetLength(0);
                    col += 2)
                {
                    char ch = (char)chessBoard[row, col];
                    if (char.IsUpper(ch))
                    {
                        if (team == 0)
                        {
                            scoreWhite += ch;
                            continue;
                        }
                        else
                        {
                            scoreBlack += ch;
                            continue;
                        }
                    }  
                    if (team == 0)
                    {
                        scoreBlack += chessBoard[row, col];
                    }
                    else
                    {
                        scoreWhite += chessBoard[row, col];
                    }
                }
            }
        }

        static void AnnounceResult()
        {
            if (scoreWhite == scoreBlack)
            {
                Console.WriteLine("Equal result: {0}", scoreWhite);
            }
            else
            {
                if (scoreWhite > scoreBlack)
                {
                    Console.WriteLine("The winner is: white team");
                }
                else
                {
                    Console.WriteLine("The winner is: black team");
                }
                int winner = Math.Max(scoreWhite, scoreBlack);
                int loser = Math.Min(scoreWhite, scoreBlack);
                Console.WriteLine(winner - loser);
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string str = Console.ReadLine();
            CalculateScore(FillChessBoard(n, ConvertStringToAscii(str, n)), 0);
            CalculateScore(FillChessBoard(n, ConvertStringToAscii(str, n)), 1);
            AnnounceResult();
        }
    }
}
