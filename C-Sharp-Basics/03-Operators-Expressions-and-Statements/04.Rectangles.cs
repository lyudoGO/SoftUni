using System;

class Rectangles
{
    static void Main(string[] args)
    {
        double weigthRectangle = double.Parse(Console.ReadLine());
        double heigthRectangle = double.Parse(Console.ReadLine());
        double perimeterRectangle = 2 * weigthRectangle + 2 * heigthRectangle;
        double areaRectangle = weigthRectangle * heigthRectangle;
        Console.WriteLine(perimeterRectangle);
        Console.WriteLine(areaRectangle);

    }
}

