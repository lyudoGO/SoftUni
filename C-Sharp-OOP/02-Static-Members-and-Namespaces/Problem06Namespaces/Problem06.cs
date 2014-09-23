using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geometry.Geometry2D;
using Geometry.Geometry3D;
using Geometry.Storage;
using Geometry.UI;

class Problem06
{
    static void Main(string[] args)
    {
        // Create instances from namespace Geometry2D
        Point2D point2D = new Point2D();
        Circle circle = new Circle();
        DistanceCalculator2D distance2D = new DistanceCalculator2D();
        Ellipse ellipse = new Ellipse();
        Figure2D figure2D = new Figure2D();
        Polygon polygon = new Polygon();
        Rectangle rectangle = new Rectangle();
        Square square = new Square();

        // Create instances from namespace Geometry3D
        DistanceCalculator3D distance3D = new DistanceCalculator3D();
        Path3D path3D = new Path3D();
        Point3D point3D = new Point3D();

        // Create instances from namespace Storage
        GeometryBinaryStorage binaryStorage = new GeometryBinaryStorage();
        GeometrySVGStorage svgStorage = new GeometrySVGStorage();
        GeometryXMLStorage xmlStorage = new GeometryXMLStorage();

        // Create instances from namespace UI
        Screen2D screen2D = new Screen2D();
        Screen3D screen3D = new Screen3D();
  }
}