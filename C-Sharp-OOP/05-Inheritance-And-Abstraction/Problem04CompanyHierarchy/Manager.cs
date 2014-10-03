using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem04CompanyHierarchy
{
    class Manager : Employee, IManager
    {
        private IList<RegularEmployee> employees;

        public Manager(uint id, string firstName, string lastName, decimal salary, Department department, IList<RegularEmployee> employees)
            : base(id, firstName, lastName, salary, department)
        {
            this.Employees = employees;
        }

        public IList<RegularEmployee> Employees 
        {
            get { return this.employees; }
            set { this.employees = value; }
        }

        public override string ToString()
        {
            string employeesStr = string.Join("\n", this.employees);
            return "Manager -> " + base.ToString() + string.Format("\nEmployees under command:\n{0}\n", employeesStr);
        }
    }
}
