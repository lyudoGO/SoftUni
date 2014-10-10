import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

/**
 * Class handles events of the keyboard
 */
public class KeyCatcher implements KeyListener{
	
	/**
	 * Create a object of class KeyListener
	 * @param game Object of class Game
	 */
	public KeyCatcher(Game game){
		game.addKeyListener(this);
	}
	
	/**
	 * Method to handles pressed key.Use keys arrows to move the snake 
	 * @param e Object of class KeyEvent
	 */
	public void keyPressed(KeyEvent e) {
		int keyCode = e.getKeyCode();
		
		if (keyCode == KeyEvent.VK_W || keyCode == KeyEvent.VK_UP) {
			if(Game.snake.getVelY() != 20){
				Game.snake.setVelX(0);
				Game.snake.setVelY(-20);
			}
		}
		if (keyCode == KeyEvent.VK_S || keyCode == KeyEvent.VK_DOWN) {
			if(Game.snake.getVelY() != -20){
				Game.snake.setVelX(0);
				Game.snake.setVelY(20);
			}
		}
		if (keyCode == KeyEvent.VK_D || keyCode == KeyEvent.VK_RIGHT) {
			if(Game.snake.getVelX() != -20){
			Game.snake.setVelX(20);
			Game.snake.setVelY(0);
			}
		}
		if (keyCode == KeyEvent.VK_A || keyCode == KeyEvent.VK_LEFT) {
			if(Game.snake.getVelX() != 20){
				Game.snake.setVelX(-20);
				Game.snake.setVelY(0);
			}
		}
		// If ESC key is pressed quit the game
		if (keyCode == KeyEvent.VK_ESCAPE) {
			System.exit(0);
		}
	}
	
	public void keyReleased(KeyEvent e) {
	}
	
	public void keyTyped(KeyEvent e) {
		
	}

}
