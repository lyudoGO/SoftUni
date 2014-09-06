import java.util.Scanner;


public class CountSpecifiedWord {

	public static void main(String[] args) {
		
		Scanner input = new Scanner(System.in);
		String inputsentence = input.nextLine();
		String word = input.nextLine();
	
		String[] arraySentence = inputsentence.split("[!,.@#$%^&*(){}<>?;:\'\"\\-_+=| ]+");
	
        int countWord = 0;
		for (int i = 0; i < arraySentence.length; i++) {
			if(arraySentence[i].toUpperCase().equals(word.toUpperCase()) || arraySentence[i].toLowerCase().equals(word.toLowerCase())){
				countWord++;
			}
			if(arraySentence[i].toUpperCase().equals(word.toLowerCase()) || arraySentence[i].toLowerCase().equals(word.toUpperCase())){
				countWord++;
			}
		}
		System.out.println(countWord);
	}
}
