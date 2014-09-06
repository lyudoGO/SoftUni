package softUni;

import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class Problem4 {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		//input.nextLine();
		String inputText = input.nextLine();
		Map<String, Integer> lineMap = new HashMap<>();
		Map<String, Map<String, Integer>> allLine = new HashMap<>();
		
		
		for (int i = 0; i < n; i++) {
			String[] words = inputText.split(" ");
			lineMap.put(words[0], Integer.parseInt(words[1]));
			allLine.put(words[3], lineMap);
			
		}
		
	}

}
