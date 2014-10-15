package problem01Geometry;

import java.util.Arrays;
import java.util.List;
import java.util.Comparator;
import java.util.stream.Collectors;

public class Problem01 {

	public static void main(String[] args) {
		Vertex[] triangleVertex = {new Vertex(15, 15), new Vertex(23, 30), new Vertex(50, 25)};
		Triangle triangle = new Triangle(triangleVertex);
		
		Vertex[] rectangleVertex = {new Vertex(25.5, 25.5)};
		Rectangle rectangle = new Rectangle(rectangleVertex, 32.5, 23.5);
		
		Vertex[] circleVertex = {new Vertex(20.1, 18.3)};
		Circle circle = new Circle(circleVertex, 12.7);
		
		Vertex[] squarePyramidBaseCenter = {new Vertex(25, 25, 0)};
		SquarePyramid squarePyramid = new SquarePyramid(squarePyramidBaseCenter, 20, 20);
		
		Vertex[] cuboidBaseVertex = {new Vertex(25.5, 25.5, 0)};
		Cuboid cuboid = new Cuboid(cuboidBaseVertex, 32.5, 23.5, 25.5);
		
		Vertex[] sphereVertex = {new Vertex(20.1, 18.3, 15)};
		Sphere sphere = new Sphere(sphereVertex, 12.7);
		
		Shape[] shapes = {triangle, rectangle, circle, squarePyramid, cuboid, sphere};
			
		for (Shape shape : shapes) {
			System.out.print(shape);
		}
		
		List<Shape> filterByVolume = Arrays.asList(shapes)
									.stream()
									.filter(e -> e instanceof SpaceShape)
									.filter(e -> ((SpaceShape)e).getVolume() > 40)
									.collect(Collectors.toList());
		
		List<Shape> sortByPerimeter = Arrays.asList(shapes)
				.stream()
				.filter(e -> e instanceof PlaneShape)
				.sorted((e, e1) -> (int)(((PlaneShape) e).getPerimeter() - ((PlaneShape) e1).getPerimeter()))
				.collect(Collectors.toList());
		
		System.out.print("Filter space shapes by volume:\n");
		for (Shape shape : filterByVolume) {
			System.out.print(shape);
		}
		
		System.out.print("Sort plane shapes by perimeter:\n");
		for (Shape shape : sortByPerimeter) {
			System.out.print(shape);
		}
	}
}
