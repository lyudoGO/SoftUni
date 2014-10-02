using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem01School
{
    public class Student : People
    {
        private int classNumber;

        public Student(string name, int classNumber, string details = null)
            : base(name, details)
        {
            this.ClassNumber = classNumber;
        }

        public int ClassNumber
        {
            get
            {
                return this.classNumber;
            }
            set
            {
                this.classNumber = value;
            }
        }
    }
}