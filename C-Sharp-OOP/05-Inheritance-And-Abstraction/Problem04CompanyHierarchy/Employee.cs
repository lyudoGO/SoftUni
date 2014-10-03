using System;

namespace Problem04CompanyHierarchy
{
    class Employee : Person, IEmployee
    {
        private decimal salary;
        private Department department;

        public Employee(uint id, string firstName, string lastName, decimal salary, Department department)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public decimal Salary 
        {
            get { return this.salary; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Salary cannot be negative!");
                }
                this.salary = value;
            }
        }

        public Department Department 
        {
            get { return this.department; }
            set { this.department = value; }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(" Salary: {0}LV; Departamnet: {1}", this.salary, this.department);
        }
    }
}
