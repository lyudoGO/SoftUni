import java.util.Scanner;


public class CountSubstringOccurrences {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String inputSentence = input.nextLine().toLowerCase();
		String inputString = input.nextLine().toLowerCase();
	
		String[] arraySentence = inputSentence.split("[!,.@#$%^&*(){}<>?;:\'\"\\-_+=| ]+");
	
        int countString = 0;
        for (int i = 0; i < arraySentence.length; i++) {
        	String word = arraySentence[i];
        	for (int j = 0; j <= word.length() - inputString.length() ; j++) {
        		if(word.substring(j, inputString.length() + j).contains(inputString)){
    				countString++;
    			}
			}
		}
        System.out.println(countString);
	}
}

//
//public static void main(String[] args) {
//	Scanner in = new Scanner(System.in);
//	String sentence = in.nextLine().toLowerCase();
//	String word = in.nextLine().toLowerCase();
//	int counter = 0;
//
//
//	for (int i = 0; i <= sentence.length() - word.length(); i++) {
//		if (sentence.substring(0 + i, word.length() + i).contains(word)) {
//			counter++;
//		}
//	}
//	System.out.println(counter);
//}
