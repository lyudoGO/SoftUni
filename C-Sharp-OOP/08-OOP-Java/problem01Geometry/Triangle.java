package problem01Geometry;

public class Triangle extends PlaneShape {
	
	public Triangle(Vertex[] vertices2D) {
		super(vertices2D);
		
	}

	@Override
	public double getArea() {
		
		double area = Math.abs(super.vertices2D[0].getX() * (super.vertices2D[1].getY() - super.vertices2D[2].getY()) + 
				super.vertices2D[1].getX() * (super.vertices2D[2].getY() - super.vertices2D[0].getY()) + 
					  super.vertices2D[2].getX() * (super.vertices2D[0].getY() - super.vertices2D[1].getY())) / 2;
		
		return area;
	}

	@Override
	public double getPerimeter() {
		
		double distAB = Math.sqrt(Math.pow((super.vertices2D[0].getX() - super.vertices2D[1].getX()), 2) +
				Math.pow((super.vertices2D[0].getY() - super.vertices2D[1].getY()), 2));
		double distAC = Math.sqrt(Math.pow((super.vertices2D[0].getX() - super.vertices2D[2].getX()), 2) +
				Math.pow((super.vertices2D[0].getY() - super.vertices2D[2].getY()), 2));
		double distBC = Math.sqrt(Math.pow((this.vertices2D[1].getX() - super.vertices2D[2].getX()), 2) +
				Math.pow((super.vertices2D[1].getY() - super.vertices2D[2].getY()), 2));
		
		return distAB + distAC + distBC;
	}

	@Override
	public String toString() {
		
		String vertexA = "vertex A->" + super.vertices2D[0].getX() + " " + super.vertices2D[0].getY();
		String vertexB = "vertex B->" + super.vertices2D[1].getX() + " " + super.vertices2D[1].getY();
		String vertexC = "vertex C->" + super.vertices2D[2].getX() + " " + super.vertices2D[2].getY();
		String vertexCoord = String.format("\nVertex's coordinates: %s; %s; %s", vertexA, vertexB, vertexC);
		String infoStr = String.format("Shape type: %s %s\nPerimeter = %.2f; Area = %.2f\n\n", this.getClass().getSimpleName(), vertexCoord, this.getPerimeter(), this.getArea()); 
		
		return infoStr;
	}

}
