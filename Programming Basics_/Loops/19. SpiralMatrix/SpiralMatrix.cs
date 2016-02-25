using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.SpiralMatrix
{
    class SpiralMatrix
    {        
        static int n;
        static int[,] matrix;
        static int filler = 1;
        static byte[] direction
            = new byte[4] { 0, 1, 2, 3 }; // Right, down, left, up        
        
        static void ShrinkBounds()
        {
            // Matrix constraints
            int topRow = 0;
            int bottomRow = n - 1;
            int leftCol = 0;
            int rightCol = n - 1;

            int dir = 0; // Start direction right
            while (filler != n * n + 1) // Ends prematurely if only n * n
            {
                switch (direction[dir])
                {
                    case 0: // Going right
                        FillMatrix(topRow, leftCol, dir,
                            topRow, rightCol);
                        topRow++; // Top row gone
                        dir++;
                        break;
                    case 1: // Going down
                        FillMatrix(topRow, rightCol, dir,
                            bottomRow, rightCol);
                        rightCol--; // Right column gone
                        dir++;
                        break;
                    case 2: // Going left
                        FillMatrix(bottomRow, rightCol, dir,
                            bottomRow, leftCol);
                        bottomRow--; // Bottom row gone
                        dir++;
                        break;
                    case 3: // Going up
                        FillMatrix(bottomRow, leftCol, dir,
                            topRow, leftCol);
                        leftCol++; // Left column gone
                        dir = 0; // Reset directions
                        break;
                }
            }            
        }

        static void FillMatrix(int row, int col, int dir,
            int rowBound, int colBound)
        {
            switch (dir)
            {
                case 0: // The for-loop for right and down is the same
                case 1: // The end-condition depends on the direction
                    for (int r = row; r < ((dir == 0) ? row + 1 : rowBound + 1); r++)                    
                        for (int c = col; c < ((dir == 1) ? col + 1 : colBound + 1); c++)
                        {
                            matrix[r, c] = filler;
                            filler++;
                        }
                    break;
                case 2:
                case 3: 
                    for (int r = row; r > ((dir == 2) ? row - 1 : rowBound - 1); r--)
                        for (int c = col; c > ((dir == 3) ? col - 1 : colBound - 1); c--)
                        {
                            matrix[r, c] = filler;
                            filler++;
                        }
                    break;
            }
        }

        static void PrintMatrix()
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write("{0}\t", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        
        static void Main(string[] args)
        {
            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());
            matrix = new int[n, n];
            ShrinkBounds();
            PrintMatrix();
        }
    }
}
