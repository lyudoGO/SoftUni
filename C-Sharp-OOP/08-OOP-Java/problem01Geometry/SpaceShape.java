package problem01Geometry;

public abstract class SpaceShape extends Shape implements AreaMeasurable, VolumeMeasurable {

	public SpaceShape(Vertex[] vertices3D) {
		super(vertices3D);
		// TODO Auto-generated constructor stub
	}

	@Override
	public double getVolume() {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public double getArea() {
		// TODO Auto-generated method stub
		return 0;
	}
}
