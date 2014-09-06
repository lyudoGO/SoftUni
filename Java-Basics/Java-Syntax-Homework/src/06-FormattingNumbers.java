import java.util.Scanner;


public class FormattingNumbers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		//Scanner inputDouble = new Scanner(System.in);
		int a = input.nextInt();
		double b = input.nextDouble();
		double c = input.nextDouble();
		String aHex = Integer.toHexString(a);
		String aBinary = Integer.toBinaryString(a);
		System.out.printf("|%-10s" , aHex);
		System.out.printf("|" + String.format("%10s", aBinary).replace(" ", "0"));
		System.out.printf("|%10.2f" , b);
		System.out.printf("|%-10.3f|" , c);
	}
}

