package problem01Geometry;

public class SquarePyramid extends SpaceShape {

	private double baseWidth;
	private double pyramidHeight;
	
	public SquarePyramid(Vertex[] vertices3D, double baseWidth, double pyramidHeight) {
		super(vertices3D);
	
		this.baseWidth = baseWidth;
		this.pyramidHeight = pyramidHeight;
	}

	
	public double getBaseWidth() {
		return baseWidth;
	}

	public void setBaseWidth(double baseWidth) {
		this.baseWidth = baseWidth;
	}

	public double getPyramidHeight() {
		return pyramidHeight;
	}

	public void setPyramidHeight(double pyramidHeight) {
		this.pyramidHeight = pyramidHeight;
	}

	@Override
	public double getVolume() {
		double volume = (this.baseWidth * this.baseWidth * this.pyramidHeight) / 3;
		return volume;
	}

	@Override
	public double getArea() {
		double slantHeight = Math.sqrt((this.pyramidHeight * this.pyramidHeight) + ((this.baseWidth * this.baseWidth) / 4));
		double area = 2 * this.baseWidth * slantHeight + (this.baseWidth * this.baseWidth);
		return area;
	}

	@Override
	public String toString() {
		String vertexPyramid = "vertex pyramid->" + super.vertices3D[0].getX() + " " + super.vertices3D[0].getY() + " " + (super.vertices3D[0].getZ() + this.pyramidHeight);
		String baseCenter = "base center->" + super.vertices3D[0].getX() + " " + super.vertices3D[0].getY();
		String vertexCoord = String.format("\nVertex's coordinates: %s; %s;", vertexPyramid, baseCenter);
		String infoStr = String.format("Shape type: %s %s\nVolume = %.2f; Area = %.2f\n\n", this.getClass().getSimpleName(), vertexCoord, this.getVolume(), this.getArea()); 
		
		return infoStr;
	}

}
