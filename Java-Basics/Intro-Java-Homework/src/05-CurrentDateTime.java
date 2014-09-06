import java.time.LocalDateTime;
//import java.util.Date;


public class CurrentDateTime {

	public static void main(String[] args) {
		System.out.printf("The current Date is: %1$tA %1$td.%1$tm.%1$tY\n", LocalDateTime.now());
		System.out.printf("The current Time is: %1$tH:%1$tM \n", LocalDateTime.now());
		//System.out.printf("The current Date is: %1$tA %1$td.%1$tm.%1$tY\n", new Date());
		//System.out.printf("The current Time is: %1$tH:%1$tM \n", new Date());
	}

}
