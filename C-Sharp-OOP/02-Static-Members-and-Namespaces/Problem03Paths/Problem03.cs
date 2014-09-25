using System;
using Problem01Point3D;
using System.IO;
using System.Text.RegularExpressions;

namespace Problem03Paths
{
    class Problem03
    {
        static void Main(string[] args)
        {
            Point3D point1 = new Point3D(1.1, 2.2, 3.3);
            Point3D point2 = new Point3D(4.4, 5.5, 6.6);
            Point3D point3 = new Point3D(7.7, 8.8, 9.9);
            Point3D[] points = new Point3D[] { point1, point2, point3 };

            Path3D pathPoints = new Path3D(points);

            // Save to file points1.txt
            Console.WriteLine("Save path of points to file points.txt\n");
            Storage.savePaths("../../points.txt", pathPoints);

            // Load from file points1.txt
            Console.WriteLine("Load path of points from file points.txt:");
            Storage.loadPaths("../../points.txt");
            Console.WriteLine();

            // Load from file pointsOld.txt
            Console.WriteLine("Load path of points from file pointsOld.txt:");
            Storage.loadPaths("../../pointsOld.txt");
        }
    }
}