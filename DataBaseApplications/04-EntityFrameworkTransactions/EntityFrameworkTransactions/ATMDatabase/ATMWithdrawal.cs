// Problem 4.	ATM Database
// Suppose you are creating a simple engine for an ATM machine. 
// Create a new database "ATM" in SQL Server to hold the accounts of the cardholders and the balance (money) for each account. 
// Add a new table CardAccounts with the following fields:
// •	Id – int
// •	CardNumber – char(10)
// •	CardPIN – char(4)
// •	CardCash – money
// Add a few sample records in the table. Submit as solution the SQL script for your database.
// Problem 5.	Transactional ATM Withdrawal
// Using transactional logic in Entity Framework write a method that withdraws money (for example $200) from given account. 
// The withdrawal is successful when the following steps are completed successfully:
// Step 1.	Check if the given CardPIN and CardNumber are valid. Throw an exception if not.
// Step 2.	Check if the amount on the account (CardCash) is bigger than the requested sum (in our example $200). Throw an exception if not.
// Step 3.	The ATM machine pays the required sum (e.g. $200) and stores in the table CardAccounts the new amount (CardCash = CardCash - 200).
// Put the above steps in explicit transaction that is started before the first step and is committed after the last step. 
// Think why the isolation level needs to be set to “repeatable read”.

namespace ATMDatabase
{
    using System;
    using System.Linq;
    using System.Data;

    public class ATMWithdrawal
    {
        // You shoud first execute script sql_script_ATM.sql
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
                                currentEntity.CardCach = currentEntity.CardCach - money;

                                context.SaveChanges();
                                Console.WriteLine("You have got your money!Amount after withdraw {0}!", currentEntity.CardCach);
                            }
                 
                        }

                        dbContextTransaction.Commit();
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        Console.WriteLine("Transaction cancled!\nError occured: {0}", e.Message);
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