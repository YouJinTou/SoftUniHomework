using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NumeralSystemConversions
{
    class Program
    {
        static void ConvertDecimalToBinary(int num)
        {
            List<char> binary = new List<char>();
            int originalNumber = num;
             
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

        static void ConvertDecimalToHex(int num)
        {                      
            List<char> hex = new List<char>();
            int originalNumber = num;
            int temp = 0;
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
            int result = 0;
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

        static void ConvertBinaryToHex(string bin)
        {
            StringBuilder newBin = new StringBuilder();
            // We will be taking chunks of four bits,
            // and we need to add zeroes if necessary
            if ((bin.Length % 4) != 0)
            {                
                int leadingZeroes = bin.Length;
                while (leadingZeroes % 4 != 0)
                {
                    leadingZeroes++;
                }
                leadingZeroes -= bin.Length;

                
                for (int i = 1; i <= leadingZeroes; i++)
                {
                    newBin.Append('0');
                }
                newBin.Append(bin);
            }
            else
            {
                newBin.Append(bin);
            }

            StringBuilder buffer = new StringBuilder();
            StringBuilder hex = new StringBuilder();
            int fourCount = 0;
            foreach (char bit in newBin.ToString())
            {
                buffer.Append(bit);
                fourCount++;
                if (fourCount == 4)
                {
                    switch (buffer.ToString())
                    {
                        case "0000":
                            hex.Append('0');
                            break;
                        case "0001":
                            hex.Append('1');
                            break;
                        case "0010":
                            hex.Append('2');
                            break;
                        case "0011":
                            hex.Append('3');
                            break;
                        case "0100":
                            hex.Append('4');
                            break;
                        case "0101":
                            hex.Append('5');
                            break;
                        case "0110":
                            hex.Append('6');
                            break;
                        case "0111":
                            hex.Append('7');
                            break;
                        case "1000":
                            hex.Append('8');
                            break;
                        case "1001":
                            hex.Append('9');
                            break;
                        case "1010":
                            hex.Append('A');
                            break;
                        case "1011":
                            hex.Append('B');
                            break;
                        case "1100":
                            hex.Append('C');
                            break;
                        case "1101":
                            hex.Append('D');
                            break;
                        case "1110":
                            hex.Append('E');
                            break;
                        case "1111":
                            hex.Append('F');
                            break;
                    }
                    buffer.Clear();
                    fourCount = 0;
                }
            }
            Console.WriteLine("{0} in hexadecimal is: {1}", bin, hex.ToString());
        }

        static void ConvertHexToDecimal(string hex)
        {
            int result = 0;
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

        static void ConvertHexToBinary(string hex)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hex.Length; i++)
            {
                switch (hex[i])
                {
                    case '0':
                        builder.Append("0000");
                        break;
                    case '1':
                        builder.Append("0001");
                        break;
                    case '2':
                        builder.Append("0010");
                        break;
                    case '3':
                        builder.Append("0011");
                        break;
                    case '4':
                        builder.Append("0100");
                        break;
                    case '5':
                        builder.Append("0101");
                        break;
                    case '6':
                        builder.Append("0110");
                        break;
                    case '7':
                        builder.Append("0111");
                        break;
                    case '8':
                        builder.Append("1000");
                        break;
                    case '9':
                        builder.Append("1001");
                        break;
                    case 'A':
                        builder.Append("1010");
                        break;
                    case 'B':
                        builder.Append("1011");
                        break;
                    case 'C':
                        builder.Append("1100");
                        break;
                    case 'D':
                        builder.Append("1101");
                        break;
                    case 'E':
                        builder.Append("1110");
                        break;
                    case 'F':
                        builder.Append("1111");
                        break;
                }
            }
            Console.WriteLine("{0} to binary is: {1}", hex, builder);
        }

        static void Main(string[] args)
        {
            ConvertDecimalToBinary(1234);
            ConvertDecimalToHex(1234);
            ConvertBinaryToDecimal("1100101");
            ConvertBinaryToHex("1100101");
            ConvertHexToDecimal("ABC");
            ConvertHexToBinary("ABC");
        }
    }
}
