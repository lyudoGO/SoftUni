package problem02_1lvShop;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.text.ParseException;

public class FoodProduct extends Product implements Expirable {

	private String expirationDateStr;
	
	public FoodProduct(String name, double price, int quantity,
			AgeRestriction ageRestriction) {
		super(name, price, quantity, ageRestriction);

		this.expirationDateStr = "";
	}

	public FoodProduct(String name, double price, int quantity,
			AgeRestriction ageRestriction, String expirationDate) {
		super(name, price, quantity, ageRestriction);
		
		this.expirationDateStr = expirationDate;
	}

	public String getExpirationDateStr() {
		return expirationDateStr;
	}


	public void setExpirationDateStr(String expirationDate) {
		this.expirationDateStr = expirationDate;
	}

	@Override
	public Date getExpirationDate() {
		Date expirationDate = null;
		
		if (this.expirationDateStr.isEmpty()) {
			
			throw new NullPointerException("Non expiration date, you enter empty string!");
			
		} else {
			
				SimpleDateFormat formatter = new SimpleDateFormat("dd/MM/yyyy");
			 
				try {
	
					expirationDate = formatter.parse(this.expirationDateStr);
			 
				} catch (ParseException e) {
					System.out.println("Invalid date format, must be -> dd/MM/yyyy: " + this.expirationDateStr);
				}
		}
		
		return expirationDate;
	}

	@Override
	public double getPrice() {
		
		double price = super.getPrice();
		if (this.expirationDateStr.isEmpty()) {
			
			return price;
			
		} else {
					Date todayDate = new Date();
					long dayTodayDate = todayDate.getTime();
					long dayExpirationDate = getExpirationDate().getTime();
					
					if ((dayExpirationDate - dayTodayDate) / (60 * 60 * 24 * 1000) <= 15) {
						price *= 0.7;
					}
			   }
		
		return price;
	}
}
