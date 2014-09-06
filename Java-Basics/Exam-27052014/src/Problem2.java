package softUni;

import java.math.BigDecimal;
import java.text.DecimalFormat;
import java.util.Arrays;
import java.util.Locale;
import java.util.Scanner;

public class Problem2 {

	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		
		BigDecimal[]  numbers = new BigDecimal[n];
		
		for (int i = 0; i < numbers.length; i++) {
			numbers[i] = input.nextBigDecimal();
		}
		
		Arrays.sort(numbers);
		
		for (int i = numbers.length - 1; i >= numbers.length - 3; i--) {
			if(i < 0 || i > numbers.length){
				break;
			}
			
			System.out.println(numbers[i].toPlainString());
//			DecimalFormat formatter = new DecimalFormat("#.###");
//			System.out.println(formatter.format(numbers[i]));//
		}
	}

}
