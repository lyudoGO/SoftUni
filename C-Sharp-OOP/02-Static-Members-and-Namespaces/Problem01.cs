using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01Point3D
{
    public class Point3D
    {
        private double coordinateX;
        private double coordinateY;
        private double coordinateZ;

        private static readonly Point3D startingPoint;
     
        static Point3D()
        {
            startingPoint = new Point3D(0, 0, 0);
        }

        public static Point3D StartingPoint
        {
            get { return Point3D.startingPoint; }
        }
        
        public Point3D(double coordinateX, double coordinateY, double coordinateZ)
        {
            this.CoordinateX = coordinateX;
            this.CoordinateY = coordinateY;
            this.CoordinateZ = coordinateZ;
        }

        public double CoordinateX
        {
            get { return this.coordinateX; }
            set { this.coordinateX = value; }
        }

        public double CoordinateY
        {
            get { return this.coordinateY; }
            set { this.coordinateY = value; }
        }

        public double CoordinateZ
        {
            get { return this.coordinateZ; }
            set { this.coordinateZ = value; }
        }

        public override string ToString()
        {
            return string.Format("X coord: {0}\nY coord: {1}\nZ coord: {2}\n", this.CoordinateX, this.CoordinateY, this.CoordinateZ);
        }
    }

    class Problem01
    {
        static void Main(string[] args)
        {
            Point3D point1 = new Point3D(12.5, 20, 23.5);
            Point3D point2 = new Point3D(2.5, 3.45, 0.99);
            Console.WriteLine("Point One\n" + point1);
            Console.WriteLine("Point Two\n" + point2);
            Console.WriteLine("Start point\n" + Point3D.StartingPoint);
        }
    }
}