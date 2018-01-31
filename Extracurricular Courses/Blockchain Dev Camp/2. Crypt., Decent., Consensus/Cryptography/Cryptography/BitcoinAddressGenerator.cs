using System;
using System.Globalization;
using System.Numerics;
using System.Security.Cryptography;

namespace Cryptography
{
    public class BitcoinAddressGenerator
    {
        private const string Base58Alphabet = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";

        public BitcoinAddress GetBitcoinAddress(string publicKeyHexHash, byte bitcoinNetwork)
        {
            var publicKey = this.HexToByte(publicKeyHexHash);
            var publicKeySha = this.ToSha256(publicKey);
            var publicKeyRipe = this.ToRipeMd160(publicKeySha);
            var preHashWithNetwork = this.AppendBitcoinNetwork(publicKeyRipe, bitcoinNetwork);
            var publicHash = this.ToSha256(preHashWithNetwork);
            var publicHashHash = this.ToSha256(publicHash);
            var address = this.GetAddress(preHashWithNetwork, publicHashHash);

            var bitcointAddress = new BitcoinAddress
            {
                PublicKeyHex = this.ByteToHex(publicKey),
                PublicKeySha = this.ByteToHex(publicKeySha),
                PublicKeyRipe = this.ByteToHex(publicKeyRipe),
                PublishHash = this.ByteToHex(publicHash),
                PublicHashHash = this.ByteToHex(publicHashHash),
                Checksum = this.ByteToHex(publicHashHash).Substring(0, 4),
                Address = this.ByteToHex(address),
                HumanReadableAddress = this.ToBase58(address)
            };

            return bitcointAddress;
        }

        private string ToBase58(byte[] bytes)
        {
            var base58String = string.Empty;
            BigInteger encodeSize = Base58Alphabet.Length;
            BigInteger bytesAsInt = 0;

            for (int i = 0; i < bytes.Length; i++)
            {
                bytesAsInt = bytesAsInt * 256 + bytes[i];
            }

            while (bytesAsInt > 0)
            {
                int remainder = (int)(bytesAsInt % encodeSize);
                bytesAsInt /= encodeSize;
                base58String = Base58Alphabet[remainder] + base58String;
            }

            for (int i = 0; i < bytes.Length && bytes[i] == 0; ++i)
            {
                base58String = Base58Alphabet[0] + base58String;
            }

            return base58String;
        }

        private byte[] HexToByte(string hex)
        {
            if (hex.Length % 2 != 0)
            {
                throw new ArgumentException(
                    "Invalid HEX string length. Must be a multiple of two.");
            }

            var bytes = new byte[hex.Length / 2];

            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = byte.Parse(
                    hex.Substring(i * 2, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return bytes;
        }

        private string ByteToHex(byte[] bytes)
        {
            return BitConverter.ToString(bytes);
        }

        private byte[] ToSha256(byte[] bytes)
        {
            var sha256Managed = new SHA256Managed();

            return sha256Managed.ComputeHash(bytes);
        }

        private byte[] ToRipeMd160(byte[] bytes)
        {
            var ripeManaged = new RIPEMD160Managed();

            return ripeManaged.ComputeHash(bytes);
        }

        private byte[] AppendBitcoinNetwork(byte[] ripeHash, byte network)
        {
            var hashWithNetwork = new byte[ripeHash.Length + 1];
            hashWithNetwork[0] = network;

            Array.Copy(ripeHash, 0, hashWithNetwork, 1, ripeHash.Length);

            return hashWithNetwork;
        }

        private byte[] GetAddress(byte[] preHashWithNetwork, byte[] publicHashHash)
        {
            var bytes = new byte[preHashWithNetwork.Length + 4];

            Array.Copy(preHashWithNetwork, bytes, preHashWithNetwork.Length);
            Array.Copy(publicHashHash, 0, bytes, preHashWithNetwork.Length, 4);

            return bytes;
        }
    }
}
