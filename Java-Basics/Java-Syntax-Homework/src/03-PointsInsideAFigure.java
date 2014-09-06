import java.util.Locale;
import java.util.Scanner;


public class PointsInsideAFigure {

	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		Scanner input = new Scanner(System.in);
		double pointX = input.nextDouble();
		double pointY = input.nextDouble();
		boolean isInsideRectA = (pointX >= 12.5 && pointX <= 22.5) && (pointY >= 6 && pointY <= 8.5);
		boolean isInsideRectB = (pointX >= 12.5 && pointX <= 17.5) && (pointY >= 8.5 && pointY <= 13.5);
		boolean isInsideRectC = (pointX >= 20 && pointX <= 22.5) && (pointY >= 8.5 && pointY <= 13.5);
		
		if(isInsideRectA || isInsideRectB || isInsideRectC ){
			System.out.println("Inside");
		}else{
			System.out.println("Outside");
		}
	}
}
