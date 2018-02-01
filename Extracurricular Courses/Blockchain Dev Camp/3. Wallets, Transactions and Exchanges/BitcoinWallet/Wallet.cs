using HBitcoin.KeyManagement;
using System;
using System.IO;

namespace BitcoinWallet
{
    public class Wallet
    {
        private const string WalletsDir = ".\\Wallets";

        public static Safe LoadWalletLocal(string password, string walletName)
        {
            var safe = Safe.Load(password, Path.Combine(WalletsDir, walletName + ".json"));

            return safe;
        }

        public static bool VerifyExists(string password, string walletName)
        {
            try
            {
                LoadWalletLocal(password, walletName);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Credentials GetCredentials()
        {
            var credentials = new Credentials();

            Console.Write("Password: ");

            credentials.Password = Console.ReadLine();

            Console.Write("Wallet name: ");

            credentials.WalletName = Console.ReadLine();

            Console.Write("Address: ");

            credentials.Address = Console.ReadLine();

            return credentials;
        }
    }
}
