using System;

class OddOrEvenIntegers
{
    static void Main()
    {
        int number = Int32.Parse(Console.ReadLine());
        bool isOdd = number % 2 != 0;
        Console.WriteLine(isOdd);
    }
}

