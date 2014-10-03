using System;

namespace Problem04CompanyHierarchy
{
    interface IEmployee
    {
        decimal Salary { get; set; }

        Department Department { get; set; }
    }
}
