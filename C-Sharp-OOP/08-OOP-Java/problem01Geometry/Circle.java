package problem01Geometry;

public class Circle extends PlaneShape{

	private double radius;
	
	public Circle(Vertex[] vertices2D, double radius) {
		super(vertices2D);
		
		this.radius = radius;
	}

	public double getRadius() {
		return radius;
	}

	public void setRadius(double radius) {
		this.radius = radius;
	}

	@Override
	public double getArea() {
		double area = Math.PI * this.radius * this.radius;
		return area;
	}

	@Override
	public double getPerimeter() {
		double perimeter = 2 * Math.PI * this.radius;
		return perimeter;
	}

	@Override
	public String toString() {
		
		String vertex = "circle center->" + super.vertices2D[0].getX() + " " + super.vertices2D[0].getY();
		String vertexCoord = String.format("\nVertex's coordinates: %s;", vertex);
		String infoStr = String.format("Shape type: %s %s\nPerimeter = %.2f; Area = %.2f\n\n", this.getClass().getSimpleName(), vertexCoord, this.getPerimeter(), this.getArea()); 
		
		return infoStr;
	}
	

	
}
