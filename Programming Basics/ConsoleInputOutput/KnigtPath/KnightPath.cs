// This solution only receives 87 points,
// and I don't know why
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnigtPath
{
    class KnightPath
    {
        public static int rank = 0;
        public static int file = 7;
        public static int[,] board = new int[8, 8];
        public static List<int> numbersToPrint = new List<int>();           

        static void MoveKnight(string dir, int[,] board)
        {
            #region Move
            switch (dir)
            {
                case "left up":
                    if (CheckBounds(dir, rank, file))
                    {
                        file -= 2;
                        rank--;
                        if (board[rank, file] == 1)
                            board[rank, file] = 0;
                        else
                            board[rank, file] = 1;
                    }
                    break;
                case "left down":
                    if (CheckBounds(dir, rank, file))
                    {
                        file -= 2;
                        rank++;
                        if (board[rank, file] == 1)
                            board[rank, file] = 0;
                        else
                            board[rank, file] = 1;
                    }
                    break;
                case "right up":
                    if (CheckBounds(dir, rank, file))
                    {
                        file += 2;
                        rank--;
                        if (board[rank, file] == 1)
                            board[rank, file] = 0;
                        else
                            board[rank, file] = 1;
                    }
                    break;
                case "right down":
                    if (CheckBounds(dir, rank, file))
                    {
                        file += 2;
                        rank++;
                        if (board[rank, file] == 1)
                            board[rank, file] = 0;
                        else
                            board[rank, file] = 1;
                    }
                    break;
                case "up left":
                    if (CheckBounds(dir, rank, file))
                    {
                        rank -= 2;
                        file--;
                        if (board[rank, file] == 1)
                            board[rank, file] = 0;
                        else
                            board[rank, file] = 1;
                    }
                    break;
                case "up right":
                    if (CheckBounds(dir, rank, file))
                    {
                        rank -= 2;
                        file++;
                        if (board[rank, file] == 1)
                            board[rank, file] = 0;
                        else
                            board[rank, file] = 1;
                    }
                    break;
                case "down left":
                    if (CheckBounds(dir, rank, file))
                    {
                        rank += 2;
                        file--;
                        if (board[rank, file] == 1)
                            board[rank, file] = 0;
                        else
                            board[rank, file] = 1;
                    }
                    break;
                case "down right":
                    if (CheckBounds(dir, rank, file))
                    {
                        rank += 2;
                        file ++;
                        if (board[rank, file] == 1)
                            board[rank, file] = 0;
                        else
                            board[rank, file] = 1;
                    }
                    break;
#endregion
            }
        }

        static bool CheckBounds(string dir,
            int rank, int file)
        {
            bool canJump = true;

            #region Check bounds
            switch (dir)
            {
                case "left up":
                    if (file - 2 < 0
                        || rank - 1 < 0)
                    {
                        canJump = false;
                    }
                    break;
                case "left down":
                    if (file - 2 < 0
                        || rank + 1 > 7)
                    {
                        canJump = false;
                    }
                    break;
                case "right up":
                    if (file + 2 > 7
                        || rank - 1 < 0)
                    {
                        canJump = false;
                    }
                    break;
                case "right down":
                    if (file + 2 > 7
                        || rank + 1 > 7)
                    {
                        canJump = false;
                    }
                    break;
                case "up left":
                    if (rank - 2 < 0
                        || file - 1 < 0)
                    {
                        canJump = false;
                    }
                    break;
                case "up right":
                    if (rank - 2 < 0
                        || file + 1 > 7)
                    {
                        canJump = false;
                    }
                    break;
                case "down left":
                    if (rank + 2 > 7
                        || file - 1 < 0)
                    {
                        canJump = false;
                    }
                    break;
                case "down right":
                    if (rank + 2 > 7
                        || file + 1 > 7)
                    {
                        canJump = false;
                    }
                    break;
            }
            return canJump;
            #endregion
        }

        static void GetBinaryFromRows(int[,] board)
        {            
            for (int rank = 0; rank < 8; rank++)
            {
                StringBuilder binary = new StringBuilder();
                for (int file = 0; file < 8; file++)
                {
                    binary.Append(board[rank, file]);
                }
                int number =                                // Convert binary to decimal
                    Convert.ToInt32(binary.ToString(), 2);
                AddNumber(number);                
            }
        }        
        
        static void AddNumber(int number)
        {
            if (number != 0)
            {
                numbersToPrint.Add(number);
            }            
        }

        static void Main(string[] args)
        {
            board[0, 7] = 1;
            string input = null;

            int count = 1;
            while (input != "stop" || count > 25)
            {
                input = Console.ReadLine();
                MoveKnight(input, board);
                count++;
            }

            GetBinaryFromRows(board);
            foreach (int number in numbersToPrint)
            {
                Console.WriteLine(number);
            }
        }
    }
}

