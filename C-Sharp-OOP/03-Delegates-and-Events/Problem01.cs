using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01InterestCalculator
{
    class InterestCalculator
    {
        public delegate decimal CalculateInterest(decimal sumMoney, double interest, int years);

        private decimal sumMoney;
        private double interest;
        private int years;
        private decimal delegateValue;

        public InterestCalculator(decimal sumMoney, double interest, int years, CalculateInterest d)
        {
            this.SumMoney = sumMoney;
            this.Interest = interest;
            this.Years = years;
            this.DelegateValue = d(sumMoney, interest, years);
        }

        public decimal SumMoney
        {
            get;
            set;
        }

        public double Interest
        {
            get;
            set;
        }

        public int Years
        {
            get;
            set;
        }

        public decimal DelegateValue
        {
            get;
            set;
        }

        public static decimal GetSimpleInterest(decimal sum, double interest, int years)
        {
            interest = interest / 100;
            decimal result = sum * (decimal)(1 + interest * years);
            return result;
        }

        public static decimal GetCompoundInterest(decimal sum, double interest, int years)
        {
            int n = 12;
            interest = interest / 100;
            decimal result = sum * (decimal)Math.Pow((double)(1 + interest / n ), years * n);
            return result;
        }
    }

    class Problem01
    {
        static void Main(string[] args)
        {
            InterestCalculator compound = new InterestCalculator(500M, 5.6, 10, InterestCalculator.GetCompoundInterest);
            Console.WriteLine("Compound interset: {0:0.0000}$", compound.DelegateValue);

            InterestCalculator simple = new InterestCalculator(2500M, 7.2, 15, InterestCalculator.GetSimpleInterest);
            Console.WriteLine("Simple interest: {0:0.0000}$", simple.DelegateValue);
        }
    }
}