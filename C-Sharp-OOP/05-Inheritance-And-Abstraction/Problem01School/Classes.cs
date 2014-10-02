using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01School
{
    public class Classes
    {
        private string uniqueID;
        private IList<Teacher> teachers;
        private IList<Student> students;
        private string details;

        public Classes(string uniqueID, List<Teacher> teachers, List<Student> students, string details = null)
        {
            this.UniqueID = uniqueID;
            this.Teachers = teachers;
            this.Students = students;
            this.Details = details;
        }

        public string UniqueID
        {
            get
            {
                return this.uniqueID;
            }
            set
            {
                this.uniqueID = value;
            }
        }

        public IList<Teacher> Teachers
        {
            get
            {
                return this.teachers;
            }
            set
            {
                this.teachers = value;
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