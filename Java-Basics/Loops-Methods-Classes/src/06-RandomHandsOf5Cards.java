import java.util.Random;
import java.util.Scanner;


public class RandomHandsOf5Cards {

	public static void main(String[] args) {
		String[] cardFaces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A",  };
		char[] cardSuits = { '\u2663', '\u2666','\u2665', '\u2660'};
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		Random rand = new Random();
		
		for(int i = 0; i < n; i++){
			int fR = rand.nextInt(13);
			int fR1 = rand.nextInt(13);
			int fR2 = rand.nextInt(13);
			int fR3 = rand.nextInt(13);
			int fR4 = rand.nextInt(13);
			int sR = rand.nextInt(4);
			int sR1 = rand.nextInt(4);
			int sR2 = rand.nextInt(4);
			int sR3 = rand.nextInt(4);
			int sR4 = rand.nextInt(4);
			System.out.print(cardFaces[fR] + cardSuits[sR] + " " + cardFaces[fR1] + cardSuits[sR1] + " " + cardFaces[fR2] + cardSuits[sR2]);
			System.out.print(" " + cardFaces[fR3] + cardSuits[sR3] + " " + cardFaces[fR4] + cardSuits[sR4] + "\n");
		}
	}

}
