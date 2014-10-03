using System;

namespace Problem04CompanyHierarchy
{
    class RegularEmployee : Employee
    {
        public RegularEmployee(uint id, string firstName, string lastName, decimal salary, Department department)
            : base(id, firstName, lastName, salary, department)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}