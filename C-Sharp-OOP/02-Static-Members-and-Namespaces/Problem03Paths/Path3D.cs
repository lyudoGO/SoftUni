using System;
using System.Collections.Generic;
using Problem01Point3D;

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
}