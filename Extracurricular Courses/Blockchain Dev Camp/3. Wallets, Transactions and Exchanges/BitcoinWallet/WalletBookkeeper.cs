using NBitcoin;
using QBitNinja.Client;
using System;

namespace BitcoinWallet
{
    public class WalletBookkeeper
    {
        private const string WalletsDir = ".\\Wallets";

        public void ShowBalance()
        {
            this.ShowBalance(Wallet.GetCredentials());
        }

        public void ShowHistory()
        {
            this.ShowHistory(Wallet.GetCredentials());
        }

        private void ShowBalance(Credentials credentials)
        {
            if (!Wallet.VerifyExists(credentials.Password, credentials.WalletName))
            {
                Console.WriteLine("Invalid wallet name or password.");

                return;
            }

            var client = new QBitNinjaClient(Network.TestNet);
            var totalBalance = 0.0m;
            var balance = client.GetBalance(
                BitcoinAddress.Create(credentials.Address), true).Result;

            foreach (var op in balance.Operations)
            {
                foreach (var coin in op.ReceivedCoins)
                {
                    var moneyAmount = (Money)coin.Amount;
                    var decimalAmount = moneyAmount.ToDecimal(MoneyUnit.BTC);
                    totalBalance += decimalAmount;
                }
            }

            Console.WriteLine($"{credentials.Address} balance: {totalBalance}");
        }

        private void ShowHistory(Credentials credentials)
        {
            if (!Wallet.VerifyExists(credentials.Password, credentials.WalletName))
            {
                Console.WriteLine("Invalid wallet name or password.");

                return;
            }

            var client = new QBitNinjaClient(Network.TestNet);

            this.PrintReceivedCoins(client, credentials);

            this.PrintSpentCoints(client, credentials);
        }

        private void PrintReceivedCoins(QBitNinjaClient client, Credentials credentials)
        {
            var coinsReceived = client.GetBalance(
                            BitcoinAddress.Create(credentials.Address), true).Result;
            var header = "---- COINS RECEIVED ----";

            Console.WriteLine(header);

            foreach (var entry in coinsReceived.Operations)
            {
                foreach (var coin in entry.ReceivedCoins)
                {
                    var moneyAmount = (Money)coin.Amount;

                    Console.WriteLine(
                        $"Transaction ID: {coin.Outpoint}; " +
                        $"Received coins: {moneyAmount.ToDecimal(MoneyUnit.BTC)}");
                }
            }

            Console.WriteLine(new string('-', header.Length));
        }

        private void PrintSpentCoints(QBitNinjaClient client, Credentials credentials)
        {
            var coinsSpent = client.GetBalance(
                            BitcoinAddress.Create(credentials.Address), false).Result;
            var header = "---- COINS SPENT ----";

            Console.WriteLine(header);

            foreach (var entry in coinsSpent.Operations)
            {
                foreach (var coin in entry.SpentCoins)
                {
                    var moneyAmount = (Money)coin.Amount;

                    Console.WriteLine(
                        $"Transaction ID: {coin.Outpoint}; " +
                        $"Received coins: {moneyAmount.ToDecimal(MoneyUnit.BTC)}");
                }
            }

            Console.WriteLine(new string('-', header.Length));
        }
    }
}
