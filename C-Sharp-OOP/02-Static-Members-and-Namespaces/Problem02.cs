using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem01Point3D;

namespace Problem02DistanceCalculator
{
    static class DistanceCalculator
    {
        public static double CalculateDistance(Point3D firstPoint, Point3D secondPoint)
        {
            double produceX = firstPoint.CoordinateX - secondPoint.CoordinateX;
            double produceY = firstPoint.CoordinateY - secondPoint.CoordinateY;
            double produceZ = firstPoint.CoordinateZ - secondPoint.CoordinateZ;
            double distance = Math.Sqrt(Math.Pow(produceX, 2) + Math.Pow(produceY, 2) + Math.Pow(produceZ, 2));
            return distance;
        }
    }

    class Problem02
    {
        static void Main(string[] args)
        {
            Point3D point1 = new Point3D(10, 20.5, 35);
            Point3D point2 = new Point3D(100, 12, 23.5);

            Console.WriteLine("Point1\n" + point1);
            Console.WriteLine("Point2\n" + point2);

            double result = DistanceCalculator.CalculateDistance(point1, point2);
            Console.WriteLine("Distance between Point1 and Point2 is: " + result);
        }
    }
}
