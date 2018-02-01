using NBitcoin;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinWallet
{
    public class WalletRecoverer
    {
        public void RecoverWallet()
        {
            this.PrintInstructions();


        }

        private void PrintInstructions()
        {
            Console.WriteLine("The wallet cannot check if your password is correct.");
            Console.WriteLine("If you supply an incorrect password, " +
                "a wallet will be created with the mnemonic/password pair.");
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
