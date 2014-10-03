using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem04CompanyHierarchy
{
    class Sale
    {
        private string productName;
        private DateTime date;
        private decimal price;

        public Sale(string productName, DateTime date, decimal price)
        {
            this.ProductName = productName;
            this.Date = date;
            this.Price = price;
        }

        public string ProductName 
        {
            get { return this.productName; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("The product name cannot be empty and must be at least 3 characters!");
                }
                if (!Regex.IsMatch(value, @"^[a-zA-Z0-9\s]+$") || !char.IsUpper(value, 0))
                {
                    throw new FormatException("The product name must be only latin letters and start with capital letter!");
                }
                this.productName = value;
            }
        }

        public DateTime Date 
        {
            get { return this.date; }
            set { this.date = value; } 
        }

        public decimal Price 
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The price of product cannot be negative!");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Product: {0}; Date of sale: {1}; Price: {2}LV", this.productName, this.date.ToString("d"), this.price);
        }
    }
}
