package model;

import java.util.HashSet;
import java.util.Set;
import javax.persistence.*;

@Entity
@Table(name="DEPARTMENTS")
public class Department {
	
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name = "DEPTID")
	private long deptId;
	
	@Column(name = "DEPTNAME")
	private String name;
	
	@ManyToMany 
    @JoinTable(name="DEPARTMENTSPROFESSORS")
	private Set<Professor> professors;
	
	@OneToMany(mappedBy="department")
	private Set<Course> courses;

    public Department() {
    	this.professors = new HashSet<Professor>();
    	this.courses = new HashSet<Course>();
    }
    
	public Set<Course> getCourses() {
		return courses;
	}
	
	public void setCourses(Set<Course> courses) {
		this.courses = courses;
	}
	
	public long getDeptId() {
		return deptId;
	}
	
	public void setDeptId(long deptId) {
		this.deptId = deptId;
	}
	
	public String getName() {
		return name;
	}
	
	public void setName(String name) {
		this.name = name;
	}
	
	public Set<Professor> getProfessors() {
		return professors;
	}
	
	public void setProfessors(Set<Professor> professors) {
		this.professors = professors;
	}
}
