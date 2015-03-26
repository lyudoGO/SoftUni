package StudentSystem;

import java.util.*;
import javax.persistence.*;

@Entity
@Table(name="Resources")
public class Resource {
	
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
    private int id;
	
    //@Basic
    @Column(name = "Name", nullable = false, length = 100)
    private String name;
   
    //@Basic
    @Column(name = "TypeOfResource", nullable = false)
    private ResourceType typeOfResource;
    
    //@Basic
    @Column(name = "Link", length = 300)
    private String link;
    
    @ManyToMany 
    @JoinTable(name = "ResourcesCourses")
    private Collection<Course> courses;
    
	public Resource() {
		this.courses = new HashSet<Course>();
	}
	
	public Resource(String name, ResourceType typeOfResource, String link) {
		this.name = name;
		this.typeOfResource = typeOfResource;
		this.link = link;
	}
	
	public int getId() {
    	return id;
    }
    
    public void setId(int id) {
    	this.id = id;
    }
    
    public void setName(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }
    
    public void setTypeOfResource(ResourceType typeOfResource) {
        this.typeOfResource = typeOfResource;
    }

    public ResourceType getTypeOfResource() {
        return typeOfResource;
    }
    
    public void setLink(String link) {
        this.link = link;
    }

    public String getLink() {
        return link;
    }
    
    public Collection<Course> getCourse() {
        return this.courses;
    }

     public void setCourse(Collection<Course> courses) {
        this.courses = courses;
     }
}
