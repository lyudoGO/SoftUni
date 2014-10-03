using System;

namespace Problem04CompanyHierarchy
{
    interface IPerson
    {
        uint Id { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }
    }
}