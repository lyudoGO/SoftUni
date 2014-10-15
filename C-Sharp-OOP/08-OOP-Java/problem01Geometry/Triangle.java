package problem01Geometry;

public class Triangle extends PlaneShape {

	private Vertex[] vertices2D;
	
	public Triangle(Vertex[] vertices2D) {
		super(vertices2D);
		this.vertices2D = vertices2D;
	}

	public Vertex[] getVertices2D() {
		return vertices2D;
	}

	public void setVertices2D(Vertex[] vertices2d) {
		vertices2D = vertices2d;
	}
	
	@Override
	public double getArea() {
		
		double area = Math.abs(this.vertices2D[0].getX() * (this.vertices2D[1].getY() - this.vertices2D[2].getY()) + 
					  this.vertices2D[1].getX() * (this.vertices2D[2].getY() - this.vertices2D[0].getY()) + 
					  this.vertices2D[2].getX() * (this.vertices2D[0].getY() - this.vertices2D[1].getY())) / 2;
		
		return area;
	}

	@Override
	public double getPerimeter() {
		
		double distAB = Math.sqrt(Math.pow((this.vertices2D[0].getX() - this.vertices2D[1].getX()), 2) +
				Math.pow((this.vertices2D[0].getY() - this.vertices2D[1].getY()), 2));
		double distAC = Math.sqrt(Math.pow((this.vertices2D[0].getX() - this.vertices2D[2].getX()), 2) +
				Math.pow((this.vertices2D[0].getY() - this.vertices2D[2].getY()), 2));
		double distBC = Math.sqrt(Math.pow((this.vertices2D[1].getX() - this.vertices2D[2].getX()), 2) +
				Math.pow((this.vertices2D[1].getY() - this.vertices2D[2].getY()), 2));
		
		return distAB + distAC + distBC;
	}

	@Override
	public String toString() {
		
		String vertexA = "vertex A->" + this.vertices2D[0].getX() + " " + this.vertices2D[0].getY();
		String vertexB = "vertex B->" + this.vertices2D[1].getX() + " " + this.vertices2D[1].getY();
		String vertexC = "vertex C->" + this.vertices2D[2].getX() + " " + this.vertices2D[2].getY();
		String vertexCoord = String.format("\nVertex's coordinates: %s; %s; %s", vertexA, vertexB, vertexC);
		String infoStr = String.format("Shape type: %s %s\nPerimeter = %.2f; Area = %.2f\n\n", this.getClass().getSimpleName(), vertexCoord, this.getPerimeter(), this.getArea()); 
		
		return infoStr;
	}

}
