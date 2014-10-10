import java.awt.Color;
import java.awt.Graphics;
import java.awt.Rectangle;

/**
 * Class for points of the objects
 */
public class Point {
	private int x, y;
	private final int WIDTH = 20;
	private final int HEIGHT = 20;
	
	/**
	 * Constructor for point
	 * @param point of type Point
	 */
	public Point(Point point){
		this(point.x, point.y);
	}
	
	/**
	 * Constructor for point
	 * @param x X coordinate
	 * @param y Y coordinate
	 */
	public Point(int x, int y){
		this.x = x;
		this.y = y;
	}	
	
	/**
	 * Getter
	 * @return X coordinate
	 */
	public int getX() {
		return x;
	}
	
	/**
	 * Setter
	 * @param X coordinate
	 */
	public void setX(int x) {
		this.x = x;
	}
	
	/**
	 * Getter
	 * @return Y coordinate
	 */
	public int getY() {
		return y;
	}
	
	/**
	 * Setter
	 * @param Y coordinate
	 */
	public void setY(int y) {
		this.y = y;
	}
	
	/**
	 * Method to draw point by coordinates x and y
	 * @param g Object of class Graphics
	 * @param color Color for drawing object
	 */
	public void drawPoint(Graphics g, Color color) {
		g.setColor(Color.BLACK);
		g.fillRect(x, y, WIDTH, HEIGHT);
		g.setColor(color);
		g.fillRect(x + 1, y + 1, WIDTH - 2, HEIGHT - 2);		
	}
	
	/**
	 * Method to print coordinates x and y
	 * @return Formatted string
	 */
	public String toString() {
		return "[x=" + x + ",y=" + y + "]";
	}
	
	/**
	 * Method to check if snake and apple points are matching
	 * @return True or false
	 */
	public boolean equals(Object objects) {
        if (objects instanceof Point) {
            Point point = (Point)objects;
            return (x == point.x) && (y == point.y);
        }
        return false;
    }
}

