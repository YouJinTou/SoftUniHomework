using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.MatrixOfPalindromes
{
    class MatrixOfPalindromes
    {
        static string GeneratePalindromes(int row, int col)
        {
            if (row > 25)
                row -= 26;
            if (col + row + 97 > 122)
                col -= 26;

            string palindrome = null;            
            char[] palArray = new char[3];
            for (int i = row + 97; i <= 122; i++)
            {

                palArray[0] = (char)i;
                palArray[1] = (char)(col + i);
                palArray[2] = (char)i;                
                palindrome = new string(palArray);
                break;
            }
            return palindrome;
        }

        static string[,] FilLMatrix(int row, int col)
        {
            string[,] matrix = new string[row, col];
            for (int i = 0; i < row; i++)          
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = GeneratePalindromes(i, j);
                }
            return matrix;    
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Rows: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Columns: ");
            int cols = int.Parse(Console.ReadLine());

            PrintMatrix(FilLMatrix(rows, cols));
        }
    }
}
