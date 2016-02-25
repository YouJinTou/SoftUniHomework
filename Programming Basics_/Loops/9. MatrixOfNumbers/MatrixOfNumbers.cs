using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.MatrixOfNumbers
{
    class MatrixOfNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            int filler;
            for (int row = 0; row < n; row++)
            {
                filler = row + 1;
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = filler;
                    Console.Write(matrix[row, col] + " ");
                    filler++;
                }                
                Console.WriteLine();
            }
        }
    }
}
