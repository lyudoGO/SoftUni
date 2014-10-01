Taks Functional Programming

Problem 1.StringBuilder Extensions          
Implement the following extension methods for the class StringBuilder:       
  •	Substring(int startIndex, int length) – returns a new String object, containing the elements in the given range.    
  Throw an exception when the range is invalid.         
  •	RemoveText(string text) – removes all occurrences of the specified text (case-insensitive) from the StringBuilder.       
  The method should not create a new StringBuilder, but should modify the existing one and return it as a result.       
  •	AppendAll<T>(IEnumerable<T> items) – appends the string representations of all items from the specified collection.         
  Use ToString() to convert from T to string.         
Write a program to demonstrate that your new extension methods work correctly.            

Problem 2.Custom LINQ Extension Methods           
Create your own LINQ extension methods:         
  •	public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate) { … } –       
  works just like Where(predicate) but filters the non-matching items from the collection.            
  •	public static IEnumerable<T> Repeat<T>(this IEnumerable<T> collection, int count) { … } –           
  repeats the collection count times.              
  •	public static IEnumerable<string> WhereEndsWith<string>(this IEnumerable<string> collection, IEnumerable<string> suffixes) –  
  filters all items from the collection that ends with some of the specified suffixes.        
  
Problem 3.Class Student       
Create a class Student with properties FirstName, LastName, Age, FacultyNumber, Phone, Email, Marks (IList<int>),      
GroupNumber. Create a List<Student> with sample students. These students will be used for the next few tasks.     

Problem 4.Students by Group       
Print all students from group number 2. Use a LINQ query. Order the students by FirstName.          

Problem 5.Students by First and Last Name       
Print all students whose first name is before their last name alphabetically. Use a LINQ query.           

Problem 6.Students by Age           
Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.          
The query should return only the first name, last name and age.             

Problem 7.Sort Students               
Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name          
in descending order. Rewrite the same with LINQ query syntax.             

Problem 8.Filter Students by Email Domain           
Print all students that have email @abv.bg. Use LINQ.               

Problem 9.Filter Students by Phone              
Print all students with phones in Sofia (starting with 02 / +3592 / +359 2). Use LINQ.            

Problem 10.Excellent Students             
Print all students that have at least one mark Excellent (6). Using LINQ first select them into a new anonymous class           
that holds { FullName + Marks}.           

Problem 11.Weak Students              
Write a similar program to the previous one to extract the students with exactly two marks "2". Use extension methods.          

Problem 12.Students Enrolled in 2014              
Extract and print the Marks of the students that enrolled in 2014 (the students from 2014 have 14 as their 5-th and       
6-th digit in the FacultyNumber).         

Problem 13.* Students by Groups                 
Add a GroupName property to Student. Write a program that extracts all students grouped by GroupName and then prints them        
on the console. Print all group names along with the students in each group. Use the "group by into" LINQ operator.         

Problem 14.* Students Joined to Specialties         
Create a class StudentSpecialty that holds specialty name and faculty number. Create a list of student specialties,         
where each specialty corresponds to a certain student (via the faculty number). Print all student names alphabetically along      
with their faculty number and specialty name. Use the "join" LINQ operator.             












