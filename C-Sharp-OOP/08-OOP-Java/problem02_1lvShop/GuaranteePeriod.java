package problem02_1lvShop;

public enum GuaranteePeriod {
	
	COMPUTER(24),
	APPLIANCE(6);
	
	private int value;

    private GuaranteePeriod(int value) {
            this.value = value;
    }
    
    @Override
    public String toString() {
    	
    	return "" + this.value;
    }
}
