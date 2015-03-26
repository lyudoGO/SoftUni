//Problem 7.	* Unit Tests for the ATM
//Design and implement unit tests for the ATM withdrawal operation with 100% code coverage.
//Your tests should cover all major cases and should assert for each case that the values in 
//the CardAccounts and TransactionHistory tables are correct.

namespace ATMDatabase.Tests
{
    using System;
    using System.Linq;
    using System.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ATMDatabase;
    using ATMDatabseHistory;

    [TestClass]
    public class ATMUnitTest
    {
        private ATMEntities context;
        private string cardNumber;
        private string cardPin;
        private decimal money;
        private int countEntity;

        [TestInitialize]
        public void InitializeContext()
        {
            context = new ATMEntities();
            cardNumber = "3333333333";
            cardPin = "3333";
            money = 1000M;
            countEntity = context.CardAccounts.Count(c => c.CardNumber == cardNumber);
            if (countEntity == 0)
            {
                context.CardAccounts.Add(new CardAccount()
                {
                    CardNumber = cardNumber,
                    CardPIN = cardPin,
                    CardCach = money
                });
                context.SaveChanges();
            }
            else
            {
                context.CardAccounts.First(c => c.CardNumber == cardNumber).CardCach = money;
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void ATMWithdrawShoudCheckIsValidCardNumber()
        {
            ATMWithdrawal.WithdrawMoney(cardNumber, cardPin, 0M);

            int count = context.CardAccounts.Count(c => c.CardNumber == cardNumber);
            Assert.IsTrue(count == 1, "There is no card with this number!");
        }

        [TestMethod]
        public void ATMWithdrawShoudCheckIsValidPinNumber()
        {
            ATMWithdrawal.WithdrawMoney(cardNumber, cardPin, 0M);

            int count = context.CardAccounts.Count(c => c.CardNumber == cardNumber && c.CardPIN == cardPin);
            Assert.IsTrue(count == 1, "There is no card with this PIN!");
        }

        [TestMethod]
        public void ATMWithdrawShoudWithdrawMoney()
        {
            ATMWithdrawal.WithdrawMoney(cardNumber, cardPin, 100M);
            var testContext = new ATMEntities();
            var newCash = testContext.CardAccounts.First(c => c.CardNumber == cardNumber).CardCach;
            Assert.AreEqual(900M, newCash);
        }

        [TestMethod]
        public void ATMDatabaseHistoryShoudCheckIsValidCardNumber()
        {
            ATMHistory.WithdrawMoney(cardNumber, cardPin, 0M);

            int count = context.CardAccounts.Count(c => c.CardNumber == cardNumber);
            Assert.IsTrue(count == 1, "There is no card with this number!");
        }

        [TestMethod]
        public void ATMDatabaseHistoryShoudCheckIsValidPinNumber()
        {
            ATMHistory.WithdrawMoney(cardNumber, cardPin, 0M);

            int count = context.CardAccounts.Count(c => c.CardNumber == cardNumber && c.CardPIN == cardPin);
            Assert.IsTrue(count == 1, "There is no card with this PIN!");
        }

        [TestMethod]
        public void ATMDatabaseHistoryShoudWithdrawMoney()
        {
            ATMHistory.WithdrawMoney(cardNumber, cardPin, 100M);
            var testContext = new ATMEntities();
            var newCash = testContext.CardAccounts.First(c => c.CardNumber == cardNumber).CardCach;
            Assert.AreEqual(900M, newCash);
        }

        [TestMethod]
        public void ATMDatabaseHistoryShoudWithdrawMoneyAndSaveHistory()
        {
            ATMHistory.WithdrawMoney(cardNumber, cardPin, 100M);
            var testContext = new ATMEntities();
            var newCash = testContext.CardAccounts.First(c => c.CardNumber == cardNumber).CardCach;
            var newCashTransaction = testContext.TransactionHistories.OrderBy(c => c.TransactionDate).First(c => c.CardNumber == cardNumber).Amount;
            Assert.AreEqual(900M, newCash);
            Assert.AreEqual(900M, newCashTransaction);
        }
    }
}
