using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IST215C_Project
{
    public class Customer:Person
    {
/*        private int id;
        private string last;
        private string first;
        private int a;
        private string street;
        private string city;
        private string state;
        private int zip;
        private string phone;
        private string email;
        */
        public int customerId { get; set;}

        public Customer(int id, string last, string first, int a, string street, string city, string state, string zip, string phone, string email)
        {
            customerId      = id;
            LastName        = last;
            FirstName       = first;
            Age             = a;
            Address         = street;
            City            = city;
            State           = state;
            ZipCode         = zip;
            PhoneNumber     = phone;
            EmailAddress    = email;
        }

        public bool Equals(Customer otherCustomer)
        {
            //ID comparison
            if (this.customerId != otherCustomer.customerId)
                return false;
            return true;
        }

    } // end class
} // end namespace
