import java.util.Scanner;


public class CountOfBitsOne {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		int countBits = 0;
		for(int i = 0; i < 32; i++){
			int result = n & 1;
			if(result == 1){
				countBits++;
			}
			n  = n >> 1;
		}
		System.out.println(countBits);
	}
}

