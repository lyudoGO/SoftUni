package problem01Geometry;

public class Circle extends PlaneShape{

	private double radius;
	private Vertex[] vertices2D = new Vertex[1];
	
	public Circle(Vertex[] vertices2D, double radius) {
		super(vertices2D);
		this.vertices2D = vertices2D;
		this.radius = radius;
	}

	public Vertex[] getVertices2D() {
		return vertices2D;
	}

	public void setVertices2D(Vertex[] vertices2d) {
		vertices2D = vertices2d;
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
		
		String vertex = "circle center->" + this.vertices2D[0].getX() + " " + this.vertices2D[0].getY();
		String vertexCoord = String.format("\nVertex's coordinates: %s;", vertex);
		String infoStr = String.format("Shape type: %s %s\nPerimeter = %.2f; Area = %.2f\n\n", this.getClass().getSimpleName(), vertexCoord, this.getPerimeter(), this.getArea()); 
		
		return infoStr;
	}
	

	
}
