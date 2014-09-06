import java.util.ArrayList;
import java.util.Scanner;

public class CombineListsOfLetters {
	
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String inputLine1 = input.nextLine();
		String inputLine2 = input.nextLine();
		
		String[] line1 = inputLine1.split(" ");
		String[] line2 = inputLine2.split(" ");
		
		ArrayList<Character> l1 = new ArrayList<>();
		ArrayList<Character> l2 = new ArrayList<>();
		
		convertStringToListOfChar(l1, line1);
		convertStringToListOfChar(l2, line2);
				
		for (Character character1 : l1) {
			for (int i = l2.size()-1; i >= 0; i--) {
				if(character1.equals(l2.get(i))){
					l2.remove(i);
				}
			}					
		}
	    
		for (Character character2 : l2) {
			l1.add(character2);
		}
		
		for (Character character1 : l1) {
			System.out.printf(character1 + " ");
		}
	}

	private static void convertStringToListOfChar(ArrayList<Character> list, String[] line) {
		for (int i = 0; i < line.length; i++) {
			list.add(line[i].charAt(0));
		}
	}
}


//public static void main(String[] args) {
//	Scanner in = new Scanner(System.in);
//	ArrayList<Character> arrFL = new ArrayList<Character>();
//	ArrayList<Character> arrSL = new ArrayList<Character>();
//	ArrayList<Character> arrPrint = new ArrayList<Character>();
//
//
//	for (char ch : in.nextLine().toCharArray()) {
//		arrFL.add(ch);
//	}
//	for (char ch : in.nextLine().toCharArray()) {
//		arrSL.add(ch);
//	}
//	arrPrint.addAll(arrFL);
//
//
//	for (int i = 0; i < arrSL.size(); i++) {
//		if (arrFL.contains(arrSL.get(i))) {
//			continue;
//		} else {
//			arrPrint.add(' ');
//			arrPrint.add(arrSL.get(i));
//		}
//	}
//
//
//	for (int i = 0; i < arrPrint.size(); i++) {
//		System.out.print(arrPrint.get(i));
//	}
//}
