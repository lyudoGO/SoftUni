using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem03to14ClassStudent
{
    class StudentSpecialty
    {
        private string specialtyName;
        private long facultyNumber;

        public StudentSpecialty(string specialtyName, long facultyNumber)
        {
            this.specialtyName = specialtyName;
            this.facultyNumber = facultyNumber;
        }

        public string SpecialtyName
        {
            get { return this.specialtyName; }
            set { this.specialtyName = value; }
        }

        public long FacultyNumber
        {
            get { return this.facultyNumber; }
            set { this.facultyNumber = value; }
        }
    }
}