using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21.DetectiveBoev
{
    class DetectiveBoev
    {
        static int GetMask(string cipher)
        {
            int sum = 0;
            foreach (char ch in cipher)
                sum += ch;

            int mask = sum;
            if (sum.ToString().Length > 1)
            {
                do
                {
                    mask = 0;
                    foreach (char digit in sum.ToString())
                        mask += (int)char.GetNumericValue(digit);
                    sum = mask;
                }
                while (mask.ToString().Length > 1);
            }            
            return mask;
        }

        static string DecryptMessage(string message, int mask)
        {
            StringBuilder decrypter = new StringBuilder();
            foreach (char ch in message)
            {
                if (ch % mask == 0)
                    decrypter.Append((char)(ch + mask));
                else
                    decrypter.Append((char)(ch - mask));
            }

            char[] array = decrypter.ToString().ToCharArray();
            Array.Reverse(array);
            string reversedMessage = new string(array);            
            return reversedMessage;
        }

        static void Main(string[] args)
        {
            string cipher = Console.ReadLine();
            string message = Console.ReadLine();

            Console.WriteLine(DecryptMessage(message, GetMask(cipher)));
        }
    }
}
