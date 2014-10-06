using System;
using System.Collections;

namespace Problem01Shapes
{
    class Problem01
    {
        static void Main()
        {
            IShape[] shapes = new IShape[]
            {
                new Rectangle(5.45, 3.05),
                new Triangle(5, 3.75, 4),
                new Circle(2.5)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine("{0} area is: {1:F3}", shape.GetType().Name, shape.CalculateArea());
                Console.WriteLine("{0} perimeter is: {1:F3}", shape.GetType().Name, shape.CalculatePerimeter());
                Console.WriteLine();
            }
        }
    }
}