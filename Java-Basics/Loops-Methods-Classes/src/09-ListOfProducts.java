import java.io.BufferedReader;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;


public class ListOfProducts {


	public static void main(String[] args){
		String fileName = "Input.txt";
		String newFileName = "Output.txt";
		
		ArrayList<Product> listOfProducts = new ArrayList<Product>();
		
		try (BufferedReader fileReader = new BufferedReader(new FileReader(fileName));
			 FileWriter fileWriter = new FileWriter(newFileName);){
			
			String line = fileReader.readLine();
			
			while (line != null) {
				
				String[] lines = line.split(" ");
				listOfProducts.add(new Product(lines[0], Double.parseDouble(lines[1])));
				line = fileReader.readLine();
			}
			
			Collections.sort(listOfProducts);
			
			for (Product item : listOfProducts) {
				fileWriter.write(item.getPrice() + " " + item.getName() + "\r\n");
			}
			fileReader.close();
			fileWriter.close();
		
		} catch (IOException ioex) {
			System.err.println("Error");
			ioex.printStackTrace();
		}
	}

}

class Product implements Comparable<Product>{
	private String name;
	private double price;
	
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public double getPrice() {
		return price;
	}
	public void setPrice(double price) {
		this.price = price;
	}
	public Product(String name, double price) {
		super();
		this.name = name;
		this.price = price;
	}
	public int compareTo(Product product) {
	      double price = product.getPrice();
		  if(this.price > price){
		        return 1;
		  }else if(this.price == price){
		        return 0;
		  }else{
		        return -1;
		  }
	} 		
}
