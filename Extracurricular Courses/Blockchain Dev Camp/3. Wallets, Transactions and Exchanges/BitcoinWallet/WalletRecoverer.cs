using HBitcoin.KeyManagement;
using NBitcoin;
using System;
using System.IO;

namespace BitcoinWallet
{
    public class WalletRecoverer
    {
        private const string WalletsDir = ".\\Wallets";

        public void RecoverWallet()
        {
            this.PrintInstructions();

            this.RecoverWallet(this.GetRecoveryObject());
        }

        private void PrintInstructions()
        {
            Console.WriteLine("The wallet cannot check if your password is correct.");
            Console.WriteLine("If you supply an incorrect password, " +
                "a wallet will be created with the mnemonic/password pair.");
        }

        private RecoveryObject GetRecoveryObject()
        {
            var recoveryObject = new RecoveryObject();

            Console.Write("Enter password: ");

            recoveryObject.Password = Console.ReadLine();

            Console.Write("Enter mnemonic phrase: ");

            recoveryObject.Mnemonic = new Mnemonic(Console.ReadLine());

            Console.Write("Enter date: (yyyy-MM-dd): ");

            recoveryObject.Date = DateTime.Parse(Console.ReadLine());

            return recoveryObject;
        }

        private void RecoverWallet(RecoveryObject recoveryObject)
        {
            var randGen = new Random();
            var walletName = $"RecoveredWallet{randGen.Next()}";
            var walletPath = Path.Combine(WalletsDir, walletName + ".json");
            var safe = Safe.Recover(
                recoveryObject.Mnemonic, 
                recoveryObject.Password, 
                walletPath, 
                Network.TestNet, 
                recoveryObject.Date);

            Console.WriteLine($"Wallet {walletName} successfully recovered.");
        }

        private struct RecoveryObject
        {
            public RecoveryObject(string password, string mnemonic, DateTime date)
            {
                this.Password = password;
                this.Mnemonic = new Mnemonic(mnemonic);
                this.Date = date;
            }

            public string Password { get; set; }

            public Mnemonic Mnemonic { get; set; }

            public DateTime Date { get; set; }
        }
    }
}
