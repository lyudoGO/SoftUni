using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem04CompanyHierarchy
{
    class Developer : RegularEmployee
    {
        private IList<Project> projects;

        public Developer(uint id, string firstName, string lastName, decimal salary, Department department, IList<Project> projects)
            : base(id, firstName, lastName, salary, department)
        {
            this.Projects = projects;
        }

        public IList<Project> Projects 
        {
            get { return this.projects; }
            set { this.projects = value; }
        }

        public override string ToString()
        {
            string projectStr = string.Join("\n", this.projects);
            return "\nDeveloper -> " + base.ToString() + string.Format("\n{0} work on projects:\n{1}", this.FirstName, projectStr);
        }
    }
}