using HBitcoin.KeyManagement;
using NBitcoin;
using System;
using System.IO;
using System.Linq;

namespace BitcoinWallet
{

    public class Program
    {
        private static readonly Operation[] Operations;

        static Program()
        {
            Operations = Enum.GetValues(typeof(Operation))
            .Cast<Operation>()
            .ToArray();
        }

        public static void Main()
        {
            var input = Operation.Create;

            while (input != Operation.Exit)
            {
                switch (input = GetOperation())
                {
                    case Operation.Create:
                        var walletCreator = new WalletCreator();

                        walletCreator.CreateWallet();

                        break;
                    case Operation.Recover:
                        break;
                    case Operation.Balance:
                        break;
                    case Operation.History:
                        break;
                    case Operation.Receive:
                        break;
                    case Operation.Send:
                        break;
                    case Operation.Exit:
                        break;
                    default:
                        break;
                }
            }
        }

        private static Operation GetOperation()
        {
            Operation input;

            do
            {
                Console.WriteLine($"Enter operation: {string.Join(", ", Operations)}");

                Enum.TryParse(Console.ReadLine().ToLower().Trim(), true, out int input);
            } while (!Operations.Contains(input));

            return input;
        }
    }
}
