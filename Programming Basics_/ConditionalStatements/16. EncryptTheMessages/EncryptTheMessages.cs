using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _16.EncryptTheMessages
{
    class EncryptTheMessages
    {
        static int messageCount = 0;

        static char[] ReverseMessage(string message)
        {
            char[] result = message.ToCharArray();
            Array.Reverse(result);
            return result;
        }

        static string EncryptMessage(char[] message)
        {
            StringBuilder encrypter = new StringBuilder();
            char[] AM = new char[]
            { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm' };
            char[] NZ = new char[]
            { 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            foreach (char ch in message)
            {
                string c = ch.ToString();
                if (AM.Contains(ch))
                {
                    int indexAM = Array.IndexOf(AM, ch);
                    encrypter.Append(NZ[indexAM]);
                }
                else if (NZ.Contains(ch))
                {
                    int indexNZ = Array.IndexOf(NZ, ch);
                    encrypter.Append(AM[indexNZ]);
                }
                else if (Regex.IsMatch(c, @"\W"))
                {
                    switch (ch)
                    {
                        case ' ':
                            encrypter.Append('+');
                            break;
                        case ',':
                            encrypter.Append('%');
                            break;
                        case '?':
                            encrypter.Append('#');
                            break;
                        case '.':
                            encrypter.Append('&');
                            break;
                        case '!':
                            encrypter.Append('$');
                            break;
                    }
                }
                else if (char.IsDigit(ch))
                {
                    encrypter.Append(ch);
                }
            }
            return encrypter.ToString();
        }

        static List<string> EstablishCommunication()
        {
            List<string> communication = new List<string>();
            string message = null;
            bool encrypting = false;
            while (true)
            {
                if (encrypting)
                {
                    if (message != "")
                    {
                        communication.Add(
                        EncryptMessage(ReverseMessage(message)));
                        messageCount++;
                    }
                }
                if (message == "start" || message == "START")
                    encrypting = true;
                message = Console.ReadLine();
                if (message == "END" || message == "end")
                    break;
            }
            return communication;
        }

        static void PrintCommunication(List<string> com,
            int count)
        {
            if (messageCount != 0)
            {
                Console.WriteLine("Total number of messages: " + count);
                foreach (string message in com)
                {
                    Console.WriteLine(message);
                }
            }
            else
                Console.WriteLine("No messages sent.");
        }

        static void Main(string[] args)
        {
            PrintCommunication(EstablishCommunication(), messageCount);
        }
    }
}
