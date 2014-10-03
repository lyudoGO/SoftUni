using System;
using System.Collections.Generic;

namespace Problem04CompanyHierarchy
{
    interface ISalesEmployee
    {
        IList<Sale> Sales { get; set; }    
    }
}
