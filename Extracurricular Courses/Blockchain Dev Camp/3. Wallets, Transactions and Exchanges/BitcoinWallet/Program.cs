using System;
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
                        var walletRecoverer = new WalletRecoverer();

                        walletRecoverer.RecoverWallet();

                        break;
                    case Operation.Balance:
                        {
                            var walletBookkeeper = new WalletBookkeeper();

                            walletBookkeeper.ShowBalance();

                            break;
                        }
                    case Operation.History:
                        {
                            var walletBookkeeper = new WalletBookkeeper();

                            walletBookkeeper.ShowHistory();

                            break;
                        }
                    case Operation.Index:
                        var walletIndex = new WalletIndex();

                        walletIndex.GetWalletAddresses();

                        break;
                    case Operation.Send:
                        var walletOperator = new WalletOperator();

                        walletOperator.SendCoins();

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
            do
            {
                Console.WriteLine($"Enter operation: {string.Join(", ", Operations)}");

                if (Enum.TryParse(Console.ReadLine().ToLower().Trim(), true, out Operation input))
                {
                    return input;
                }
            } while (true);
        }
    }
}
