import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class ExtractEmails {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String text = input.nextLine();
		Pattern emailPattern = Pattern.compile("[a-z0-9]+(\\.[-_a-z0-9]+)*@[a-z-a-z]+\\.[a-z]+");
		Matcher matcher = emailPattern.matcher(text);
		
		while (matcher.find()) {
		    System.out.println(matcher.group());
		}

	}

}
