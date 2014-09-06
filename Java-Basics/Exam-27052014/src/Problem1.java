package softUni;


import java.util.Scanner;

public class Problem1 {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		
		int countStacks = 0;
		int countBeers = 0;
		int realBeers = 0;
		
		
		while(true){
			String inputLine = input.nextLine();
			String[] line = inputLine.split(" ");
			if(inputLine.equals("End")){
				break;
			}
			
			if(line[1].equals("stacks")){
				countStacks += Integer.parseInt(line[0]);
				
			}else{
				countBeers += Integer.parseInt(line[0]);
			}
		
		}
		while(countBeers >= 20){
			//realBeers = countBeers - 20;
			countBeers -= 20;
			countStacks += 1;
		}
		System.out.println(countStacks + " stacks" + " + " + countBeers + " beers");

	}

}

//if(countBeers > 20){
//realBeers = countBeers - 20;
//countStacks += 1;
//}
