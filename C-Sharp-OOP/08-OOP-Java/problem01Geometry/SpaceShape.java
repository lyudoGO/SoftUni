package problem01Geometry;

public abstract class SpaceShape extends Shape implements AreaMeasurable, VolumeMeasurable {

	protected Vertex[] vertices3D;
	
	public SpaceShape(Vertex[] vertices) {
		super(vertices);
		this.vertices3D = vertices;
	}

	public Vertex[] getVertices3D() {
		return this.vertices3D;
	}

	public void setVertices3D(Vertex[] vertices3d) {
		this.vertices3D = vertices3d;
	}
}
