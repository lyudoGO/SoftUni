using System;

namespace Problem02FractionCalculator
{
    struct Fraction
    {
        private long numerator;
        private long denominator;

        public Fraction(long numerator, long denominator) : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public long Numerator
        {
            get { return this.numerator; }
            set { this.numerator = value;}
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
            decimal result = this.Numerator / this.Denominator;
            return string.Format("{0}", result);
        }
    }

    class Problem02
    {
        static void Main(string[] args)
        {
            Fraction fraction1 = new Fraction(22, 7);
            Fraction fraction2 = new Fraction(40, 4);
            Fraction result = fraction1 + fraction2;
            Console.WriteLine(result.Numerator);
            Console.WriteLine(result.Denominator);
            Console.WriteLine(result);

            // Throw excaption
            Fraction fraction3 = new Fraction();
            fraction3.Numerator = 92233720368547758;
            fraction3.Denominator = 0;
        }
    }
}