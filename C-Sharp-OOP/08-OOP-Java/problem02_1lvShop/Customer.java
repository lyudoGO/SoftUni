package problem02_1lvShop;

public class Customer {

	private String name;
	private int age;
	private double balance;
	
	public Customer(String name, int age, double balance) {
		super();
		this.name = name;
		this.age = age;
		this.balance = balance;
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

	public int getAge() {
		return age;
	}

	public void setAge(int age) {
		
		if (age < 0 || age > 100) {
		      throw new IllegalArgumentException("Age not in range [0..100]: " + age);
		}
		
		this.age = age;
	}

	public double getBalance() {
		return balance;
	}

	public void setBalance(double balance) {
		this.balance = balance;
	}
	
	
}
