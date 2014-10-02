using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem01School
{
    public class Teacher : People
    {
        private List<Discipline> disciplines;

        public Teacher(string name, List<Discipline> disciplines, string details = null)
            : base(name, details)
        {
            this.Disciplines = disciplines;
        }

        public List<Discipline> Disciplines
        {
            get
            {
                return this.disciplines;
            }
            set
            {
                this.disciplines = value;
            }
        }
    }
}