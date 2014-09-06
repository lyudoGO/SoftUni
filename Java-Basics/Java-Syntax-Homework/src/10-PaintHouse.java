import java.awt.BasicStroke;
import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Shape;
import java.awt.geom.Ellipse2D;
import java.awt.geom.GeneralPath;
import java.awt.geom.Line2D;
import java.awt.geom.Rectangle2D;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Locale;
import java.util.Scanner;

import javax.swing.JPanel;

import org.apache.batik.dom.GenericDOMImplementation;
import org.apache.batik.svggen.SVGGraphics2D;
import org.w3c.dom.DOMImplementation;
import org.w3c.dom.Document;

//You have to use Batik 1.7
//Download from http://apache.cbox.biz/xmlgraphics/batik/batik-1.7.zip

public class PaintHouse extends JPanel {
	

	public PaintHouse(ArrayList<String> inputCoordinates)
	{
		this.inputCoordinatesArrayList = inputCoordinates;
	}
	
    public ArrayList<String> inputCoordinatesArrayList = new ArrayList<String>();


	public void paintComponent(Graphics g){
		super.paintComponent(g);
		this.setBackground(Color.WHITE);
		
		Graphics2D g2 = (Graphics2D) g;
		int scale = 35;
		
		//draw left house body
		g2.setStroke(new BasicStroke(3f));
	    Shape rectangleLeft = new Rectangle2D.Double(12.5 * scale, 8.5 * scale, 5 * scale, 5 * scale);
	    g2.setPaint(Color.LIGHT_GRAY);
	    g2.fill(rectangleLeft);
	    g2.setPaint(Color.BLACK);
	    g2.draw(rectangleLeft);
	    
	    //draw right house body
	    Shape rectangleRight = new Rectangle2D.Double(20 * scale, 8.5 * scale, 2.5 * scale, 5 * scale);
	    g2.setPaint(Color.LIGHT_GRAY);
	    g2.fill(rectangleRight);
	    g2.setPaint(Color.BLACK);
	    g2.draw(rectangleRight);
	    
	    //draw house roof
	    GeneralPath roof = new GeneralPath();
	    roof.moveTo(12.5 * scale, 8.5 * scale);
	    roof.lineTo(17.5 * scale, 3.5 * scale);
	    roof.lineTo(22.5 * scale, 8.5 * scale);
	    roof.closePath();
	    g2.setPaint(Color.LIGHT_GRAY);
	    g2.fill(roof);
	    g2.setPaint(Color.BLACK);
	    g2.draw(roof);
	    
	    //draw coordinate axes 
		float[] dash = { 2f, 3f };
		g.setColor(Color.CYAN);
	    BasicStroke bs = new BasicStroke(2f, BasicStroke.CAP_BUTT, BasicStroke.JOIN_ROUND, 10f, dash, 0f);
	    g2.setStroke(bs);
	    //draw coordinate axe Y
	    double x1 = 10;
		double x2 = 10;
		double y1 = 2;
		double y2 = 17;
		double c = 2.5;
		
	    for (int i = 0;  i < 6; i++) {
	    	Shape lineY = new Line2D.Double(x1 * scale, y1 * scale, x2 * scale, y2 * scale);
		    g2.draw(lineY);
		    x1 = x1 + c;
		    x2 = x2 + c;
		}
	    //draw coordinate axe X
	    x1 = 9;
		x2 = 23.5;
		y1 = 3.5;
		y2 = 3.5;
		
		for (int i = 0;  i < 6; i++) {
			Shape lineX = new Line2D.Double(x1 * scale, y1 * scale, x2 * scale, y2 * scale);
		    g2.draw(lineX);
		    y1 = y1 + c;
		    y2 = y2 + c;
		}
	    	    
	    //draw text on coordinate axes
	    g.setColor(Color.BLACK);
	    g2.setFont(new Font("Consolas", Font.PLAIN, scale));
	    
	    float x = 9.5f;
	    for (int i = 0; i < 6; i++) {
			String[] textX = {"10", "12.5", "15", "17.5", "20", "22.5"};
			g2.drawString(textX[i], x * scale, 1.5f * scale);
			x = x + 2.5f;
		}
	    
	    float y = 3.5f;
	    for (int i = 0; i < 6; i++) {
			String[] textX = {"3.5", "6", "8.5", "11", "13.5", "16"};
			g2.drawString(textX[i], 6.5f * scale, y * scale);
			y = y + 2.5f;
		}    
	    g2.drawString("Powered by Lyudo", 15f * scale, 17.5f * scale);
	    
	    //draw points inside and outside the house
	    g2.setStroke(new BasicStroke(2f));
	   	    
	    for (String string : inputCoordinatesArrayList) {
	    	if(string.equals("stop")){
	    		break;
	    	}
	    	
	    	String[] posPoint = string.split(" ");
    		double pointX = Double.parseDouble(posPoint[0]);
    		double pointY = Double.parseDouble(posPoint[1]);
    		
	    	String positionPoint = PointsInsideTheHouse(string);
	    	
	    	Shape point = new Ellipse2D.Double(pointX * scale, pointY * scale, scale/2, scale/2);
    		
    		if(positionPoint.equals("Inside")){
	    		g2.setPaint(Color.BLACK);
	    		g2.fill(point);
	      	}else{
	    		g2.setPaint(Color.LIGHT_GRAY);
	    		g2.fill(point);
	    		g2.setPaint(Color.DARK_GRAY);
	    	    g2.draw(point);
	    	}
		}
	}
	
	//check whether a point is inside or outside the house 
	public static String PointsInsideTheHouse(String position){
		String[] posPoint = position.split(" ");
		double pointX = Double.parseDouble(posPoint[0]);
		double pointY = Double.parseDouble(posPoint[1]);
		
		String positionPoint = null;
		
		boolean isInsideRectB = (pointX >= 12.5 && pointX <= 17.5) && (pointY >= 8.5 && pointY <= 13.5);
		boolean isInsideRectC = (pointX >= 20 && pointX <= 22.5) && (pointY >= 8.5 && pointY <= 13.5);
		
		if(isInsideRoof(pointX, pointY) || isInsideRectB || isInsideRectC ){
			positionPoint = "Inside";
		}else{
			positionPoint = "Outside";
		}
		return positionPoint;
	}
	
	//check whether a point is inside the roof 
	private static boolean isInsideRoof(double pointX, double pointY) {
		double areaABC = Math.abs((12.5 * (3.5 - 8.5) + 17.5 * (8.5 - 8.5)+ 22.5 * (8.5 - 3.5))/2.0);
		double areaPointBC = Math.abs((pointX * (3.5 - 8.5) + 17.5 * (8.5 - pointY) + 22.5 * (pointY - 3.5))/2.0);
		double areaPointAC = Math.abs((12.5 * (pointY - 8.5) + pointX * (8.5 - 8.5) + 22.5 * (8.5 - pointY))/2.0);
		double areaPointAB = Math.abs((12.5 * (3.5 - pointY) + 17.5 * (pointY - 8.5) + pointX * (8.5 - 3.5))/2.0);
		return (areaABC == areaPointBC + areaPointAC + areaPointAB);
	}
	
	public static void main(String[] args) throws IOException{
		Locale.setDefault(Locale.ROOT);
		
		ArrayList<String> inputCoordinates = new ArrayList<String>();
		Scanner input = new Scanner(System.in);
		
		boolean exit = true;
		
		System.out.println("Enter coordinates X, Y in pairs on one line like this: 12.5 10.1");
		System.out.println("For end write \"stop\"! ");
		
		while(exit){
			String inputLine = input.nextLine();
			inputCoordinates.add(inputLine);
			if(inputLine.equals("stop")){
				exit = false;
			}
		}
		//draw house into SVG/HTML file called house.html	
		PaintHouse paintSvgHouse = new PaintHouse(inputCoordinates);
        DOMImplementation domImpl = GenericDOMImplementation.getDOMImplementation();
        Document doc = domImpl.createDocument(null, "html", null); 
        SVGGraphics2D svg = new SVGGraphics2D(doc);
        paintSvgHouse.paintComponent(svg);
        svg.stream(new FileWriter("house.html"),false);

		//draw house into window frame		
		/*JFrame frame = new JFrame("House"); //create window frame
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		PaintHouse drawHouse = new PaintHouse(inputCoordinates);
		frame.add(drawHouse); //draw house to window frame 
		frame.setSize(660, 450);
		frame.setLocationRelativeTo(null);//set window frame on center of display 
		frame.setVisible(true);*/
	}
}
