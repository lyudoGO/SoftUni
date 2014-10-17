package problem02_1lvShop;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class Problem02 {

	public static void main(String[] args) {
		
		FoodProduct cigars = new FoodProduct("Arda bez filter", 6.90, 1400, AgeRestriction.ADULT, "29/10/2015");
		FoodProduct bananas = new FoodProduct("Bananas", 2.90, 200, AgeRestriction.NONE, "29/10/2014");
		FoodProduct rakia = new FoodProduct("Rakia", 12.90, 250, AgeRestriction.ADULT, "29/10/2016");
		Appliance  breadMachine = new Appliance("Bread machine", 195.99, 23, AgeRestriction.NONE);
		Computer lenovo = new Computer("Lenovo G505", 399.00, 10, AgeRestriction.NONE);
		
		Customer pecata = new Customer("Pecata", 17, 30.00);
		Customer gopeto = new Customer("Gopeto", 18, 1.44);
		Customer mara = new Customer("Mara", 22, 235.00);
	
		try {
			PurchaseManager.ProcessPurchase(cigars, pecata);
		}  catch (Exception  e) {
			System.err.println(e.getMessage());
		} 
		
		try {
			PurchaseManager.ProcessPurchase(cigars, gopeto);

		} catch (Exception e) {
			System.err.println(e.getMessage());
		}
		
		try {
			PurchaseManager.ProcessPurchase(lenovo, mara);

		} catch (Exception e) {
			System.err.println(e.getMessage());
		}
		
		try {
			PurchaseManager.ProcessPurchase(bananas, mara);

		} catch (Exception e) {
			System.err.println(e.getMessage());
		}
		
		List<Product> products = new ArrayList<Product>();
		products.add(cigars);
		products.add(bananas);
		products.add(rakia);
		products.add(breadMachine);
		products.add(lenovo);
		
		Product expirableProduct = products
				.stream()
				.filter(e -> e instanceof Expirable)
				.sorted((e, e1) -> (int)(((FoodProduct)e).getExpirationDate().getTime() > ((FoodProduct)e1).getExpirationDate().getTime() ? 
						((FoodProduct)e).getExpirationDate().getTime():((FoodProduct)e1).getExpirationDate().getTime()))
				.findFirst()
				.get();
		
		List<Product> sortByAdultRestr = products
				.stream()
				.filter(e -> e.getAgeRestriction() == AgeRestriction.ADULT)
				.sorted((e, e1) -> (int)(e.getPrice() - e1.getPrice()))
				.collect(Collectors.toList());
		
		for (Product product : sortByAdultRestr) {
			System.out.println(product.getName() + ": " + product.getPrice() + "lv");
		}
		
		System.out.println(expirableProduct.getName() + ": " + expirableProduct.getPrice() + "lv");
	}

}
