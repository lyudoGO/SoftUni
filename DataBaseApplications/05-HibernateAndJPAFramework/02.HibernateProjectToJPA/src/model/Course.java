package model;

import java.util.HashSet;
import java.util.Set;

import javax.persistence.*;

@Entity
@Table(name="COURSES")
public class Course {
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name = "COURSEID")
	private long courseId;
	
	@Column(name = "COURSENAME")
	private String name;
	
	@ManyToOne(cascade=CascadeType.ALL)
	private Professor professor;
	
	@ManyToOne(cascade=CascadeType.ALL)
	private Department department;
	
	@ManyToMany 
    @JoinTable(name="COURSESSTUDENTS")
	private Set<Student> students;

    public Course() {
    	this.students = new HashSet<Student>();
    }
    
	public long getCourseId() {
		return courseId;
	}
	
	public void setCourseId(long courseId) {
		this.courseId = courseId;
	}
	
	public Department getDepartment() {
		return department;
	}
	
	public void setDepartment(Department department) {
		this.department = department;
	}
	
	public String getName() {
		return name;
	}
	
	public void setName(String name) {
		this.name = name;
	}
	
	public Professor getProfessor() {
		return professor;
	}
	
	public void setProfessor(Professor professor) {
		this.professor = professor;
	}
	
	public Set<Student> getStudents() {
		return students;
	}
	
	public void setStudents(Set<Student> students) {
		this.students = students;
	}
}
