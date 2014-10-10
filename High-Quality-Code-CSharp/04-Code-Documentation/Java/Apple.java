import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;

/**
 * Class for object apple
 */
public class Apple {
	public static Random randomGenerator;
	private Point appleObject;
	private Color appleColor;
	
	public Apple(Snake s) {
		appleObject = createApple(s);
		appleColor = Color.RED;		
	}
	
	/**
	 * Method to create apple random position
	 * @param s Current snake
	 * @return Coordinates of apple different from coordinates of snake
	 */
	private Point createApple(Snake s) {
		randomGenerator = new Random();
		int x = randomGenerator.nextInt(30) * 20; 
		int y = randomGenerator.nextInt(30) * 20;
		for (Point snakePoint : s.snakeBody) {
			if (x == snakePoint.getX() || y == snakePoint.getY()) {
				return createApple(s);				
			}
		}
		return new Point(x, y);
	}
	
	/**
	 * Method to draw the apple
	 * @param g Object of type Graphics
	 */
	public void drawApple(Graphics g){
		appleObject.drawPoint(g, appleColor);
	}	
	
	/**
	 * Method to get apples coordinates
	 * @return Coordinates of apple
	 */
	public Point getPoint(){
		return appleObject;
	}
}
