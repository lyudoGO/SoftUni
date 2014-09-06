
using System;

    class ThirdDigitIs7
    {
        static void Main()
        {
            int number = Int32.Parse(Console.ReadLine());
            int tirthDigit = (number / 100) % 10;
            bool isThirdSeven = tirthDigit == 7;
            Console.WriteLine(isThirdSeven);
        }
    }

