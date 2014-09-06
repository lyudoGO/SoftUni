public class FullHouse {

	public static void main(String[] args) {
		String[] cardFaces = { "2", "3", "4", "5", "6", "7", "8", "9", "10",
				"J", "Q", "K", "A" };
		char[] cardSuits = { '\u2663', '\u2666', '\u2665', '\u2660' };
		int countFulls = 0;
		for (int f = 0; f < cardFaces.length; f++) {
			for (int f1 = 0; f1 < cardFaces.length ; f1++) {
				for (int s1 = 0; s1 < cardSuits.length; s1++) {
					for (int s2 = s1 + 1; s2 < cardSuits.length; s2++) {
						for (int s3 = s2 + 1; s3 < cardSuits.length; s3++) {
							for (int s4 = 0; s4 < cardSuits.length; s4++) {
								for (int s5 = s4 + 1; s5 < cardSuits.length; s5++) {
									if(f != f1){
									countFulls++;
									System.out.printf("%1$s%3$c %1$s%4$c %1$s%5$c %2$s%6$c %2$s%7$c\n", cardFaces[f],cardFaces[f1],cardSuits[s1],cardSuits[s2],cardSuits[s3],cardSuits[s4],cardSuits[s5]);
									}
								}
							}
						}
					}
				}
			}
		}
		System.out.println(countFulls + " full houses");
	}
}
