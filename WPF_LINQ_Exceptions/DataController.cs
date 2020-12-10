using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IST215C_Project
{
    class DataArray
    {
        private List<Customer> customerList;//reference to array

        public DataArray(int maxSize, string inputPath)//constructor
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

        //public int LoadData()
        //{
        //    string sPath = @"..\..\";
        //    //string sNewFile = "Customer10.txt";
        //    string sNewFile = "Customer10.csv";
        //    string line;
        //    string[] words;
        //    int count = 0;

        //    StreamReader reader = new StreamReader(sPath + sNewFile);
        //    try
        //    {
        //        do
        //        {
        //            count++;
        //            line = reader.ReadLine();
        //            words = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        //            customerList.Add(new Customer(Convert.ToInt32(words[0]),words[1], words[2], Convert.ToInt32(words[3]),words[4],words[5],words[6],words[7],words[8],words[9]));
        //            // Console.WriteLine("{0,6} - {1}", count, line);
        //        } while (reader.Peek() != -1);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //    finally
        //    {
        //        reader.Close();
        //    }
        //    //Console.WriteLine("Items read {0}", customerList.Count);
        //    return customerList.Count;
        //} // end loadData

        //public void SaveData()
        //{
        //    string sPath = @"..\..\";
        //    string sNewFile = "CustomerLab9_output.txt";

        //    StreamWriter writer = new StreamWriter(sPath + sNewFile);
        //    foreach (var person in customerList)
        //    {
        //        writer.WriteLine(person);
        //    }
        //    writer.Close();
        //}

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