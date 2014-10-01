using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem03to14ClassStudent
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private int age;
        private long facultyNumber;
        private string phone;
        private string email;
        private IList<int> marks;
        private int groupNumber;
        private string groupName;

        public Student(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public Student(string firstName, string lastName, int age, long facultyNumber, string phone, string email, IList<int> marks, int groupNumber, string groupName) 
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FacultyNumber = facultyNumber;
            this.Phone = phone;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
            this.GroupName = groupName;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }
        
        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }
        
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
        
        public long FacultyNumber
        {
            get { return this.facultyNumber; }
            set { this.facultyNumber = value; }
        }
        
        public string Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public IList<int> Marks
        {
            get { return this.marks; }
            set { this.marks = new List<int>(value); }
        }

        public int GroupNumber
        {
            get { return this.groupNumber; }
            set { this.groupNumber = value; }
        }

        public string GroupName
        {
            get { return this.groupName; }
            set { this.groupName = value; }
        }

        public override string ToString()
        {
            string marksStr = string.Join(" ", this.marks);
            string nameStr = this.firstName + " " + this.lastName;
            if (this.facultyNumber == 0 || this.groupNumber == 0)
            {
                return string.Format("|{0,-20}|{1,-3}|{2,-14}|{3,-12}|{4,-25}|{5,-8}|{6,6}      |", nameStr, this.age, null, null, null, null, null );
            }
            return string.Format("|{0,-20}|{1,-3}|{2,-14}|{3,-12}|{4,-25}|{5,-8}|{6,6}      |", nameStr, this.age, this.facultyNumber, 
                                this.phone, this.email, marksStr, this.groupNumber);
        }
    }
}