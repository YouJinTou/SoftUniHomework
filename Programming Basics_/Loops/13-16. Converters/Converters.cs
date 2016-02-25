using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_16.Converters
{
    class Converters
    {
        static void ConvertDecimalToBinary(long num)
        {
            List<char> binary = new List<char>();
            long originalNumber = num;

            while (num >= 1)
            {
                if ((num % 2) == 0)
                {
                    binary.Add('0');
                }
                else
                {
                    binary.Add('1');
                }
                num /= 2;
            }
            binary.Reverse();
            Console.Write("{0} in binary is: ", originalNumber);
            foreach (char ch in binary)
            {
                Console.Write(ch);
            }
            Console.WriteLine();
        }

        static void ConvertDecimalToHex(long num)
        {
            List<char> hex = new List<char>();
            long originalNumber = num;
            long temp = 0;
            while (num >= 1)
            {
                temp = num / 16; // This will return a number < num
                temp *= 16; // if there are digits after the decimal point                                
                switch (num - temp)
                {
                    case 0:
                        hex.Add('0');
                        break;
                    case 1:
                        hex.Add('1');
                        break;
                    case 2:
                        hex.Add('2');
                        break;
                    case 3:
                        hex.Add('3');
                        break;
                    case 4:
                        hex.Add('4');
                        break;
                    case 5:
                        hex.Add('5');
                        break;
                    case 6:
                        hex.Add('6');
                        break;
                    case 7:
                        hex.Add('7');
                        break;
                    case 8:
                        hex.Add('8');
                        break;
                    case 9:
                        hex.Add('9');
                        break;
                    case 10:
                        hex.Add('A');
                        break;
                    case 11:
                        hex.Add('B');
                        break;
                    case 12:
                        hex.Add('C');
                        break;
                    case 13:
                        hex.Add('D');
                        break;
                    case 14:
                        hex.Add('E');
                        break;
                    case 15:
                        hex.Add('F');
                        break;
                }
                num = temp / 16;
            }
            hex.Reverse();
            Console.Write("{0} in hexadecimal is: ", originalNumber);
            foreach (char ch in hex)
            {
                Console.Write(ch);
            }
            Console.WriteLine();
        }

        static void ConvertBinaryToDecimal(string bin)
        {
            int currentPower = 0;
            long result = 0;
            for (int i = bin.Length - 1; i >= 0; i--)
            {
                if (bin[i] == '1')
                {
                    result += (int)Math.Pow(2, currentPower);
                    currentPower++;
                }
                else
                {
                    currentPower++;
                }
            }
            Console.WriteLine("{0} in decimal is: {1}", bin, result);
        }

        static void ConvertHexToDecimal(string hex)
        {
            long result = 0;
            int currentPower = 0;
            for (int i = hex.Length - 1; i >= 0; i--)
            {
                switch (hex[i])
                {
                    case '0':
                        result += 0 * (int)Math.Pow(16, currentPower);
                        currentPower++;
                        break;
                    case '1':
                        result += 1 * (int)Math.Pow(16, currentPower);
                        currentPower++;
                        break;
                    case '2':
                        result += 2 * (int)Math.Pow(16, currentPower);
                        currentPower++;
                        break;
                    case '3':
                        result += 3 * (int)Math.Pow(16, currentPower);
                        currentPower++;
                        break;
                    case '4':
                        result += 4 * (int)Math.Pow(16, currentPower);
                        currentPower++;
                        break;
                    case '5':
                        result += 5 * (int)Math.Pow(16, currentPower);
                        currentPower++;
                        break;
                    case '6':
                        result += 6 * (int)Math.Pow(16, currentPower);
                        currentPower++;
                        break;
                    case '7':
                        result += 7 * (int)Math.Pow(16, currentPower);
                        currentPower++;
                        break;
                    case '8':
                        result += 8 * (int)Math.Pow(16, currentPower);
                        currentPower++;
                        break;
                    case '9':
                        result += 9 * (int)Math.Pow(16, currentPower);
                        currentPower++;
                        break;
                    case 'A':
                        result += 10 * (int)Math.Pow(16, currentPower);
                        currentPower++;
                        break;
                    case 'B':
                        result += 11 * (int)Math.Pow(16, currentPower);
                        currentPower++;
                        break;
                    case 'C':
                        result += 12 * (int)Math.Pow(16, currentPower);
                        currentPower++;
                        break;
                    case 'D':
                        result += 13 * (int)Math.Pow(16, currentPower);
                        currentPower++;
                        break;
                    case 'E':
                        result += 14 * (int)Math.Pow(16, currentPower);
                        currentPower++;
                        break;
                    case 'F':
                        result += 15 * (int)Math.Pow(16, currentPower);
                        currentPower++;
                        break;
                }
            }
            Console.WriteLine("{0} in decimal is: {1}", hex, result);
        }

        static void Main(string[] args)
        {
            // Fill in the parentheses 
            ConvertBinaryToDecimal("1100101");
            ConvertDecimalToBinary(1234);
            ConvertHexToDecimal("ABC");
            ConvertDecimalToHex(1234);                    
        }
    }
}
