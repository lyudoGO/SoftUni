package problem01Geometry;

public class Cuboid extends SpaceShape{

	private double width;
	private double height;
	private double depth;
	
	public Cuboid(Vertex[] vertices3D, double width, double height, double depth) {
		super(vertices3D);
	
		this.width = width;
		this.height = height;
		this.depth = depth;
	}

	public double getWidth() {
		return width;
	}

	public void setWidth(double width) {
		this.width = width;
	}

	public double gethHeight() {
		return height;
	}

	public void sethHeight(double height) {
		this.height = height;
	}
	
	public double getDepth() {
		return depth;
	}

	public void setDepth(double depth) {
		this.depth = depth;
	}

	@Override
	public double getVolume() {
		double base = this.width * this.depth;
		double volume = base * this.height;
		return volume;
	}

	@Override
	public double getArea() {
		double base = this.width * this.depth;
		double sideA = this.width * this.height;
		double sideB = this.depth * this.height;
		double area = 2 * base + 2 * sideA + 2 * sideB;
		return area;
	}

	@Override
	public String toString() {
		String vertexA = "vertex A->" + super.vertices3D[0].getX() + " " + super.vertices3D[0].getY();
		String vertexB = "vertex B->" + super.vertices3D[0].getX() + " " + (super.vertices3D[0].getY() + this.depth);
		String vertexHeight = "height vertex:->" + this.vertices3D[0].getX() + " " + this.vertices3D[0].getY() + " " + (this.vertices3D[0].getZ() + this.height);
		String vertexC = "vertex C->" + (super.vertices3D[0].getX() + this.width) + " " + (super.vertices3D[0].getY() + this.depth);
		String vertexD = "vertex D->" + (super.vertices3D[0].getX() + this.width) + " " + super.vertices3D[0].getY();
		String vertexCoord = String.format("\nVertex's coordinates: %s; %s; %s; %s; %s", vertexA, vertexB, vertexC, vertexD, vertexHeight);
		String infoStr = String.format("Shape type: %s %s\nVolume = %.2f; Area = %.2f\n\n", this.getClass().getSimpleName(), vertexCoord, this.getVolume(), this.getArea()); 
		
		return infoStr;
	}

}
