package model;

import java.util.HashSet;
import java.util.Set;

import javax.persistence.*;

@Entity
@Table(name="PROFESSORS")
public class Professor extends Person {
	
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name = "PROFESSORID")
    private int id;
	
	@Column(name = "TITLE")
	private String title;
	
	@ManyToMany 
    @JoinTable(name="DEPARTMENTSPROFESSORS")
	private Set<Department> departments;
	
	@OneToMany(mappedBy="professor")
	private Set<Course> courses;

	public Professor() {
		this.departments  = new HashSet<Department>();
		this.courses = new HashSet<Course>();
	}
	public Set<Course> getCourses() {
		return courses;
	}
	
	public void setCourses(Set<Course> courses) {
		this.courses = courses;
	}
	
	public Set<Department> getDepartments() {
		return departments;
	}
	
	public void setDepartments(Set<Department> departments) {
		this.departments = departments;
	}
	
	public String getTitle() {
		return title;
	}
	
	public void setTitle(String title) {
		this.title = title;
	}
}
