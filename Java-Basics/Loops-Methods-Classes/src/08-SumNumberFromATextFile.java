import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;


public class SumNumberFromATextFile {

	public static void main(String[] args) {
		String fileName = "Input.txt";// This file must stay in home floder of project
		try(BufferedReader fileReader = new BufferedReader(new FileReader(fileName))){
			long sum = 0;
			while (true) {
				String line = fileReader.readLine();
				if(line == null){
					// End of file is reached
					break;
				}
				long number = Long.parseLong(line);
				sum = sum + number;
			}
			System.out.println(sum);
			
		}catch(IOException ioex){
			System.err.println("Error");
			ioex.printStackTrace();
		}
	}
}
