/// I couldn't figure out a way to count the number of intersections accurately,
/// so I've commented that part out. The rest of the functionality performs
/// as intended. Of course, the program does not pass the judge's tests
/// and thus scores 0-15.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21.BitsAtCrossroads
{
    class BitsAtCrossroads
    {
        static int[,] board;
        static int counter = 0;

        static string[] ParseCrossroad(string c)
        {
            string[] numberString = c.Split(' ');
            return numberString;
        }

        static void BuildRoads(int n, string c)
        {   
            int rowParse =
                int.Parse(ParseCrossroad(c)[0]);
            int colParse = 
                int.Parse(ParseCrossroad(c)[1]);
            int col = n - colParse - 1;
            int row = rowParse;
            int bound = 0;

            // Going left-right
             if (row - col <= 0)
            {
                row = 0;
                col = col - rowParse;
                bound = rowParse + colParse;
            }
            else
            {
                row = row - col;
                col = 0;
                bound = n - 1;
            }
            for (int i = row, j = col;
                i <= bound; i++, j++)
            {
                board[i, j] = 1;
            }

            // Resetting values
            col = n - colParse - 1;
            row = rowParse;

            // Going right-left
            if (row + col < n)
            {
                row = 0;
                col += rowParse;
                bound = col;
            }
            else
            {
                row = row - colParse;
                col = n - 1;
                bound = n - 1;
            }         
            for (int i = row, j = col;
                i <= bound; i++, j--)
            {
                board[i, j] = 1;
            }
        }

        /*static void CountCrossroads()
        {
            for (int row = 1; row < board.GetLength(0); row++)
            {
                if (row == board.GetLength(0) - 1)
                    break;
                for (int col = 1; col < board.GetLength(1); col++)
                {
                    if (col == board.GetLength(1) - 1)
                        break;                    
                    if (board[row - 1, col - 1] == 1
                        && board[row - 1, col + 1] == 1
                        && board[row, col] == 1
                        && board[row + 1, col - 1] == 1
                        && board[row + 1, col + 1] == 1) // General case
                        counter++;                             
                }
            }       
        }*/

        static List<int> GetDecimal()
        {
            List<int> decimals = new List<int>();
            StringBuilder intBuilder = new StringBuilder();

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    intBuilder.Append(board[row, col]);
                }
                decimals.Add(
                    ((Convert.ToInt32(intBuilder.ToString(), 2))));
                intBuilder.Clear();
            }
            return decimals;
        }

        static void PrintResult(List<int> numbers)
        {
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
            // CountCrossroads();
            // Console.WriteLine(counter);
        }
        
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            board = new int[n, n];
            string command = null;

            while (true)
            {                                    
                command = Console.ReadLine();
                if (command == "end")
                    break;
                BuildRoads(n, command);
            }
            PrintResult(GetDecimal());            
        }
    }
}
