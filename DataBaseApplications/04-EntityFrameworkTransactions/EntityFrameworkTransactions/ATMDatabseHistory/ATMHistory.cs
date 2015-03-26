// Problem 6.	ATM Transactions History
// Extend the project from the previous exercise and add a new table TransactionHistory with fields
// (Id, CardNumber, TransactionDate, Amount) holding information about all money withdrawals on all accounts.
// Modify the withdrawal logic so that it preserves history in the new table after each successful money withdrawal.

namespace ATMDatabseHistory
{
    using System;
    using System.Data;
    using System.Linq;
    using ATMDatabase;

    public class ATMHistory
    {
        static void Main()
        {
            Console.Write("Please, enter your card number: ");
            string cardNumber = Console.ReadLine();

            Console.Write("Please, enter your PIN: ");
            string pinNumber = Console.ReadLine();

            Console.Write("Please, enter how much money to withdraw: ");
            decimal money = decimal.Parse(Console.ReadLine());

            WithdrawMoney(cardNumber, pinNumber, money);
        }

        public static void WithdrawMoney(string cardNumber, string pinNumber, decimal money)
        {
            using (var context = new ATMEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction(IsolationLevel.RepeatableRead))
                {
                    try
                    {
                        if (CheckIsValid(context, cardNumber, pinNumber))
                        {
                            if (CheckIsHasMoney(context, cardNumber, money))
                            {
                                var currentEntity = context.CardAccounts.First(c => c.CardNumber == cardNumber && c.CardPIN == pinNumber);
                                var historyEntity = context.TransactionHistories;
                                currentEntity.CardCach = currentEntity.CardCach - money;
                                historyEntity.Add(new TransactionHistory()
                                {
                                    CardNumber = currentEntity.CardNumber,
                                    TransactionDate = DateTime.Now,
                                    Amount = currentEntity.CardCach
                                });

                                context.SaveChanges();
                                Console.WriteLine("You have got your money!Amount after withdraw {0}!", currentEntity.CardCach);
                            }
                        }

                        dbContextTransaction.Commit();
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        Console.WriteLine("Transaction cancled!\nError Occured: {0}", e.Message);
                    }
                }
            }
        }

        private static bool CheckIsHasMoney(ATMEntities context, string cardNumber, decimal money)
        {
            var currentEntity = context.CardAccounts.First(c => c.CardNumber == cardNumber);
            if (currentEntity.CardCach >= money)
            {
                return true;
            }

            throw new Exception("You do not have enough money!");
        }

        private static bool CheckIsValid(ATMEntities context, string cardNumber, string pinNumber)
        {
            try
            {
                var currentEntity = context.CardAccounts.First(c => c.CardNumber == cardNumber && c.CardPIN == pinNumber);
            }
            catch (Exception)
            {
                throw new Exception("You're entering a wrong card number or PIN!");
            }

            return true;
        }
    }
}
