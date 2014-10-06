namespace Problem02BankKurtovoKonare
{
    public abstract class Account : IDepositable, IWithdrawable
    {
        private Customer customer;
        private decimal balance;
        private double interest;

        public Account(Customer customer, decimal balance, double interest)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.Interest = interest;
        }

        public Customer Customer
        {
            get { return this.customer; }

            set
            {
                this.customer = value;
            }
        }

        public decimal Balance
        {
            get { return this.balance; }

            protected set
            {
               this.balance = value;
            }
        }

        public double Interest
        {
            get { return this.interest; }

            set
            {
               this.interest = value;
            }
        }

        public virtual decimal CalculateInterestRate(int periodMonths)
        {
            this.balance += this.balance * (decimal)(this.interest * periodMonths / 100);
            return this.balance;
        }

        public virtual decimal WithdrawSum(decimal sum)
        {
            throw new System.NotImplementedException();
        }
    }
}