using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem01School
{
    public class Discipline
    {
        private string name;
        private int numberLectures;
        private IList<Student> students;
        private string details;

        public Discipline(string name, int numberLectures, List<Student> students, string details = null)
        {
            this.Name = name;
            this.NumberLectures = numberLectures;
            this.Students = students;
            this.Details = details;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int NumberLectures
        {
            get
            {
                return this.numberLectures;
            }
            set
            {
                this.numberLectures = value;
            }
        }

        public IList<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                this.students = value;
            }
        }

        public string Details
        {
            get
            {
                return this.details;
            }
            set
            {
                this.details = value;
            }
        }
    }
}