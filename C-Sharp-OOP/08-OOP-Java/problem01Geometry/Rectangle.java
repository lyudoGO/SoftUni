package problem01Geometry;

public class Rectangle extends PlaneShape {

	private double width;
	private double height;
	
	public Rectangle(Vertex[] vertices2D, double width, double height) {
		super(vertices2D);
	
		this.width = width;
		this.height = height;
	}

	public double getWidth() {
		return width;
	}

	public void setWidth(double width) {
		this.width = width;
	}

	public double getHeight() {
		return height;
	}

	public void setHeight(double height) {
		this.height = height;
	}

	@Override
	public double getArea() {
		double area = this.height * this.width;
		return area;
	}

	@Override
	public double getPerimeter() {
		double perimeter = this.height * 2 + this.width * 2;
		return perimeter;
	}
	
	@Override
	public String toString() {
		
		String vertexA = "vertex A->" + super.vertices2D[0].getX() + " " + super.vertices2D[0].getY();
		String vertexB = "vertex B->" + super.vertices2D[0].getX() + " " + (super.vertices2D[0].getY() + this.height);
		String vertexC = "vertex C->" + (super.vertices2D[0].getX() + this.width) + " " + (super.vertices2D[0].getY() + this.height);
		String vertexD = "vertex D->" + (super.vertices2D[0].getX() + this.width) + " " + super.vertices2D[0].getY();
		String vertexCoord = String.format("\nVertex's coordinates: %s; %s; %s; %s", vertexA, vertexB, vertexC, vertexD);
		String infoStr = String.format("Shape type: %s %s\nPerimeter = %.2f; Area = %.2f\n\n", this.getClass().getSimpleName(), vertexCoord, this.getPerimeter(), this.getArea()); 
		
		return infoStr;
	}

}
