using System;

class Four_DigitNumber
{
    static void Main()
    {
        int numberAbcd = Int32.Parse(Console.ReadLine());
        int digitA = numberAbcd / 1000;
        int digitB = (numberAbcd / 100) % 10;
        int digitC = (numberAbcd / 10) % 10;
        int digitD = numberAbcd % 10;
        int sum = digitA + digitB + digitC + digitD;
        int reversedNumber = 1000 * digitD + 100 * digitC + 10 * digitB + digitA;
        int lastDigitNumber = 1000 * digitD + 100 * digitA + 10 * digitB + digitC;
        int secondThirdNumber = 1000 * digitA + 100 * digitC + 10 * digitB + digitD;
        Console.WriteLine("Sum of digit is: {0}", sum);
        Console.WriteLine("Reversed order of digit is: {0}", reversedNumber);
        Console.WriteLine("Last digit in front: {0}", lastDigitNumber);
        Console.WriteLine("Second and third digits exchanged: {0}", secondThirdNumber);

    }
}

