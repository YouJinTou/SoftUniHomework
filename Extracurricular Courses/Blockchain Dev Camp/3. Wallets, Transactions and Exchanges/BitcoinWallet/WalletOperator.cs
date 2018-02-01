using HBitcoin.KeyManagement;
using NBitcoin;
using QBitNinja.Client;
using System;
using System.Text;

namespace BitcoinWallet
{
    public class WalletOperator
    {
        private const string WalletsDir = ".\\Wallets";

        public void SendCoins()
        {
            try
            {
                this.SendCoins(this.GetCredentials());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SendCoins(OutgoingCredentials credentials)
        {
            var outpoint = this.GetOutPoint(credentials);
            var recipient = this.GetRecipient();
            var transaction = new Transaction();
            var changeTx = this.GetChangeTx(BitcoinAddress.Create(credentials.Address));
            var amountToSendTx = this.GetAmountToSendTx(BitcoinAddress.Create(recipient));
            var messageTx = this.GetMessageTx();

            transaction.Inputs.Add(new TxIn { PrevOut = outpoint });
            transaction.Outputs.Add(changeTx);
            transaction.Outputs.Add(amountToSendTx);
            transaction.Outputs.Add(messageTx);

            this.SignTransaction(transaction, credentials.PrivateKey);
        }

        private void SignTransaction(Transaction transaction, BitcoinExtKey privateKey)
        {
            transaction.Inputs[0].ScriptSig = privateKey.ScriptPubKey;

            transaction.Sign(privateKey, false);

            var client = new QBitNinjaClient(Network.TestNet);
            var response = client.Broadcast(transaction).Result;

            if (response.Success)
            {
                Console.WriteLine("Transaction sent.");
            }
            else
            {
                Console.WriteLine("Could not send transaction.");
            }
        }

        private OutgoingCredentials GetCredentials()
        {
            var credentails = Wallet.GetCredentials();

            Console.Write("Outpoint (transaction ID): ");

            var transactionId = Console.ReadLine();
            var privateKey = this.GetPrivateKey(credentails);

            return new OutgoingCredentials
            {
                Address = credentails.Address,
                Password = credentails.Password,
                TransactionId = transactionId,
                WalletName = credentails.WalletName,
                PrivateKey = privateKey
            };
        }

        private BitcoinExtKey GetPrivateKey(Credentials credentials)
        {
            Safe safe = null;

            try
            {
                safe = Wallet.LoadWalletLocal(credentials.Password, credentials.WalletName);
            }
            catch (Exception)
            {
                throw new ArgumentException("Invalid wallet name or password.");
            }

            for (int i = 0; i < 10; i++)
            {
                if (safe.GetAddress(i).ToString() == credentials.Address)
                {
                    Console.Write("Enter private key: ");

                    var privateKey = new BitcoinExtKey(Console.ReadLine());

                    if (!privateKey.Equals(safe.FindPrivateKey(safe.GetAddress(i))))
                    {
                        throw new ArgumentException("Wrong private key.");
                    }

                    return privateKey;
                }
            }

            throw new ArgumentException("Could not find private key.");
        }

        private OutPoint GetOutPoint(OutgoingCredentials credentials)
        {
            var client = new QBitNinjaClient(Network.TestNet);
            var balance = client.GetBalance(BitcoinAddress.Create(credentials.Address), false).Result;

            foreach (var op in balance.Operations)
            {
                foreach (var coin in op.ReceivedCoins)
                {
                    if (coin.Outpoint.ToString() == credentials.TransactionId)
                    {
                        return coin.Outpoint;
                    }
                }
            }

            throw new ArgumentException("Could not find transaction to spend.");
        }

        private string GetRecipient()
        {
            Console.Write("Recipient address: ");

            return Console.ReadLine();
        }

        private TxOut GetAmountToSendTx(BitcoinAddress recipientAddress)
        {
            return new TxOut
            {
                Value = new Money(this.GetAmountToSend(), MoneyUnit.BTC),
                ScriptPubKey = recipientAddress.ScriptPubKey
            };
        }

        private decimal GetAmountToSend()
        {
            Console.Write("Amount to send: ");

            return decimal.Parse(Console.ReadLine());
        }

        private TxOut GetChangeTx(BitcoinAddress senderAddress)
        {
            return new TxOut
            {
                Value = new Money(this.GetChange(), MoneyUnit.BTC),
                ScriptPubKey = senderAddress.ScriptPubKey
            };
        }

        private decimal GetChange()
        {
            Console.Write("Change expected: ");

            return decimal.Parse(Console.ReadLine());
        }

        private TxOut GetMessageTx()
        {
            Console.Write("Enter message: ");

            return new TxOut
            {
                Value = Money.Zero,
                ScriptPubKey = TxNullDataTemplate.Instance
                    .GenerateScriptPubKey(Encoding.UTF8.GetBytes(Console.ReadLine()))
            };
        }
    }
}
