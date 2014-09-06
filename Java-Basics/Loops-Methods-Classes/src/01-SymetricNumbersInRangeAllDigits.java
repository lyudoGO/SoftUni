import java.util.Scanner;


public class SymetricNumbersInRangeAllDigits {

	public static void main(String[] args) {
		//work with all digits number
		Scanner input = new Scanner(System.in);
		int start = input.nextInt();
		int end = input.nextInt();
		
		for (int i = start; i <= end; i++) {
			String number = Integer.toString(i);
			String firstHalf = number.substring(0, number.length()/2);
			String secondHalf;
			if(number.length() % 2 == 0){
				secondHalf = number.substring(number.length()/2, number.length());
			}else{
				secondHalf = number.substring(number.length()/2 + 1, number.length());
			}
			
			String reverseSecondHalf = new StringBuilder(secondHalf).reverse().toString();
			
			if(firstHalf.equals(reverseSecondHalf)){
				System.out.printf("%s ", i);
			}
		}
	}
}
