using System;

namespace BitcoinWallet
{
    public class WalletIndex
    {
        public void GetWalletAddresses()
        {
            Console.Write("Wallet name: ");

            var walletName = Console.ReadLine();

            Console.Write("Password: ");

            var password = Console.ReadLine();

            this.GetAddresses(walletName, password);
        }

        private void GetAddresses(string walletName, string password)
        {
            try
            {
                var safe = Wallet.LoadWalletLocal(password, walletName);

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(safe.GetAddress(i));
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid wallet name or password.");

                return;
            }
        }
    }
}
