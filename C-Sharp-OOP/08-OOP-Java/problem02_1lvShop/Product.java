package problem02_1lvShop;

public abstract class Product implements Buyable {
	
	private String name;
	private double price;
	private int quantity;
	private AgeRestriction ageRestriction;
	
	public Product(String name, double price, int quantity, AgeRestriction ageRestriction) {
		super();
		this.name = name;
		this.price = price;
		this.quantity = quantity;
		this.ageRestriction = ageRestriction;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		if (name.isEmpty() || name.length() < 3) {
			
			throw new IllegalArgumentException("Name must be at least 3 symbol: " + name);
		}
		
		this.name = name;
	}

	public int getQuantity() {
		return quantity;
	}

	public void setQuantity(int quantity) {
		
		if (quantity < 0) {
			
		      throw new IllegalArgumentException("Quantity of product cannot be negative: " + quantity);
		}
		this.quantity = quantity;
	}

	public AgeRestriction getAgeRestriction() {
		return ageRestriction;
	}

	public void setAgeRestriction(AgeRestriction ageRestriction) {
		this.ageRestriction = ageRestriction;
	}

	public void setPrice(double price) {
		this.price = price;
	}

	@Override
	public double getPrice() {
		return this.price;
	} 
}
