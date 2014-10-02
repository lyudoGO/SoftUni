using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem01School
{
    public class School
    {
        private IList<Classes> classes;

        public School(List<Classes> classes)
        {
            this.Classes = classes;
        }

        public IList<Classes> Classes
        {
            get
            {
                return this.classes;
            }
            set
            {
                this.classes = value;
            }
        }
    }
}