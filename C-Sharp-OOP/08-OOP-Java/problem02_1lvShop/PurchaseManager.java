package problem02_1lvShop;

import java.util.Date;

public final class PurchaseManager {

	static void ProcessPurchase(Product product, Customer customer){
		
		long diffDays;
		double money = customer.getBalance();
		boolean isFoodProduct = product instanceof FoodProduct;
		Date today = new Date();
		
		int customerAge = customer.getAge();
		
		if (product.getQuantity() == 0) {
			throw new NullPointerException(customer.getName() + ", this product " + product.getName() + " is out of stock: " + product.getQuantity() + " quanty!");
		}
		
		if (money < product.getPrice()) {
			throw new IllegalArgumentException(customer.getName() + ", you do not have enough money to buy this product: " + product.getName());
		}
		
		if (customerAge <= 18 && product.getAgeRestriction() == AgeRestriction.ADULT) {
			throw new IllegalArgumentException(customer.getName() + ", you are too young to buy this product: " + product.getName());
		}
		
		diffDays = (((FoodProduct)product).getExpirationDate().getTime() - today.getTime()) / (60 * 60 * 24 * 1000);
		if (isFoodProduct && diffDays <= 15) {
			throw new IllegalArgumentException(customer.getName() + ", this product " + product.getName() + " has expired in: " + diffDays + " days!");
		}
	}
	
	
}