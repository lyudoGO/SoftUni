package problem01Geometry;


public abstract class PlaneShape extends Shape implements PerimeterMeasurable, AreaMeasurable {

	protected Vertex[] vertices2D;
	
	public PlaneShape(Vertex[] vertices) {
		super(vertices);
		this.vertices2D = vertices;
	}

	public Vertex[] getVertices2D() {
		return vertices2D;
	}

	public void setVertices2D(Vertex[] vertices2d) {
		vertices2D = vertices2d;
	}

}
