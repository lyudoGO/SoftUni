
public class FullHouseWithJokers {

	public static void main(String[] args) {
		
	String[] cardFaces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
	char[] cardSuits = { '\u2663', '\u2666','\u2665', '\u2660'};
	String[][] cards = new String[cardFaces.length][cardSuits.length];
	
	long countFulls = 0;
	
	for (int row = 0; row < cardFaces.length; row++) {
		for (int col = 0; col < cardSuits.length; col++) {
			cards[row][col] = cardFaces[row] + cardSuits[col];
		}
	}
	
		
	for (int row = 0; row < cardFaces.length; row++) {
	  for (int row1 = 0; row1 < cardFaces.length; row1++) {
		for (int p1 = 0; p1 < cardSuits.length; p1++) {    
			for (int p2	= p1 + 1; p2 < cardSuits.length; p2++) {
				for (int p3 = p2 + 1; p3 < cardSuits.length; p3++) {
					 for (int p4 = 0; p4 < cardSuits.length; p4++) {
						for (int p5 = p4 + 1; p5 < cardSuits.length; p5++) {
							if(row != row1){
						
								for (int tirth = 0; tirth < 8; tirth++) {
									
									String  tirthCards = cards[row][p1] + " " + cards[row][p2] + " " + cards[row][p3];
									
									switch (tirth) {
										case 1:	tirthCards = cards[row][p1] + " " + cards[row][p2] + " *";break;										
										case 2:	tirthCards = cards[row][p1]  + " * " + cards[row][p3];break;								
										case 3:	tirthCards = cards[row][p1] + " * " + "*";break;									
										case 4:	tirthCards =  "* " + cards[row][p2] + " " + cards[row][p3];break;
									    case 5:	tirthCards = "* " + cards[row][p2] + " *";break;
									    case 6:	tirthCards = "*" + " * " + cards[row][p3];break;							
										case 7:	tirthCards = "*" + " * " + "*";break;									
									  	default:break;
									}										
										for (int pair = 0; pair < 4; pair++) {
											switch (pair) {
												case 1:	System.out.printf("(%s %s *)\n", tirthCards,cards[row1][p4]);break;										
												case 2:	System.out.printf("(%s * %s)\n", tirthCards,cards[row1][p5]);break;										
												case 3:	System.out.printf("(%s * *)\n", tirthCards);break;										
												default:System.out.printf("(%s %s %s)\n", tirthCards,cards[row1][p4],cards[row1][p5]);break;
										    }
											countFulls++;
										}
								}
								
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
