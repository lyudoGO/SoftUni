package StudentSystem;

import java.math.BigDecimal;
import java.util.*;

import javax.persistence.*;

@Entity
@Table(name="Courses")
public class Course {
	
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
    private int id;

    //@Basic
    @Column(name="Name", nullable = false, length = 100)
    private String name;
    
    //@Basic
    @Column(name="Description", length = 300)
    private String description;
    
  //@Basic
    @Column(name = "StartDate", nullable = false)
    private Date startDate;
    
    //@Basic
    @Column(name = "EndDate", nullable = false)
    private Date endDate;
    
    //@Basic
    @Column(name = "Price", nullable = false)
    private BigDecimal price;
    
    @ManyToMany(mappedBy="courses")
    private Collection<Student> students;
    
    @ManyToMany(mappedBy="courses")
    private Collection<Resource> resources;
    
    @OneToMany(mappedBy="course")
    private Collection<Homework> homeworks;
    
    public Course() {
    	this.students = new HashSet<Student>();
    	this.homeworks = new HashSet<Homework>();
    	this.resources = new HashSet<Resource>();
    }
    
    public Course(String name, String description, Date startDate, Date endDate, BigDecimal price) {
    	this.name = name;
    	this.description = description;
    	this.startDate = startDate;
    	this.endDate = endDate;
    	this.price = price;
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
    
    public void setDescription(String description) {
        this.description = description;
    }

    public String getDescription() {
        return this.description;
    }
    
    public void setStartDate(Date date) {
    	this.startDate = date;
    }

    public Date getStartDate() {
        return this.startDate;
    }
    
    public void setEndDate(Date date) {
    	this.endDate = date;
    }

    public Date getEndDate() {
        return this.endDate;
    }
    
    public void setPrice(BigDecimal price) {
    	this.price = price;
    }
    
    public BigDecimal getPrice() {
    	return this.price;
    }
    
    public void setStudents(Collection<Student> students) {
    	this.students = students;
    }
    
    public Collection<Student> getStudents() { 
    	return this.students; 
    }
    
    public void setResources(Collection<Resource> resources) {
    	this.resources = resources;
    }
    
    public Collection<Resource> getResources() { 
    	return this.resources; 
    }
    
    public void setHomeworks(Collection<Homework> homeworks) {
    	this.homeworks = homeworks;
    }
    
    public Collection<Homework> Homeworks() { 
    	return this.homeworks; 
    }
}
