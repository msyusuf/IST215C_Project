using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IST215C_Project
{
    class DataController
    {
        private List<Customer> customerList;//reference to array

        public DataController(int maxSize, string inputPath)//constructor
        {
            // customerList = new List<Customer>();//create the array
            Util.LoadData(inputPath, out customerList);
        }
        //GetCount. Returns the number of customers in the list
        public int GetCount() { return customerList.Count; }

        public void InsertCustomer(int id, String last, String first, int a, String street, String city, String state, String zip, String phone, String email)
        {
            customerList.Add(new Customer(id, last, first, a, street, city, state, zip, phone, email));
            return;
        }

        public void InsertCustomer(Customer p)
        {
            customerList.Add(p);
            return;
        }

        public void UpdateCustomer(int pos, int id, string first, string last, int age, string street, string city, string state, string zip, string phone, string email)
        {
            customerList[pos].customerId = id;
            customerList[pos].FirstName = first;
            customerList[pos].LastName = last;
            customerList[pos].Age = age;
            customerList[pos].Address = street;
            customerList[pos].City = city;
            customerList[pos].State = state;
            customerList[pos].ZipCode = zip;
            customerList[pos].PhoneNumber = phone;
            customerList[pos].EmailAddress = email;
        }

        public void Clear()
        {
            customerList.Clear();
        }

        public int DisplayId(int pos)
        {
            return customerList[pos].customerId;
        }

        public string DisplayFirstName(int pos)
        {
            return customerList[pos].FirstName;
        }
        
        public string DisplayLastName(int pos)
        {
            return customerList[pos].LastName;
        }

        public int DisplayAge(int pos)
        {
            return customerList[pos].Age;
        }

        public string DisplayAddress(int pos)
        {
            return customerList[pos].Address;
        }

        public string DisplayCityName(int pos)
        {
            return customerList[pos].City;
        }

        public string DisplayStateCode(int pos)
        {
            return customerList[pos].State;
        }

        public string DisplayZipCode(int pos)
        {
            return customerList[pos].ZipCode;
        }

        public string DisplayPhoneNumber(int pos)
        {
            return customerList[pos].PhoneNumber;
        }

        public string DisplayEmailAddress(int pos)
        {
            return customerList[pos].EmailAddress;
        }
    }
}