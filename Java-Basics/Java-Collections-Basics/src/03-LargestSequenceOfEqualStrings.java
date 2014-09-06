import java.util.Scanner;


public class LargestSequenceOfEqualStrings {

	public static void main(String[] args) {
		
		Scanner input = new Scanner(System.in);
		String inputLine = input.nextLine();
		
		String[] arrStr = inputLine.split(" ");
		
		int count = 1;
		int countTemp = 1;
		int index = 0;
		
		for (int i = 1; i < arrStr.length; i++) {
			if(arrStr[i].equals(arrStr[i-1])){
				countTemp++;
			}else{
				countTemp = 1;
			}
			if(countTemp > count){
				count = countTemp;
				index = i;
			}
		}
		
		for (int i = 0; i < count; i++) {
			System.out.print(arrStr[index] + " ");
		}
	}

}
