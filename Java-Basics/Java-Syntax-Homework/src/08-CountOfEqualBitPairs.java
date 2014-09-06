import java.util.Scanner;


public class CountOfEqualBitPairs {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		int countBitsPair = 0;
		while(n > 0){
				int firstBit = n & 1;
				int result  = n >> 1;
				int secondBit = result & 1;
				if(firstBit == secondBit){
					countBitsPair++;
				}
				n = n >> 1;
		}
		System.out.println(countBitsPair);	
	}
}
