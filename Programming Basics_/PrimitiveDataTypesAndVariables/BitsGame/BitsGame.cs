/// This only scores 87 when checked by the Judge System,
/// and I don't understand why.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsGame
{
    class BitsGame
    {
        static string Reverse(string binaryNumber)
        {
            char[] charArray = binaryNumber.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static string ExtractOddBits(uint number)
        {
            if (number == 1)
            {
                return "1";
            }
            string numberString = Convert.ToString(number, 2);           
            StringBuilder num = new StringBuilder();            
            int bitPosition = 1;
            for (int i = numberString.Length - 1; i >= 0; i--)
            {
                if (bitPosition % 2 != 0)
                {
                    num.Append(numberString[i]);
                }
                bitPosition++;
            }

            string result = Reverse(num.ToString());
            return result;
        }

        static string ExtractEvenBits(uint number)
        {            
            if (number == 1)
            {
                return "1";
            }
            string oddBits = Convert.ToString(number, 2);
            StringBuilder num = new StringBuilder();
            int bitPosition = 1;
            for (int i = oddBits.Length - 1; i >= 0; i--)
            {
                if (bitPosition % 2 == 0)
                {
                    num.Append(oddBits[i]);
                }
                bitPosition++;
            }

            string result = Reverse(num.ToString());
            return result;
        }

        static string GameOver(uint number)
        {
            string evenBits = Convert.ToString(number, 2);
            int count = 0;
            foreach (char bit in evenBits)
            {
                if (bit == '1')
                {
                    count++;
                }
            }
            int finalNumber = Convert.ToInt32(evenBits, 2);

            string result = finalNumber + " -> " + count;
            return result;
        }

        static void Main(string[] args)
        {
            uint number = uint.Parse(Console.ReadLine());
            string command = null;
            
            do
            {                
                command = Console.ReadLine();
                switch (command)
                {
                    case "Odd":
                        number = Convert.ToUInt32(ExtractOddBits(number), 2);
                        break;
                    case "Even":
                        number = Convert.ToUInt32(ExtractEvenBits(number), 2);
                        break;
                }

            } while ((command != "Game Over!"
                && number != 0));
            Console.WriteLine(GameOver(number));
        }
    }
}