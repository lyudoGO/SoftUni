package StudentSystem;

import java.util.*;

import javax.persistence.*;

@Entity
@Table(name="Students")
public class Student {
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
    private int id;

    //@Basic
    @Column(name = "Name", nullable = false, length = 50)
    private String name;
    
    //@Basic
    @Column(name="PhoneNumber", length = 15)
    private String phoneNumber;
    
    //@Basic
    @Column(name = "RegistrationDate", nullable = false)
    private Date registrationDate;
    
    //@Basic
    @Column(name = "Birthday")
    private Date birthday;
    
    @ManyToMany 
    @JoinTable(name="StudentsCourses")
    private Collection<Course> courses;
    
    @OneToMany(mappedBy="student")
    private Collection<Homework> homeworks;
    
    public Student() {
    	this.courses = new HashSet<Course>();
    	this.homeworks = new HashSet<Homework>();
    }
    
    public Student(String name, String phoneNumber, Date registrationDate, Date birthday) {
    	this.name = name;
    	this.phoneNumber = phoneNumber;
    	this.registrationDate = registrationDate;
    	this.birthday = birthday;
    }
    
    public int getId() { 
        return this.id; 
    }
    
    public void setId(int id) { 
    	this.id = id; 
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getName() {
        return this.name;
    }
    
    public void setPhoneNumber(String phone) {
    	this.phoneNumber = phone;
    }

    public String getPhoneNumber() {
        return this.phoneNumber;
    }

    public void setRegistrationDate(Date date) {
    	this.registrationDate = date;
    }

    public Date getRegistrationDate() {
        return this.registrationDate;
    }
    
    public void setBirthday(Date date) {
    	this.birthday = date;
    }

    public Date getBirthday() {
        return this.birthday;
    }
   
    public void setCourses(Collection<Course> courses) {
    	this.courses = courses;
    }
    
    public Collection<Course> getCourses() { 
    	return this.courses; 
    }
    
    public void setHomeworks(Collection<Homework> homeworks) {
    	this.homeworks = homeworks;
    }
    
    public Collection<Homework> getHomeworks() { 
    	return this.homeworks; 
    }

}
