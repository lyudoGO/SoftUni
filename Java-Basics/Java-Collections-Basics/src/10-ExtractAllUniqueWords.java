import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;
import java.util.TreeSet;


public class ExtractAllUniqueWords {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String inputText = input.nextLine().toLowerCase();
		String[] text = inputText.split("\\W+");
		
		Set<String> setText = new HashSet<>();
		for (int i = 0; i < text.length; i++) {
			setText.add(text[i]);
		}
		
		TreeSet<String> orderedSetText = new TreeSet(setText);
		
		orderedSetText.forEach(x -> System.out.print(x + " "));
	}
}
	
	
//public static void main(String[] args) {
//	Scanner in = new Scanner(System.in);
//	String[] text = in.nextLine().toLowerCase().split("\\W+");
//	Set<String> setWords = new TreeSet<>();
//	for (String word : text) {
//		setWords.add(word);
//	}
//
//
//	for (String word : setWords) {
//		System.out.print(word + " ");
//	}
//}
	






	
	/*ArrayList<String> listText = new ArrayList<>();
	
	convertStringToList(listText, text);
	
	removeDuplicatesFromList(listText);
	
	Collections.sort(listText);
	
	for (String string : listText) {
		System.out.print(string + " ");
	}*/
	/*public static void removeDuplicatesFromList(ArrayList<String> listText) {
        HashSet set = new HashSet(listText);
        listText.clear();
        listText.addAll(set);
   }

	private static void convertStringToList(ArrayList<String> listText, String[] text) {
		for (int i = 0; i < text.length; i++) {
			listText.add(text[i]);
		}
	}*/

