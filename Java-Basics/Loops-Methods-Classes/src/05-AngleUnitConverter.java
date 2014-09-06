import java.util.Scanner;


public class AngleUnitConverter {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		input.nextLine();
		
		for(int i = 0; i < n; i++){
			String inputLine = input.nextLine();
			String[] inputSplit = inputLine.split(" ");
			double number = Double.parseDouble(inputSplit[0]);
			String measure = inputSplit[1];
			
			if(measure.equals("deg")){
				convertDegreesToRadians(number);
			}else{
				convertRadiansToDegrees(number);
			}
		}
	}
	
	private static void convertRadiansToDegrees(double number) {
		double degrees = number * 180 / Math.PI;
		System.out.printf("%.6f deg", degrees);
		System.out.println();
	}

	private static void convertDegreesToRadians(double number) {
		double radians = number *  Math.PI / 180;
		System.out.printf("%.6f rad", radians);
		System.out.println();
	}

}
