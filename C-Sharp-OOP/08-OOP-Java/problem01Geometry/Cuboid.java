package problem01Geometry;

public class Cuboid extends SpaceShape{

	private Vertex[] vertices3D = new Vertex[1];
	private double width;
	private double height;
	private double depth;
	
	public Cuboid(Vertex[] vertices3D, double width, double height, double depth) {
		super(vertices3D);
		this.vertices3D = vertices3D;
		this.width = width;
		this.height = height;
		this.depth = depth;
	}

	public Vertex[] getVertices3D() {
		return vertices3D;
	}

	public void setVertices3D(Vertex[] vertices3d) {
		vertices3D = vertices3d;
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
		String vertexA = "vertex A->" + this.vertices3D[0].getX() + " " + this.vertices3D[0].getY();
		String vertexB = "vertex B->" + this.vertices3D[0].getX() + " " + (this.vertices3D[0].getY() + this.depth);
		String vertexHeight = "height vertex:->" + this.vertices3D[0].getX() + " " + this.vertices3D[0].getY() + " " + (this.vertices3D[0].getZ() + this.height);
		String vertexC = "vertex C->" + (this.vertices3D[0].getX() + this.width) + " " + (this.vertices3D[0].getY() + this.depth);
		String vertexD = "vertex D->" + (this.vertices3D[0].getX() + this.width) + " " + this.vertices3D[0].getY();
		String vertexCoord = String.format("\nVertex's coordinates: %s; %s; %s; %s; %s", vertexA, vertexB, vertexC, vertexD, vertexHeight);
		String infoStr = String.format("Shape type: %s %s\nVolume = %.2f; Area = %.2f\n\n", this.getClass().getSimpleName(), vertexCoord, this.getVolume(), this.getArea()); 
		
		return infoStr;
	}

}
