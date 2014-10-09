using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem01Customer
{
    public class Payment
    {
        public Payment(string productName, decimal price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public string ProductName  { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            string payments = String.Format("\nProduct: {0} -> {1}lv", this.ProductName, this.Price);
            return payments;
        }
    }
}
