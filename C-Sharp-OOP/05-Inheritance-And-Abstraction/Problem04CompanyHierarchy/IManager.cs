﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem04CompanyHierarchy
{
    interface IManager
    {
        IList<RegularEmployee> Employees { get; set; }
    }
}
