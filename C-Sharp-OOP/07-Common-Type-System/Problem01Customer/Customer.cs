using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01Customer
{
    public class Customer : ICloneable, IComparable<Customer>
    {
        private CustomerType customerType;

        public Customer(string firstName, string middleName, string lastName, ulong id, 
                        string permanentAddress = null, string mobilePhone = null, string email = null, 
                        List<Payment> payments = null)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Id = id;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Payments = payments;
            this.CustomerType = customerType;
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public ulong Id { get; set; }

        public string PermanentAddress { get; set; }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public List<Payment> Payments { get; set; }

        public CustomerType CustomerType 
        {
            get { return this.customerType; }
            set
            {
                if (this.Payments.Count <= 1)
                {
                    this.customerType = CustomerType.OneTime;
                }

                if (this.Payments.Count >= 2)
                {
                    this.customerType = CustomerType.Regular;
                }

                if (this.Payments.Count >= 3)
                {
                    this.customerType = CustomerType.Golden;
                }

                if (this.Payments.Count >= 5)
                {
                    this.customerType = CustomerType.Diamond;
                }
            }
        }

        public override bool Equals(object obj)
        {
            Customer customer = obj as Customer;

            if (obj == null)
            {
                return false;
            }

            if (!Object.Equals(this.FirstName, customer.FirstName) && !Object.Equals(this.MiddleName, customer.MiddleName) 
                && !Object.Equals(this.LastName, customer.LastName))
            {
                return false;
            }

            if (this.Id != customer.Id)
            {
               return false; 
            }

            if (Object.Equals(this.PermanentAddress, customer.PermanentAddress))
            {
                return false; 
            }

            if (!Object.Equals(this.MobilePhone, customer.MobilePhone))
            {
                return false;
            }

            if (!Object.Equals(this.Email, customer.Email))
            {
                return false;
            }

            return true;
        }

        public static bool operator ==(Customer customer1, Customer customer2)
        {
            return Customer.Equals(customer1, customer2);
        }

        public static bool operator !=(Customer customer1, Customer customer2)
        {
            return !Customer.Equals(customer1, customer2);
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ MiddleName.GetHashCode() ^ LastName.GetHashCode() ^ Id.GetHashCode() 
                   ^ MobilePhone.GetHashCode() ^ Email.GetHashCode();
        }

        public override string ToString()
        {
            string fullName = String.Format("Full customer name: {0} {1} {2}", this.FirstName, this.MiddleName, this.LastName);
            string address = String.Format("Permanent address: {0}", this.PermanentAddress);
            string phoneAndEmail = String.Format("Mobile phone: {0}; E-mail: {1}", this.MobilePhone, this.Email);
            string payments = "List of payments: " + string.Join(" ", this.Payments);
            string customerType = this.CustomerType.ToString();

            return String.Format("{0}; Id: {1};\n{2}; {3}; Type: {4};\n{5}", fullName, this.Id, address, phoneAndEmail, customerType, payments);
        }

        public object Clone()
        {
            Customer newCustomer = new Customer(this.FirstName, this.MiddleName, this.LastName, this.Id, this.PermanentAddress, 
                                                this.MobilePhone, this.Email, this.Payments);

            return newCustomer;
        }

        public int CompareTo(Customer other)
        {
            string thisFullName = this.FirstName + this.MiddleName + this.LastName;
            string otherFullName = other.FirstName + other.MiddleName + other.LastName;

            int result = thisFullName.CompareTo(otherFullName);
            if (result == 0)
            {
                result = this.Id.CompareTo(other.Id);
            }
      
            return result;
        }
    }
}
