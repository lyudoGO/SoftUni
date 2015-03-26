// Problem 7.	Employees with Corresponding Territories
// Your task is to create a class, which allows employees to access their corresponding territories 
// as property of the type EntitySet<T> by inheriting the Employee entity class or by using a partial class.

namespace SoftUniDBFirst
{
    using System;
    using System.Collections.Generic;

    public partial class Territory
    {
        public Territory()
        {
            this.Employees = new HashSet<Employee>();
        }

        public string TerritoryID { get; set; }
        public string TerritoryDescription { get; set; }
   
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
