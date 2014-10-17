package problem01Geometry;

public class Sphere extends SpaceShape{

	private double radius;
	
	public Sphere(Vertex[] vertices3D, double radius) {
		super(vertices3D);
	
		this.radius = radius;
	}

	public double getRadius() {
		return radius;
	}

	public void setRadius(double radius) {
		this.radius = radius;
	}

	@Override
	public double getVolume() {
		double volume = 1.3333 * Math.PI * this.radius * this.radius * this.radius;
		return volume;
	}

	@Override
	public double getArea() {
		double area = 4 * Math.PI * this.radius * this.radius;
		return area;
	}

	@Override
	public String toString() {
		String vertex = "sphere center->" + super.vertices3D[0].getX() + " " + super.vertices3D[0].getY()+ " " + super.vertices3D[0].getZ();
		String vertexCoord = String.format("\nVertex's coordinates: %s;", vertex);
		String infoStr = String.format("Shape type: %s %s\nVolume = %.2f; Area = %.2f\n\n", this.getClass().getSimpleName(), vertexCoord, this.getVolume(), this.getArea()); 
		
		return infoStr;
	}

}
