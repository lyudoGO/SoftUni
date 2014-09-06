using System;

class PointInsideCircleOutsideRectangle
{
    static void Main()
    {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        double x1 = x-1;
        double y1 = y-1;
        
        bool isInCircle = Math.Sqrt((x1 * x1) + (y1 * y1)) <= 1.5;
        bool isOutRectangle = x < -1 || x > 5 || y > 1 || y < -1;
        bool isInCircleOutRectangle = isInCircle && isOutRectangle;
        if (isInCircleOutRectangle)
            Console.WriteLine("yes");
        else
            Console.WriteLine("no");
              
    }
}

