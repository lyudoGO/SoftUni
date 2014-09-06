import java.util.Scanner;


public class SymmetricNumbersInRange3Digits {

	public static void main(String[] args) {
		//work with tree digits number
		Scanner input = new Scanner(System.in);
		int start = input.nextInt();
		int end = input.nextInt();
		
			for(int i = start; i <= end; i++){
				int d1 = i / 100;
				int d2 = (i / 10) % 10;
				int d3 = i % 10;
				if(d1 == 0 && d2 == 0){
					System.out.printf("%d " ,i);
				}
				if(d1 == 0 && d2 == d3){
					System.out.printf("%d " ,i);
				}
				if(d1 != 0 && d1 == d3){
					System.out.printf("%d " ,i);
				}
		   }
	}
}
