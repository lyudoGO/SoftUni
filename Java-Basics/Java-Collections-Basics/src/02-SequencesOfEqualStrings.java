import java.util.Scanner;


public class SequencesOfEqualStrings {

	public static void main(String[] args) {
		
		Scanner input = new Scanner(System.in);
		String inputLine = input.nextLine();
	
		String[] arrStr = inputLine.split(" ");
		
		System.out.print(arrStr[0] + " ");
		for (int i = 1; i < arrStr.length; i++) {
			if(arrStr[i].equals(arrStr[i - 1])){
					System.out.print(arrStr[i] + " ");
				}else{
					System.out.println();
					System.out.print(arrStr[i] + " ");
				}
		}
	}
}
