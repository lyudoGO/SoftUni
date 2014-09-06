import java.util.Arrays;
import java.util.Scanner;

public class SortArrayofStrings {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		input.nextLine();
		
		String[] names = new String[n];
		
		for(int i = 0; i < names.length; i++){
			
			names[i] = input.nextLine();
		}
		
		Arrays.sort(names);
		
		for(int i = 0; i < names.length; i++){
			System.out.println(names[i]);
		}
	}

}
