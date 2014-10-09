Problem 1.Customer            
Define a class Customer, which contains data about a customer – first name, middle name and last name, ID (EGN), 
permanent address, mobile phone, e-mail, list of payments and customer type.              
•	Define a class Payment which holds a product name and price.            
•	Define an enumeration for the customer type, holding the following types of customers: One-time , Regular, Golden,        
Diamond.              
•	Override the standard methods, inherited by System.Object: Equals(), ToString(), GetHashCode() and              
operators == and !=.                        
•	Implement the ICloneable interface. The Clone() method should make a deep copy of all object fields into a new              
object of type Customer.                  
•	Implement the IComparable<Customer> interface to compare customers by full name (as first criteria, in              
lexicographic order) and by ID (as second criteria, in ascending order).                    

Problem 2.String Disperser              
Define a class StringDisperser.                 
•	The constructor should take several strings as arguments.             
•	Override the standard methods, inherited by System.Object: Equals(), ToString(), GetHashCode()          
and operators == and !=.                
•	Implement the ICloneable interface. The Clone() method should make a deep copy of all object fields                 
into a new object of type StringDisperser.                  
•	Implement the IComparable<StringDisperser> interface to compare string dispersers by their total            
string value lexicographically.                 
•	Implement the IEnumerable interface to allow foreach on objects of type StringDisperser.            
The items returned should be the characters of each string.           

Problem 3.** Custom Tree            
Define the data structure binary search tree. It should support the following operations:           
•	Adding a new element          
•	Searching element                         
•	Deleting elements                       
It is not necessary to keep the tree balanced. Implement the standard methods from System.                    
Object – ToString(), Equals(), GetHashCode() and the operators for comparison  == and !=. ).                      
Implement IEnumerable<T> to traverse the tree.                      
Add and implement the ICloneable interface for deep copy of the tree.                               
Tip: Define two separate types – structure BinarySearchTree (for the tree) and class TreeNode (for the tree elements).                    


