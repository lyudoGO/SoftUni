namespace Problem02BankKurtovoKonare
{
    class MortgageAccount : Account
    {
        public MortgageAccount(Customer customer, decimal balance, double interest) 
            : base(customer, balance, interest)
        {

        }

        public override decimal CalculateInterestRate(int periodMonths)
        {
            int currentPeriodMonths = 0;
            if (this.Customer.GetType().Name == "IndividualCustomer")
            {
                if (periodMonths <= 6)
                {
                    return 0;
                }
                else
                {
                    currentPeriodMonths = periodMonths - 6;
                }

            }

            if (this.Customer.GetType().Name == "CompanieCustomer")
            {
                if (periodMonths <= 12)
                {
                    this.Balance += this.Balance * (decimal)((this.Interest / 2) * periodMonths / 100);
                    return this.Balance;
                }
                else
                {
                    currentPeriodMonths = periodMonths;
                }
            }

            return base.CalculateInterestRate(currentPeriodMonths);
        }
    }
}
