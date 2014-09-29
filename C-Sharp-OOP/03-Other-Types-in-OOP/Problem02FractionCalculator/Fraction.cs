using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem02FractionCalculator
{
    struct Fraction
    {
        private long numerator;
        private long denominator;

        public Fraction(long numerator, long denominator)
            : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public long Numerator
        {
            get { return this.numerator; }
            set { this.numerator = value; }
        }

        public long Denominator
        {
            get { return this.denominator; }
            set
            {
                if (value == 0)
                {
                    throw new DivideByZeroException("The denominator cannot be zero!You cannot division by zero!");
                }

                this.denominator = value;
            }
        }

        public static Fraction operator +(Fraction num1, Fraction num2)
        {
            long numeratorResult = num1.Numerator * num2.Denominator + num2.Numerator * num1.Denominator;
            long denominatorResult = num1.Denominator * num2.Denominator;
            return new Fraction(numeratorResult, denominatorResult);
        }

        public static Fraction operator -(Fraction num1, Fraction num2)
        {
            long numeratorResult = num1.Numerator * num2.Denominator - num2.Numerator * num1.Denominator;
            long denominatorResult = num1.Denominator * num2.Denominator;
            return new Fraction(numeratorResult, denominatorResult);
        }

        public override string ToString()
        {
            decimal result = (decimal)this.Numerator / this.Denominator;
            return string.Format("{0}", result);
        }
    }
}