package problem02_1lvShop;

public abstract class ElectonicsProduct extends Product implements Buyable {

	protected GuaranteePeriod guaranteePeriod;
	
	public ElectonicsProduct(String name, double price, int quantity,
			AgeRestriction ageRestriction, GuaranteePeriod guaranteePeriod) {
		super(name, price, quantity, ageRestriction);

		this.guaranteePeriod = guaranteePeriod;
	}

	@Override
	public double getPrice() {
		// TODO Auto-generated method stub
		return super.getPrice();
	}

}
