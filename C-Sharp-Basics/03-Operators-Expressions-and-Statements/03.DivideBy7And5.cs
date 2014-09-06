using System;

class DivideBy7And5
{
    static void Main()
    {
        int number = Int32.Parse(Console.ReadLine());
        bool numberDivideTo5 = number % 5 == 0;
        bool numberDivideTo7 = number % 7 == 0;
        Console.WriteLine(numberDivideTo5 && numberDivideTo7);
    }
}

