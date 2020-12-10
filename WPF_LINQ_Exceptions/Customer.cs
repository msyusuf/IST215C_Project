using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IST215C_Project
{
    public class Customer: Person
    {
        public int customerId { get; set;}

        public Customer(int id, string last, string first, int a, string street, string city, string state, string zip, string phone, string email)
             : base (last, first, a, street, city, state, zip, phone, email )
        {
            customerId      = id;
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
