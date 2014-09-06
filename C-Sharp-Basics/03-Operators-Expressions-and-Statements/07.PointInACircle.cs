using System;

class PointInACircle
{
    static void Main()
    {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        bool isInCircle = x*x + y*y <= 4;
        Console.WriteLine(isInCircle);
    }
}

