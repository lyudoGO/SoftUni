// Problem 7.	Employees with Corresponding Territories
// Your task is to create a class, which allows employees to access their corresponding territories 
// as property of the type EntitySet<T> by inheriting the Employee entity class or by using a partial class.

namespace SoftUniDBFirst
{
    using System;
    using System.Data.Linq;

    public  partial class Employee
    {
        private EntitySet<Territory> territories = new EntitySet<Territory>();

        public virtual EntitySet<Territory> Territories 
        { 
            get { return this.territories; } 
            set { this.territories = value;} 
        }
    }
}
