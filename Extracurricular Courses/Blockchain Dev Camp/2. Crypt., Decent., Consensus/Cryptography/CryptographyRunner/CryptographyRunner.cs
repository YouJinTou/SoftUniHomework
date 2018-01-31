using Cryptography;
using System;

namespace CryptographyRunner
{
    public class CryptographyRunner
    {
        private const string PrivateKeyHexHash = "0450863AD64A87AE8A2FE83C1AF1A8403CB53F53E486D8511DAD8A04887E5B23522CD470243453A299FA9E77237716103ABC11A1DF38855ED6F2EE187E9C582BA6";

        public static void Main(string[] args)
        {
            PrintSha256Result();

            Console.WriteLine(new string('-', 50));

            PrintBitcoinAddress();
        }

        private static void PrintSha256Result()
        {
            var sha256Hasher = new Sha256Hasher();
            var hashedString = sha256Hasher.GetSha256Hash("Hello_World");

            Console.WriteLine($"Hello_World SHA256 hash: {hashedString}");
        }

        private static void PrintBitcoinAddress()
        {
            var bitcoinAddressGenerator = new BitcoinAddressGenerator();
            var bitcoinAddress = bitcoinAddressGenerator.GetBitcoinAddress(PrivateKeyHexHash, 0);

            Console.WriteLine(bitcoinAddress.ToString());
        }
    }
}
