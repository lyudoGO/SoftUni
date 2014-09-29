using System;

namespace Problem02FractionCalculator
{
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
            //Fraction fraction3 = new Fraction();
            //fraction3.Numerator = 92233720368547758;
            //fraction3.Denominator = 0;
        }
    }
}