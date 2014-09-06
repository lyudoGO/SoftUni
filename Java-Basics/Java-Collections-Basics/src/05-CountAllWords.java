import java.util.Arrays;
import java.util.Scanner;


public class CountAllWords {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String inputsentence = input.nextLine();
	
		String[] arraySentence = inputsentence.split("[!,.@#$%^&*(){}<>?;:\'\"\\-_+=| ]+");
		
		Arrays.sort(arraySentence);
		
        int countWord = 0;
		for (int i = 0; i < arraySentence.length; i++) {
			int j = 0;
           
            for (j = i; j < arraySentence.length; j++){
                if (arraySentence[i].equals(arraySentence[j])){
                	countWord++;
                }
                else{
                    break;
                }
            }
            i = j - 1;
		}
		System.out.println(countWord);
		System.out.println(arraySentence.length);
	}
}
