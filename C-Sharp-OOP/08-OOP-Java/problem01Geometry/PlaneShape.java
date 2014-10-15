package problem01Geometry;


public abstract class PlaneShape extends Shape implements PerimeterMeasurable, AreaMeasurable {

	public PlaneShape(Vertex[] vertices2D) {
		super(vertices2D);
		// TODO Auto-generated constructor stub
	}

	@Override
	public double getArea() {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public double getPerimeter() {
		// TODO Auto-generated method stub
		return 0;
	}
	

}
