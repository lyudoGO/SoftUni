package softUni;


import java.util.ArrayList;
import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

public class Problem3 {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		
		String[] numbers = input.nextLine().split("\\W+");
		int[] numss = new int[numbers.length];
		ArrayList<Integer> nums = new ArrayList<Integer>();
		 int count = 1;
		 int maxCount = 0;
		 
		convertStringToList(numbers, nums);
	    
		for (int i = 0; i < nums.size(); i++) {
			if(nums.indexOf(i) % 2 == 0){
				for (int j = i + 1; j < nums.size(); j++) {
					if(nums.indexOf(j) % 2 == 1){
						count++;
					}else{
						break;
					}
				}
			}
		}
	    
	    
	    for (Integer num : nums) {
			System.out.print(num);
		}
	}

	private static void convertStringToList(String[] numbers, ArrayList<Integer> nums) {
		for (int i = 0; i < numbers.length; i++) {
			if(numbers[i].equals("")){
				continue;
			}else{
				nums.add(Integer.parseInt(numbers[i]));
			}
		}
		
	}

}
