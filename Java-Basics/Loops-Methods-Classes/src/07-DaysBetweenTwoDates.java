import java.util.Date;
import java.util.Scanner;
import java.text.ParseException;
import java.text.SimpleDateFormat;


public class DaysBetweenTwoDates {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String firstDate = input.nextLine();
		String secondDate = input.nextLine();
	   
		SimpleDateFormat format = new SimpleDateFormat("dd-MM-yyyy");
		 
		try {
			Date date1 = format.parse(firstDate);
			Date date2 = format.parse(secondDate);
			//in milliseconds
			long diff = date2.getTime() - date1.getTime();
 
			//long diffSeconds = diff / 1000 % 60;
			//long diffMinutes = diff / (60 * 1000) % 60;
			//long diffHours = diff / (60 * 60 * 1000) % 24;
			long diffDays = diff / (24 * 60 * 60 * 1000);
 
			System.out.print(diffDays + " days");
			//System.out.print(", " + diffHours + " hours, ");
			//System.out.print(diffMinutes + " minutes, ");
			//System.out.print(diffSeconds + " seconds.");
 
		} catch (ParseException e) {
				e.printStackTrace();
		};
	
	}

}
