using System;
using System.Collections.Generic;

namespace Problem04CompanyHierarchy
{
    interface IDeveloper
    {
        IList<Project> Projects { get; set; }
    }
}
