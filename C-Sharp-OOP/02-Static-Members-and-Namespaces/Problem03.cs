using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem01Point3D;
using System.IO;
using System.Text.RegularExpressions;

namespace Problem03Paths
{
    class Path3D
    {
        private List<Point3D> paths = new List<Point3D>();

        public Path3D()
        {
        }

        public Path3D(params Point3D[] points)
        {
            this.paths.AddRange(points);
        }

        public List<Point3D> Paths
        {
            get { return this.paths; }
            set { this.paths = value; }
        }

        public override string ToString()
        {
            return string.Join("\n", Paths);
        }
    }

    static class Storage
    {
        public static void savePaths(string fileName, Path3D paths)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.Write(paths);
            }
        }

        public static void loadPaths(string fileName)
        {
            Path3D paths = new Path3D();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                string pattern = "([\\d.]+)";

                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    Regex reg = new Regex(pattern);
                    MatchCollection mathes = reg.Matches(line);
                    
                    double xCoord = double.Parse(mathes[0].Value);
                    double yCoord = double.Parse(mathes[1].Value);
                    double zCoord = double.Parse(mathes[2].Value);

                    Point3D point = new Point3D(xCoord, yCoord, zCoord);
                    paths.Paths.Add(point);
                }
            }
            Console.WriteLine(paths);
        }
    }

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