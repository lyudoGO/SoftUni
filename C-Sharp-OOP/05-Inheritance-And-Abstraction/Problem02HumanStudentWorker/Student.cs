using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem02HumanStudentWorker
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }

            set
            {
                if (!value.All(Char.IsLetterOrDigit))
                {
                    throw new ArgumentNullException("Faculty number  can only contain letters and digits!");
                }

                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentOutOfRangeException("Faculty number must be in range 5 to 10 symbol!");
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Faculty number: {0}; ", this.FacultyNumber) + base.ToString();
        }
    }
}