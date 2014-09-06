import java.util.Scanner;

public class Generate3LetterWords {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		char[] letters = input.nextLine().toCharArray();
				
		for(int l1 = 0; l1 < letters.length; l1++){
			for(int l2 = 0; l2 < letters.length; l2++){
				for(int l3 = 0; l3 < letters.length; l3++){
					System.out.printf("%s%s%s ", letters[l1],letters[l2],letters[l3]);
				}
			}
		}
	}
}
