using NBitcoin;

namespace BitcoinWallet
{
    public class OutgoingCredentials : Credentials
    {
        public string TransactionId { get; set; }

        public BitcoinExtKey PrivateKey { get; set; }
    }
}
