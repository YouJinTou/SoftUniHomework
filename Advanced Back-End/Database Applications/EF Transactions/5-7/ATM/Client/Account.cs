using ATM.Data;
using System.Linq;
using System;
using System.Data;
using System.Data.Entity;

namespace Client
{
    public class Account
    {
        public static void WithdrawFunds(string pin, string cardNumber, decimal amount)
        {
            var context = new ATMEntities();

            using (var contextTransaction = context.Database.BeginTransaction(IsolationLevel.RepeatableRead))
            {
                bool isValid = false;
                var account = context.CardAccounts
                    .Where(c => c.CardNumber == cardNumber)
                    .Select(c => new
                    {
                        c.CardNumber,
                        c.CardPIN,
                        c.CardCash
                    })
                    .FirstOrDefault();

                do
                {
                    string failureCode = "";

                    try
                    {
                        if (account == null)
                        {
                            failureCode = "account";
                            throw new Exception("Something went wrong with your data.");
                        }
                        if (account.CardPIN != pin)
                        {
                            failureCode = "pin";
                            throw new Exception("Incorrect PIN.");
                        }
                        if (account.CardCash < amount)
                        {
                            failureCode = "insufficient";
                            throw new Exception("Insufficient funds.");
                        }
                        if (amount <= 0)
                        {
                            failureCode = "zero";
                            throw new Exception("Withdraw amount must be positive.");
                        }
                        if (account.CardNumber == null)
                        {
                            failureCode = "number";
                            throw new Exception("Incorrect card number.");
                        }

                        isValid = true;

                        var accountToUpdate = context.CardAccounts
                            .Where(c => c.CardNumber == cardNumber)
                            .FirstOrDefault();
                        Console.WriteLine("Funds before: " + accountToUpdate.CardCash);

                        var updatedAmount = account.CardCash - amount;
                        accountToUpdate.CardCash = updatedAmount;

                        context.SaveChanges();
                        contextTransaction.Commit();
                        SaveTransaction(cardNumber, DateTime.Now, amount);
                        Console.WriteLine("---Withdrawal successful.---");
                        Console.WriteLine("Funds after: " + accountToUpdate.CardCash);
                    }
                    catch (Exception e)
                    {
                        isValid = false;

                        Console.WriteLine(e.Message);

                        switch (failureCode)
                        {
                            case "account":
                                Console.Write("PIN: ");
                                pin = Console.ReadLine();

                                Console.Write("Card number: ");
                                cardNumber = Console.ReadLine();

                                Console.Write("Amount: ");
                                amount = decimal.Parse(Console.ReadLine());
                                break;
                            case "pin":
                                Console.Write("PIN: ");
                                pin = Console.ReadLine();
                                break;
                            case "insufficient":
                                Console.Write("New amount: ");
                                amount = decimal.Parse(Console.ReadLine());
                                break;
                            case "zero":
                                Console.Write("New amount: ");
                                amount = decimal.Parse(Console.ReadLine());
                                break;
                            case "number":
                                Console.Write("Card number: ");
                                cardNumber = Console.ReadLine();
                                break;
                        }

                    }

                } while (!isValid);
            }
        }

        private static void SaveTransaction(string cardNumber, DateTime timestamp, decimal amount)
        {
            var context = new ATMEntities();

            using (context)
            {
                var log = new TransactionLog()
                {
                    CardNumber = cardNumber,
                    TransactionDate = timestamp,
                    Amount = amount
                };

                context.TransactionLogs.Add(log);
                context.SaveChanges();
            }
        }
    }
}
