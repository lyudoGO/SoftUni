import java.util.Scanner;


public class TheSmallestOf3Numbers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		double a = input.nextDouble();
		double b = input.nextDouble();
		double c = input.nextDouble();
		double smallest = 0;
		if(a < b && a < c){
			smallest = a;
		}else if(b < a && b < c){
			smallest = b;
		}else{
			smallest = c;
		}
		System.out.println(smallest);

	}

}
