using Problem01Point3D;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Problem03Paths
{
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
}