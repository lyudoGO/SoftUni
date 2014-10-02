using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem01School
{
    public abstract class People
    {
        private string name;
        private string details;

        protected People(string name, string details)
        {
            this.Name = name;
            this.Details = details;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Details
        {
            get
            {
                return this.details;
            }
            set
            {
                this.details = value;
            }
        }
    }
}
