namespace Problem02BankKurtovoKonare
{
    class DepositAccount : Account
    {
        public DepositAccount(Customer customer, decimal balance, double interest) 
            : base(customer, balance, interest)
        {

        }

        public override decimal CalculateInterestRate(int periodMonths)
        {
            if (this.Balance < 1000)
            {
                return 0;
            }

            return base.CalculateInterestRate(periodMonths);
        }

        public override decimal WithdrawSum(decimal sum)
        {
            this.Balance = this.Balance - sum;
            return this.Balance;
        }
    }
}
