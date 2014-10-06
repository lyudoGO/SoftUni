using System;

namespace Problem02BankKurtovoKonare
{
    class Problem02
    {
        static void Main()
        {
            Customer baiIvan = new IndividualCustomer("Bai Ivan");
            Customer argus = new CompanieCustomer("Argus ltd");
            Customer kakaMinka = new IndividualCustomer("Kaka Minka");

            Account baiIvanDeposit = new DepositAccount(baiIvan, 1000M, 2.75);
            Account baiIvanMortgage = new MortgageAccount(baiIvan, 1000M, 2.75);
            Account argusAccount = new MortgageAccount(argus, 10000M, 3.2);
            Account kakaMinkaAccount = new LoanAccount(kakaMinka, 2000M, 5.5);
            
            Console.WriteLine("{0} deposit account is {1}lv, after 12 months and {2}% interset per/month his balance is {3:F2}lv",                                                    baiIvanDeposit.Customer.Name, baiIvanDeposit.Balance, baiIvanDeposit.Interest, 
                              baiIvanDeposit.CalculateInterestRate(12));
            Console.WriteLine("{0} deposit account is {1}lv, he withdraw 500 lv balance left is {3:F2}lv", 
                              baiIvanDeposit.Customer.Name, baiIvanDeposit.Balance, baiIvanDeposit.Interest, 
                              baiIvanDeposit.WithdrawSum(500));
            Console.WriteLine("{0} mortgage account is {1}lv, after 12 months and {2}% interset per/month his balance is {3:F2}lv\n",                                                  baiIvanMortgage.Customer.Name, baiIvanMortgage.Balance, baiIvanMortgage.Interest,
                              baiIvanMortgage.CalculateInterestRate(12));

            Console.WriteLine("{0} mortgage account is {1}lv, after 12 months and {2}% interset per/month his balance is {3:F2}lv",                                                    argusAccount.Customer.Name, argusAccount.Balance, argusAccount.Interest,
                              argusAccount.CalculateInterestRate(12));
            Console.WriteLine("{0} mortgage account is {1}lv, after 24 months and {2}% interset per/month his balance is {3:F2}lv\n",                                                argusAccount.Customer.Name, argusAccount.Balance, argusAccount.Interest,
                              argusAccount.CalculateInterestRate(24));

            Console.WriteLine("{0} loan account is {1}lv, after 12 months and {2}% interset per/month her balance is {3:F2}lv\n",                                               kakaMinkaAccount.Customer.Name, kakaMinkaAccount.Balance, kakaMinkaAccount.Interest,
                              kakaMinkaAccount.CalculateInterestRate(12));
        }
    }
}
 