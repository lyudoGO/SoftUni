package problem02_1lvShop;

public class Appliance extends ElectonicsProduct {

	private String name;
	private double price;
	private int quantity;
	private AgeRestriction ageRestriction;
	static GuaranteePeriod guaranteePeriod;
	
	public Appliance(String name, double price, int quantity,
			AgeRestriction ageRestriction) {
		super(name, price, quantity, ageRestriction, guaranteePeriod);
		this.name = name;
		this.price = price;
		this.quantity = quantity;
		this.ageRestriction = ageRestriction;
		this.guaranteePeriod = GuaranteePeriod.APPLIANCE;
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

	public void setPrice(double price) {
		this.price = price;
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

	@Override
	public double getPrice() {

		if (this.quantity < 50) {
			this.price *= this.price * 1.05;
		}
		
		return this.price;
	}

}
