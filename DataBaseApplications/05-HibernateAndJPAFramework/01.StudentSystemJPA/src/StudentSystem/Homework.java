package StudentSystem;

import java.util.*;
import javax.persistence.*;

@Entity
@Table(name="Homeworks")
public class Homework {
	
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
    private int id;
	
    //@Basic
    @Column(name="Content", length = 300)
    private String content;
   
    //@Basic
    @Column(name="ContentType", nullable = false)
    private ContentType contentType;
    
    //@Basic
    @Column(name = "DateTime", nullable = false)
    private Date dateTime;
    
    @ManyToOne (cascade=CascadeType.ALL)
    private Student student;
    
    @ManyToOne (cascade=CascadeType.ALL)
    private Course course;
    
	public Homework() {
		
	}
	
	public Homework(String content, ContentType contentType, Date dateTime) {
		this.content = content;
		this.contentType = contentType;
		this.dateTime = dateTime;
	}
	
	public int getId() {
    	return id;
    }
    
    public void setId(int id) {
    	this.id = id;
    }
    
    public void setContent(String content) {
        this.content = content;
    }

    public String getContent() {
        return content;
    }
    
    public void setContentType(ContentType contentType) {
        this.contentType = contentType;
    }

    public ContentType getContentType() {
        return contentType;
    }
    
    public void setDateTime(Date date) {
    	this.dateTime = date;
    }

    public Date getDateTime() {
        return dateTime;
    }
    
    public Student getStudent() {
        return this.student;
    }

     public void setStudent(Student student) {
        this.student = student;
     }
     
     public Course getCourse() {
         return this.course;
     }

      public void setCourse(Course course) {
         this.course = course;
      }
}
