import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;


public class CardsFrequencies {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		
		String[] cards = input.nextLine().split("[ \\u2660\\u2663\\u2665\\u2666]+");
		int n = cards.length;
		
		Map<String, Integer> mapCards = new LinkedHashMap<String, Integer>();
		
		for (String card : cards) {
			Integer countCards = mapCards.get(card);
			if (countCards == null){
				countCards = 0;
			}
			mapCards.put(card, countCards + 1);
		}
		
		for (Map.Entry<String, Integer> entry : mapCards.entrySet()){
			double frequency = (double)entry.getValue() * 100 / n;
			System.out.printf("%s -> %.2f%%", entry.getKey(), frequency );
			System.out.println();
		}
    }
}


