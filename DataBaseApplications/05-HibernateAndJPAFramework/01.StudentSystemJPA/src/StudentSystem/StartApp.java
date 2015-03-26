/*Problem 1.	Create a Database for Student System using JPA
Using JPA and Hibernate, create a data layer for a student system.
Use the "code first" approach and annotated Java entity classes (no XML mappings). 
Define the following entities:
•	Student: id, name, phone number, registration date, birthday
•	Course: id, name, description, start date, end date, price
•	Resource: id, name, type of resource (video / presentation / document / other), link
•	Homework: id, content, content-type (e.g. application/pdf or application/zip), date and time
Additional requirements:
•	Students can attend many courses
•	Courses can have many students
•	Courses can have many resources
•	One course can have many homework submissions
•	Homework submissions have a student (author) and a course
Add navigational properties in all models to simplify navigation.
Write a console application to add a few students, courses, resources and homework. 
Implement listing of all students along with their courses and homework submissions. 
Implement listing of all courses along with their resources. 
List all homework submissions along with their course and student. 
Find any "N+1 query problems" and fix them.*/

package StudentSystem;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.math.BigDecimal;
import java.util.*;
import java.util.stream.Collectors;

import javax.persistence.*;

public class StartApp {

	public static void main(String[] args) throws ParseException {
		
		  SimpleDateFormat formatter = new SimpleDateFormat("yyyy/MM/dd");
		  
		  ArrayList<Student> students = CreateSomeStudents(formatter);
		  ArrayList<Course> courses = CreateSomeCourses(formatter);
		  ArrayList<Resource> resources = CreateSomeResourses();
		  ArrayList<Homework> homeworks = CreateSomeHomeworks(formatter);
		
	      EntityManagerFactory emFactory = Persistence.createEntityManagerFactory( "StudentSystem" );
	      EntityManager entityManager = emFactory.createEntityManager( );
	      
	      entityManager.getTransaction( ).begin( );
	      
	      // Seed students courses
	      students.get(0).setCourses(new ArrayList<Course>() {{ add(courses.get(0)); }});
	      students.get(1).setCourses(new ArrayList<Course>() {{ add(courses.get(0)); add(courses.get(2));}});
	      students.get(2).setCourses(new ArrayList<Course>() {{ add(courses.get(0)); add(courses.get(2)); }});
	      
	      // Seed students homeworks
	      students.get(0).setHomeworks(new ArrayList<Homework>() {{ add(homeworks.get(0)); }});
	      students.get(1).setHomeworks(new ArrayList<Homework>() {{ add(homeworks.get(1)); add(homeworks.get(3)); }});
	      students.get(2).setHomeworks(new ArrayList<Homework>() {{ add(homeworks.get(2)); add(homeworks.get(4)); }});
	      
	      // Seed courses for resources
	      resources.get(0).setCourse(new ArrayList<Course>() {{ add(courses.get(1)); add(courses.get(2)); }});
	      resources.get(1).setCourse(new ArrayList<Course>() {{ add(courses.get(0)); add(courses.get(1)); add(courses.get(2)); }});
	      resources.get(2).setCourse(new ArrayList<Course>() {{ add(courses.get(1)); }});
	      
	      // Seed homeworks student and course
	      homeworks.get(0).setStudent(students.get(0));
	      homeworks.get(0).setCourse(courses.get(0));
	      homeworks.get(1).setStudent(students.get(1));
	      homeworks.get(1).setCourse(courses.get(0));
	      homeworks.get(2).setStudent(students.get(2));
	      homeworks.get(2).setCourse(courses.get(0));
	      homeworks.get(3).setStudent(students.get(1));
	      homeworks.get(3).setCourse(courses.get(2));
	      homeworks.get(4).setStudent(students.get(2));
	      homeworks.get(4).setCourse(courses.get(2));
	      
	      // Seed courses relationships
	      courses.get(0).setStudents(new ArrayList<Student>() {{ add(students.get(0)); add(students.get(1)); add(students.get(2));}});
	      courses.get(0).setResources(new ArrayList<Resource>() {{ add(resources.get(1)); }});
	      courses.get(0).setHomeworks(new ArrayList<Homework>() {{ add(homeworks.get(0)); add(homeworks.get(1)); add(homeworks.get(2));}});
	      
	      courses.get(1).setResources(new ArrayList<Resource>() {{ add(resources.get(1)); add(resources.get(2)); }});
	      
	      courses.get(2).setStudents(new ArrayList<Student>() {{ add(students.get(1)); add(students.get(2));}});
	      courses.get(2).setResources(new ArrayList<Resource>() {{ add(resources.get(0)); add(resources.get(1)); }});
	      courses.get(2).setHomeworks(new ArrayList<Homework>() {{ add(homeworks.get(3)); add(homeworks.get(4)); }});
	      
	      // Add to data base
	      entityManager.persist( students.get(0) );
	      entityManager.persist( students.get(1) );
	      entityManager.persist( students.get(2) );
	      
	      entityManager.persist( courses.get(0) );
	      entityManager.persist( courses.get(1) );
	      entityManager.persist( courses.get(2) );
	      
	      entityManager.persist( resources.get(0) );
	      entityManager.persist( resources.get(1) );
	      entityManager.persist( resources.get(2) );
	      
	      entityManager.persist( homeworks.get(0) );
	      entityManager.persist( homeworks.get(1) );
	      entityManager.persist( homeworks.get(2) );
	      entityManager.persist( homeworks.get(3) );
	      entityManager.persist( homeworks.get(4) );
	      
	      entityManager.getTransaction( ).commit( );
	      
	      // Lists all students with their courses and homework 
	      List<Student> allStudents = entityManager.createQuery("select s from Student s").getResultList();
	      
	      for (Student student : allStudents) {
	    	  Collection<Course> stuCourses = student.getCourses();
	    	  String coursesStr = stuCourses.stream().map(c -> c.getName()).collect(Collectors.joining(", "));
	    	  
	    	  Collection<Homework> stuHomeworks = student.getHomeworks();
	    	  String homeworksStr =	stuHomeworks.stream().map(h -> h.getContent()).collect(Collectors.joining(", "));
	    	  
			  System.out.printf("Student Name:%s -> Course:%s; Homeworks:%s;\n", student.getName(), coursesStr, homeworksStr);
		  }
	      
	      // List all courses with their resources
		  List<Course> allCourses = entityManager.createQuery("select c from Course c").getResultList();
	      
	      for (Course course : allCourses) {
	    	  Collection<Resource> currentResources = course.getResources();
	    	  String resourceStr = resourceStr = currentResources.stream().map(c -> c.getName()).collect(Collectors.joining(", "));
	    	  System.out.printf("Course Name:%s -> Resources:%s;\n", course.getName(), resourceStr);
		  }
	      
	      // List all homework with their course and student
	      List<Homework> allHomeworks = entityManager.createQuery("select h from Homework h").getResultList();
	      
	      for (Homework homework : allHomeworks) {
			System.out.printf("Homework:%s -> Course:%s -> Student:%s\n", homework.getContent(), homework.getCourse().getName(),
					homework.getStudent().getName());
		  }
	      
	      entityManager.close( );
	      emFactory.close( );

	}
	 
	private static ArrayList<Student> CreateSomeStudents(SimpleDateFormat formatter) throws ParseException {
		
		ArrayList<Student> students = new ArrayList<Student>();
		students.add(new Student("Ivan Ivanov", "+359888123456", formatter.parse("2014/12/30"), formatter.parse("1990/10/1")));
	    students.add(new Student("Maria Petrova", "+359888987654", formatter.parse("2014/5/10"), formatter.parse("1994/11/21")));
	    students.add(new Student("Gosho Goshev", "+359888259823", formatter.parse("2014/6/5"), formatter.parse("1992/12/9")));
	    
		return students;
	}
	
	private static ArrayList<Course> CreateSomeCourses(SimpleDateFormat formatter) throws ParseException {
		
		ArrayList<Course> courses = new ArrayList<Course>();
		courses.add(new Course("Basics JavaScript", "Course for begginers.", formatter.parse("2014/10/1"), 
				formatter.parse("2015/1/30"), new BigDecimal(325.5)));
		courses.add(new Course("Linux Administration", "Basics course for Linux.", formatter.parse("2014/12/10"), 
				formatter.parse("2015/3/30"), new BigDecimal(250)));
		courses.add(new Course("DataBase Applications", "Learn to use Entity Framework.", formatter.parse("2015/1/15"), 
				formatter.parse("2015/3/15"), new BigDecimal(450)));
	    
		return courses;
	}
	
	private static ArrayList<Resource> CreateSomeResourses() {
		
		ArrayList<Resource> resources = new ArrayList<Resource>();
		resources.add(new Resource("DataBase", ResourceType.Document, "www.database.org"));
		resources.add(new Resource("All Resources", ResourceType.Presentation, "www.softuni.bg"));
		resources.add(new Resource("Linux help", ResourceType.Presentation, "www.linux.org"));
	    
		return resources;
	}
	
	private static ArrayList<Homework> CreateSomeHomeworks(SimpleDateFormat formatter) throws ParseException {
		
		ArrayList<Homework> homeworks = new ArrayList<Homework>();
		homeworks.add(new Homework("JavaScript homework #1", ContentType.Zip,  formatter.parse("2014/12/1")));
		homeworks.add(new Homework("JavaScript homework #1", ContentType.Zip,  formatter.parse("2014/12/5")));
		homeworks.add(new Homework("JavaScript homework #1", ContentType.Zip,  formatter.parse("2014/12/1")));
		homeworks.add(new Homework("DataBase homework #4", ContentType.Zip,  formatter.parse("2015/1/29")));
		homeworks.add(new Homework("DataBase homework #4", ContentType.Zip,  formatter.parse("2015/1/30")));
		
		return homeworks;
	}
}