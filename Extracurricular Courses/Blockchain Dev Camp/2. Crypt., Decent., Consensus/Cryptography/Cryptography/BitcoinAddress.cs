using System.Text;

namespace Cryptography
{
    public class BitcoinAddress
    {
        public string PublicKeyHex { get; set; }

        public string PublicKeySha { get; set; }

        public string PublicKeyRipe { get; set; }

        public string PublishHash { get; set; }

        public string PublicHashHash { get; set; }

        public string Checksum { get; set; }

        public string Address { get; set; }

        public string HumanReadableAddress { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Public Key: {PublicKeyHex}");
            sb.AppendLine($"SHA Public Key: {PublicKeySha}");
            sb.AppendLine($"Ripe SHA Public Key: {PublicKeyRipe}");
            sb.AppendLine($"Public Hash: {PublishHash}");
            sb.AppendLine($"Public Hash Hash: {PublicHashHash}");
            sb.AppendLine($"Checksum: {Checksum}");
            sb.AppendLine($"Address: {Address}");
            sb.AppendLine($"Human-readable address: {HumanReadableAddress}");

            return sb.ToString();
        }
    }
}
