using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem04CompanyHierarchy
{
    class SalesEmployee : RegularEmployee
    {
        private IList<Sale> sales;

        public SalesEmployee(uint id, string firstName, string lastName, decimal salary, Department department, List<Sale> sales)
            : base(id, firstName, lastName, salary, department)
        {
            this.Sales = sales;
        }

        public IList<Sale> Sales 
        {
            get { return this.sales; }
            set { this.sales = value; }
        }

        public override string ToString()
        {
            string saleStr = string.Join("\n", this.sales);
            return "\nSaler -> " + base.ToString() + string.Format("\n{0} made sales:\n{1}", this.FirstName, saleStr);
        }
    }
}
    