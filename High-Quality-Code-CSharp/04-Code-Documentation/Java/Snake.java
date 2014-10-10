import java.awt.Color;
import java.awt.Graphics;
import java.util.LinkedList;

/**
 * Class for object snake.
 */
public class Snake{
	LinkedList<Point> snakeBody = new LinkedList<Point>();
	private Color snakeColor;
	private int velocityX, velocityY;
	
	public Snake() {
		snakeColor = Color.GREEN;
		snakeBody.add(new Point(300, 100)); 
		snakeBody.add(new Point(280, 100)); 
		snakeBody.add(new Point(260, 100)); 
		snakeBody.add(new Point(240, 100)); 
		snakeBody.add(new Point(220, 100)); 
		snakeBody.add(new Point(200, 100)); 
		snakeBody.add(new Point(180, 100));
		snakeBody.add(new Point(160, 100));
		snakeBody.add(new Point(140, 100));
		snakeBody.add(new Point(120, 100));

		velocityX = 10;
		velocityY = 0;
	}
	
	/**
	 * Draw the snake with points from object Point
	 * @param g object of type Graphics
	 */
	public void drawSnake(Graphics g) {		
		for (Point point : this.snakeBody) {
			point.drawPoint(g, snakeColor);
		}
	}
	
	public void tick() {
		Point newPositionPoint = new Point((snakeBody.get(0).getX() + velocityX), (snakeBody.get(0).getY() + velocityY));
		
		if (newPositionPoint.getX() > Game.WIDTH - 20) {
		 	Game.gameRunning = false;
		} else if (newPositionPoint.getX() < 0) {
			Game.gameRunning = false;
		} else if (newPositionPoint.getY() < 0) {
			Game.gameRunning = false;
		} else if (newPositionPoint.getY() > Game.HEIGHT - 20) {
			Game.gameRunning = false;
		} else if (Game.apple.getPoint().equals(newPositionPoint)) {
			snakeBody.add(Game.apple.getPoint());
			Game.apple = new Apple(this);
			Game.scores += 50;
		} else if (snakeBody.contains(newPositionPoint)) {
			Game.gameRunning = false;
			System.out.println("You ate yourself");
		}	
		
		for (int i = snakeBody.size()-1; i > 0; i--) {
			snakeBody.set(i, new Point(snakeBody.get(i-1)));
		}	
		snakeBody.set(0, newPositionPoint);
	}

	/**
	 * Getter.
	 * @return velocity by X coordinate.
	 */
	public int getVelX() {
		return velocityX;
	}

	/**
	 * Setter.
	 * @param  velocity X coordinate.
	 */
	public void setVelX(int velX) {
		this.velocityX = velX;
	}

	/**
	 * Getter.
	 * @return velocity by Y coordinate.
	 */
	public int getVelY() {
		return velocityY;
	}

	/**
	 * Setter.
	 * @param velocity Y coordinate.
	 */
	public void setVelY(int velY) {
		this.velocityY = velY;
	}
}

