using System;
using System.Security.Cryptography;
using System.Text;

namespace Runner
{
    class S
    {
        static void Main(string[] args)
        {
            string toHash = "Hello_world";
            string result = GetSha256Hash(toHash);

            Console.WriteLine(result);
        }

        static string GetSha256Hash(string toHash)
        {
            
        }
    }
}
