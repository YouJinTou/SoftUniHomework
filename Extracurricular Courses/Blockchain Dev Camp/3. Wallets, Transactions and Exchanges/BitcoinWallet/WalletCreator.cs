using HBitcoin.KeyManagement;
using NBitcoin;
using System;
using System.IO;

namespace BitcoinWallet
{
    public class WalletCreator
    {
        private const string WalletsDir = ".\\Wallets";

        public void CreateWallet()
        {
            var network = Network.TestNet;
            var password = this.GetPassword();

            while (true)
            {
                try
                {
                    Console.Write("Wallet name: ");

                    var walletPath = Path.Combine(WalletsDir, Console.ReadLine() + ".json");
                    var safe = Safe.Create(out Mnemonic mnemonic, password, walletPath, network);

                    Console.WriteLine("Wallet created successfully. Keep your keys safe.");
                    Console.WriteLine($"Mnemonic: {mnemonic}");

                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine(
                            $"Address: {safe.GetAddress(i)} -> " +
                            $"Private key: {safe.FindPrivateKey(safe.GetAddress(i))}");
                    }

                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Wallet already exists.");
                }
            }
        }

        private string GetPassword()
        {
            var password = string.Empty;
            var confirmedPassword = string.Empty;

            do
            {
                Console.Write("Password: ");

                password = Console.ReadLine();

                Console.Write("Confirm password: ");

                confirmedPassword = Console.ReadLine();

                if (password != confirmedPassword)
                {
                    Console.WriteLine("Passwords do not match.");
                }
            } while (password != confirmedPassword);

            return password;
        }
    }
}
