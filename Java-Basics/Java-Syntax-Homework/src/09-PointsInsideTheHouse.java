import java.util.Locale;
import java.util.Scanner;


public class PointsInsideTheHouse {

	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		Scanner input = new Scanner(System.in);
		double pointX = input.nextDouble();
		double pointY = input.nextDouble();
		
		boolean isInsideRectB = (pointX >= 12.5 && pointX <= 17.5) && (pointY >= 8.5 && pointY <= 13.5);
		boolean isInsideRectC = (pointX >= 20 && pointX <= 22.5) && (pointY >= 8.5 && pointY <= 13.5);
		
		if(isInsideTriangle(pointX, pointY) || isInsideRectB || isInsideRectC ){
			System.out.println("Inside");
		}else{
			System.out.println("Outside");
		}
	}

	private static boolean isInsideTriangle(double pointX, double pointY) {
		//Area existing triangle ABC (x1*(y2-y3) + x2*(y3-y1)+ x3*(y1-y2))/2.0
		//point A(x1, y1); x1 = 12.5, y1 = 8.5
		//point B(x2, y2); x2 = 17.5, y2 = 3.5
		//point C(x3, y3); x3 = 22.5, y3 = 8.5
		double areaABC = Math.abs((12.5 * (3.5 - 8.5) + 17.5 * (8.5 - 8.5)+ 22.5 * (8.5 - 3.5))/2.0);
		double areaPointBC = Math.abs((pointX * (3.5 - 8.5) + 17.5 * (8.5 - pointY) + 22.5 * (pointY - 3.5))/2.0);
		double areaPointAC = Math.abs((12.5 * (pointY - 8.5) + pointX * (8.5 - 8.5) + 22.5 * (8.5 - pointY))/2.0);
		double areaPointAB = Math.abs((12.5 * (3.5 - pointY) + 17.5 * (pointY - 8.5) + pointX * (8.5 - 3.5))/2.0);
		return (areaABC == areaPointBC + areaPointAC + areaPointAB);
	}
}
