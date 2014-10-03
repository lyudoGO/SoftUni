using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem04CompanyHierarchy
{
    class Customer : Person
    {
        private decimal purchaseAmount;

        public Customer(uint id, string firstName, string lastName, decimal purchaseAmount) 
            : base(id, firstName, lastName)
        {
            this.PurchaseAmount = purchaseAmount;
        }

        public decimal PurchaseAmount 
        {
            get { return this.purchaseAmount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Net purchase amount cannot be negative!");
                }
                this.purchaseAmount = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Net purchase amount: {0}", this.purchaseAmount);
        }
    }
}
