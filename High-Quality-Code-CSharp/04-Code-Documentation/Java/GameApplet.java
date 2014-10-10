import java.applet.Applet;
import java.awt.Dimension;
import java.awt.Graphics;

/**
 * Class to create game applet
 */
@SuppressWarnings("serial")
public class GameApplet extends Applet {
	private Game game;
	KeyCatcher IH;
	
	/**
	 * Method to initialization the game
	 */
	public void init(){
		game = new Game();
		game.setPreferredSize(new Dimension(800, 650));
		game.setVisible(true);
		game.setFocusable(true);
		this.add(game);
		this.setVisible(true);
		this.setSize(new Dimension(800, 650));
		IH = new KeyCatcher(game);
	}
	
	/**
	 * Method to paint game field(applet) with fixed dimensions 
	 */
	public void paint(Graphics g){
		this.setSize(new Dimension(800, 650));
	}

}
