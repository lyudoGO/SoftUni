namespace Problem02BankKurtovoKonare
{
    class LoanAccount : Account
    {
        public LoanAccount(Customer customer, decimal balance, double interest) 
            : base(customer, balance, interest)
        {

        }

        public override decimal CalculateInterestRate(int periodMonths)
        {
            int currentPeriodMonths = 0;
            if (this.Customer.GetType().Name == "IndividualCustomer")
            {
                if (periodMonths <= 3)
                {
                    return 0;
                }
                else 
                {
                    currentPeriodMonths = periodMonths - 3;
                }
                
            }

            if (this.Customer.GetType().Name == "CompanieCustomer")
            {
                if (periodMonths <= 2)
                {
                    return 0;
                }
                else
                {
                    currentPeriodMonths = periodMonths - 2;
                }
                
            }

            return base.CalculateInterestRate(currentPeriodMonths);
        }
    }
}
