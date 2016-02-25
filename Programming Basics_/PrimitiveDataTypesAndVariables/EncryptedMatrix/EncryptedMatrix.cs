using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptedMatrix
{
    class EncryptedMatrix
    {        
        static string ConvertMessageIntoNumber(string message)
        {
            StringBuilder numberToEncrypt = new StringBuilder();
            foreach (char ch in message)
            {                
                string asciiNumber = Convert.ToInt32(ch).ToString();
                numberToEncrypt.Append(asciiNumber[asciiNumber.Length - 1]);                
            }
            return numberToEncrypt.ToString();
        }

        static string EncryptNumber(string number)
        {
            StringBuilder encryptedNumber = new StringBuilder();
            int count = 0;
            foreach (char ch in number)
            {
                int digit = (int)char.GetNumericValue(ch);
                if (digit % 2 == 0
                    || digit == 0)
                {
                    int value = digit * digit;
                    encryptedNumber.Append(value);
                }
                else
                {
                    if (number.Length != 1
                        && number.Length != 0)
                    {
                        if (count == 0) // We are at the start of the string
                        {
                            int value = digit
                                + (int)char.GetNumericValue((number[count + 1]));
                            encryptedNumber.Append(value);
                        }
                        else if (count == number.Length - 1) // We are at the end of the string
                        {
                            int value = digit
                                + (int)char.GetNumericValue(number[count - 1]);
                            encryptedNumber.Append(value);
                        }
                        else
                        {
                            int value = digit
                                + (int)char.GetNumericValue(number[count + 1])
                                + (int)char.GetNumericValue(number[count - 1]);
                            encryptedNumber.Append(value);
                        }
                    }
                    else
                    {
                        int value = digit;
                        encryptedNumber.Append(value); // The cases where the string is of length 0 or 1
                    }                  
                }
                count++;
            }
            return encryptedNumber.ToString();
        }

        static int[,] FillMatrix(string encryptedNumber, char direction)
        {
            int size = encryptedNumber.Length;
            int[,] matrix = new int[size, size];

            if (direction == '\\')
            {
                int count = 0;
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (count == col)
                        {
                            matrix[row, col] = 
                                (int)char.GetNumericValue(encryptedNumber[col]);
                        }
                    }
                    count++;
                }
            }
            else
            {
                encryptedNumber.Reverse();
                int count = size - 1;
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (count == col)
                        {
                            matrix[row, col] =
                                (int)char.GetNumericValue(encryptedNumber[col]);
                        }
                    }
                    count--;
                }
            }
            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            char direction = char.Parse(Console.ReadLine());
            PrintMatrix(FillMatrix(EncryptNumber(ConvertMessageIntoNumber(message)), direction));            
        }
    }
}
