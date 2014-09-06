using System;

class ComparingFloats
{
    static void Main()
    {
        double numberA = double.Parse(Console.ReadLine());
        double numberB = double.Parse(Console.ReadLine());
        double eps = 0.000001;
        Console.WriteLine((numberB - numberA) < eps);
    }
}

