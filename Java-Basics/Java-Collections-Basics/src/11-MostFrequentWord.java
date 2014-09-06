import java.util.Scanner;
import java.util.TreeMap;


public class MostFrequentWord {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String inputText = input.nextLine().toLowerCase();
		String[] words = inputText.split("\\W+");
				
		TreeMap<String, Integer> wordsMap = new TreeMap<String, Integer>();
		
		int maxCountWord = 0;
		
		for (String word : words) {
			Integer countWord = wordsMap.get(word);
			if (countWord == null) {
				countWord = 0; 
			}
			if(maxCountWord < countWord + 1){
				maxCountWord = countWord + 1;
			}
			wordsMap.put(word, countWord+1);
		}
					
		for (String word : wordsMap.keySet()) {
			int count = wordsMap.get(word);
			if (count == maxCountWord) {
				System.out.printf("%s -> %d times\n", word, count);
			}
		}		
	}
}




// Map<String, Integer> grades = new HashMap<>();
// grades.put("Pesho", 5);
// for(String key : grades.keySet())
//{ System.out.println("" + key + "" + grades.get(key));}
//
//Map<String, ArrayListInteger> grades = new HashMap<>();
// grades.put("Pesho", new ArrayList<Integer>(ArrayasList(5, 3)));












  /*	int maxCountWord = findMostFrequentWord(text);
	
	printMostFrequentWord(text, maxCountWord);*/
	/*private static void printMostFrequentWord(String[] text, int maxCountWord) {
		for (int i = 0; i < text.length; i++){
            int j = 0;
            int countWord = 0;
            
            for (j = i; j < text.length; j++){
                if (text[i].equals(text[j])){ countWord++; }
                else{ break; }
            }
            if(countWord == maxCountWord){
            	System.out.printf("%s -> %s times", text[i], countWord );;
            	System.out.println();
            }
            i = j - 1;
        }
	}

	private static int findMostFrequentWord(String[] text) {
		Arrays.sort(text);
		int maxCountWord = 0;
       
        for (int i = 0; i < text.length; i++){
            int j = 0;
            int countWord = 0;
            
            for (j = i; j < text.length; j++){
                if (text[i].equals(text[j])){ countWord++; }
                else{ break; }
            }
            if(countWord > maxCountWord){
            	maxCountWord = countWord;
            }
            i = j - 1;
        }
		return maxCountWord;
	}
*/

