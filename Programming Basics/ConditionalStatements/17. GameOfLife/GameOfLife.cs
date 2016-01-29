using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.GameOfLife
{
    class GameOfLife
    {
        static int[,] board = new int[10, 10];
        static int[,] resultingBoard = new int[10, 10];

        static int GetStandardCoordinates(int y)
        {
            int newY = board.GetLength(1) - y - 1;
            return newY;
        }

        static void FillBoard(int x, int newY)
        {
            board[x, newY] = 1;
        }

        static void CalculateNextGen()
        {            
            for (int row = 0; row < board.GetLength(0); row++)            
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    int count = CountLivingNeighbors(row, col);
                    if (count < 2 && board[row, col] == 1)
                        resultingBoard[row, col] = 0; // Fewer than two -> dies
                    if ((count == 2 || count == 3)
                        && board[row, col] == 1)
                        resultingBoard[row, col] = 1; // Optimal -> lives on
                    if (count > 3 && board[row, col] == 1)
                        resultingBoard[row, col] = 0; // Overcrowding -> dies
                    if (count == 3 && board[row, col] == 0)
                        resultingBoard[row, col] = 1; // Springs to life                   
                }            
        }

        static int CountLivingNeighbors(int row, int col)
        {
            int neighborCount = 0;
            for (int i = row - 1; i <= row + 1; i++)            
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (i >= 0 && j >= 0
                        && i < 10 && j < 10        // Check bounds
                        && !(i == row && j == col) // Don't check current cell
                        && board[i, j] == 1)       // Check if alive
                        neighborCount++;                   
                }            
            return neighborCount;
        }

        static void PrintResult()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(0); j++)
                {
                    Console.Write(resultingBoard[i, j]);
                }
                Console.WriteLine();
            }
        }
        
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            while (n > 0)
            {
                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());
                FillBoard(x, GetStandardCoordinates(y));
                n--;
            }
            CalculateNextGen();
            PrintResult();
        }
    }
}
