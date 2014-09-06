import java.util.Scanner;


public class LongestIncreasingSequence {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String inputLine = input.nextLine();
		String[] inputArr = inputLine.split(" ");
		int[] inputIntArr = new int[inputArr.length];
		
		for (int i = 0; i < inputIntArr.length; i++) {
			inputIntArr[i] = Integer.parseInt(inputArr[i]);
		}
		
		allIncreasingSequence(inputIntArr);
		
		longestIncreasingSequence(inputIntArr); 
	}

	private static void longestIncreasingSequence(int[] inputIntArr) {
		int longestCount = 0;
		int startIndex = 0;
		for (int i = 0; i < inputIntArr.length; i++) {
			int tempCount = 1;
			int index = i;
			for (int j = i + 1; j < inputIntArr.length; j++) {
				if(inputIntArr[index] < inputIntArr[j]){
					index = j;
					tempCount++;
					
				}else{
					break;
				}
			}
			if(tempCount > longestCount){
				longestCount = tempCount;
				startIndex = i;
			}
		}
		System.out.print("Longest: ");
		for (int i = startIndex; i < startIndex + longestCount; i++) {
			System.out.print(inputIntArr[i] + " ");
		}
	}

	private static void allIncreasingSequence(int[] inputIntArr) {
		for (int i = 0; i < inputIntArr.length; i++) {
			System.out.print(inputIntArr[i] + " ");//print first element of sequence
			for (int j = i + 1; j < inputIntArr.length; j++) {
				if(inputIntArr[i] < inputIntArr[j]){
					i = j;
					System.out.print(inputIntArr[j] + " ");//print next element of sequence
				}else{
					break;
				}
			}
			System.out.println();
		}
	}

}
