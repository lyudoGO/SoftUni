import java.util.Scanner;


public class DecimalToHexadecimal {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int num = input.nextInt();
		String numHex = Integer.toHexString(num);
		System.out.println(numHex);
	}
}
