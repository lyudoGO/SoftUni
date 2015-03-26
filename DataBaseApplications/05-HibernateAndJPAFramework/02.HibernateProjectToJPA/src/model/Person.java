package model;

import javax.persistence.*;

@Entity
@Table(name="PERSONS")
public abstract class Person {
	
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name = "PERSONID")
	private long personId;
	
	@Column(name = "FIRSTNAME")
	private String firstName;
	
	@Column(name = "LASTNAME")
	private String lastName;

	public Person() {
		
	}
	
	public String getFirstName() {
		return firstName;
	}
	
	public void setFirstName(String firstName) {
		this.firstName = firstName;
	}
	
	public String getLastName() {
		return lastName;
	}
	
	public void setLastName(String lastName) {
		this.lastName = lastName;
	}
	
	public long getPersonId() {
		return personId;
	}
	
	public void setPersonId(long personId) {
		this.personId = personId;
	}
}
