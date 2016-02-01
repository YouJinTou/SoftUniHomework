using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Client.Tests
{
    [TestClass()]
    public class AccountTests
    {
        [TestMethod()]
        public void TestAccountNull()
        {
            try
            {
                Account.WithdrawFunds("2", "2", 2);
                Assert.Fail("Caught account null exception.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [TestMethod()]
        public void TestIncorrectPIN()
        {
            try
            {
                Account.WithdrawFunds("1", "0987654321", 100);
                Assert.Fail("Caught incorrect PIN exception.");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }           
        }

        [TestMethod()]
        public void TestIncorrectCardNumber()
        {
            try
            {
                Account.WithdrawFunds("4321", "222222", 100);
                Assert.Fail("Caught incorrect card number exception.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [TestMethod()]
        public void TestSubzeroAmount()
        {
            try
            {
                Account.WithdrawFunds("4321", "0987654321", -2);
                Assert.Fail("Caught subzero amount exception.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [TestMethod()]
        public void TestInsufficientFunds()
        {
            try
            {
                Account.WithdrawFunds("4321", "0987654321", 2000);
                Assert.Fail("Caught incorrect card number exception.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // Fails as it cannot find the connection string, even though it's there.
        // I don't know how to fix this
        [TestMethod()]
        public void TestSuccessfulWithdrawal()
        {            
            Account.WithdrawFunds("4444", "9182312312", 2133);
        }
    }
}