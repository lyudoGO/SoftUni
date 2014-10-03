using System;
using System.Linq;

namespace Problem04CompanyHierarchy
{
    public abstract class Person : IPerson
    {
        private const uint MaxIdCount = 9999;

        private uint id;
        private string firstName;
        private string lastName;
             
        public Person(uint id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public uint Id 
        {
            get { return this.id; }
            set 
            {
                if (value <= 0 || value > MaxIdCount)
                {
                    throw new ArgumentOutOfRangeException("ID cannot be negative or zero.ID must be in range [1...9999]!");
                }
                this.id = value; 
            }
        }

        public string FirstName 
        {
            get { return this.firstName; }
            set 
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("The name cannot be empty and must be at least 3 characters!");
                }
                if (!value.All(char.IsLetter) || !char.IsUpper(value, 0))
                {
                    throw new FormatException("The name must be only latin letters and start with capital letter!");   
                }
                this.firstName = value; 
            }
        }

        public string LastName 
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("The name cannot be empty and must be at least 3 characters!");
                }
                if (!value.All(char.IsLetter) || !char.IsUpper(value, 0))
                {
                    throw new FormatException("The name must be only latin letters and start with capital letter!");
                }
                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return string.Format("ID {0}; First name: {1}; Last name: {2}; ", this.id, this.firstName, this.lastName);
        }
    }
}
