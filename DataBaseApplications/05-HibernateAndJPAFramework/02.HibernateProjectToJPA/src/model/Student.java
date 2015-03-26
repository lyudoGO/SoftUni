package model;

import java.util.HashSet;
import java.util.Set;
import javax.persistence.*;

@Entity
@Table(name="STUDENTS")
public class Student extends Person {
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name = "STUDENTID")
    private int id;
	
	@Column(name = "FACULTYNUMBER")
	private String facultyNumber;
	
	@ManyToMany 
    @JoinTable(name="COURSESSTUDENTS")
	private Set<Course> courses;
	
    public Student() {
    	this.courses = new HashSet<Course>();
    }
    
	public Set<Course> getCourses() {
		return courses;
	}
	
	public void setCourses(Set<Course> courses) {
		this.courses = courses;
	}
	
	public String getFacultyNumber() {
		return facultyNumber;
	}
	
	public void setFacultyNumber(String facultyNumber) {
		this.facultyNumber = facultyNumber;
	}
	
}
