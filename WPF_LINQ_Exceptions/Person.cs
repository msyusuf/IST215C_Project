using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
// https://docs.microsoft.com/en-us/dotnet/desktop/wpf/data/how-to-implement-property-change-notification?view=netframeworkdesktop-4.8
// https://docs.microsoft.com/en-us/dotnet/desktop/wpf/data/how-to-control-when-the-textbox-text-updates-the-source?view=netframeworkdesktop-4.8&source=docs


namespace IST215C_Project
{
   public class Person : IComparable<Person>, IEquatable<Person>, INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        private int age;
        private string address;
        private string city;
        private string state;
        private string zipCode;
        private string phone;
        private string emailAddress;
        // private string _image;
        

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                NotifyPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                NotifyPropertyChanged("LastName");
            }
        }

        public int Age
        {
            get => age;
            set
            {
                age = value;
                NotifyPropertyChanged("Age");
            }
        }

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                NotifyPropertyChanged("Address");
            }
        }

        public string City
        {
            get { return city; }
            set
            {
                city = value;
                NotifyPropertyChanged("City");
            }
        }

        public string State
        {
            get { return state; }
            set
            {
                state = value;
                NotifyPropertyChanged("State");
            }
        }

        public string ZipCode
        {
            get { return zipCode; }
            set
            {
                zipCode = value;
                NotifyPropertyChanged("ZipCode");
            }
        }
        public string PhoneNumber
        {
            get { return phone; }
            set
            {
                phone = value;
                NotifyPropertyChanged("PhoneNumber");
            }
        }

        public string EmailAddress
        {
            get { return emailAddress; }
            set
            {
                emailAddress = value;
                NotifyPropertyChanged("EmailAddress");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;


        // Constructor
        public Person(String last, String first, int a, String street, String city, String state, String zip, String phone, String email)
        {
            LastName = last;
            FirstName = first;
            Age = a;
            Address = street;
            City = city;
            State = state;
            ZipCode = zip;
            PhoneNumber = phone;
            EmailAddress = email;
        }
        // Default or no-arg Constructor
        public Person()
            : this(string.Empty, string.Empty, 0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
        {
        } // Default or no-arg Constructor


        public void DisplayPerson()
        {//Check printout format positions
            Console.WriteLine("{0,12} {1,-12} Age: {2,2} {3,12} {4,-12} {5,12} {6,-12} {7,12} {8,-12}",
                FirstName, LastName, Age, Address, City, State, ZipCode, PhoneNumber, EmailAddress);
        }

        public override bool Equals(object obj)
        {
            if (this == obj)    //same object, comparing itself.
                return true;
            // if other object is null or it's type is not same as this
            if (obj == null || this.GetType() != obj.GetType())
                return false;
            //Need to do this to access members of the other object.
            Person personObj = obj as Person;
            if (personObj == null)      //if casting failed return false
                return false;
            else
                return Equals(personObj);
        }

        public bool Equals(Person otherPerson)
        {
            //Age scomparison is disabled because we don't use age
            if (this.Age != otherPerson.Age)
                return false;
            //Check if search can be done with other attributes like zip or state
            if (this.FirstName == null && otherPerson.FirstName != null)
            {
                return false;
            }
            else if (!FirstName.Equals(otherPerson.FirstName))
                return false;

            if (this.LastName == null && otherPerson.LastName != null)
            {
                return false;
            }
            else if (!LastName.Equals(otherPerson.LastName))
                return false;

            return true;
        }

        // Generates a unique number for each object based on the
        // values of the fields
        public override int GetHashCode()
        {
            const int prime = 31;
            int result = 1;
            result = result * prime + Age;
            result = result * prime
                    + ((FirstName == null) ? 0 : FirstName.GetHashCode());
            result = prime * result
                    + ((LastName == null) ? 0 : LastName.GetHashCode());
            return result;
        }

        public int CompareTo(Person other)
        {
            // if last names are the same compare first names
            if (this.LastName.Equals(other.LastName))
            {
                if (this.FirstName.Equals(other.FirstName))
                {
                    // Both firstname and last names were equal.
                    // Age determines the comparision.

                    //Replace this next line with something like an Id number
                    //return this.Age.CompareTo(other.Age);
                }
                else
                {   //Lastnames were equal, but firstnames were not.
                    return this.FirstName.CompareTo(other.FirstName);
                }
            }
            //Last names were not equal
            return this.LastName.CompareTo(other.LastName);
        }

        // When you print an object, this method is called
        public override string ToString()
        {
            return string.Format("{0,12} {1,-12} Age: {2,2} {3,12} {4,-12} {5,12} {6,-12} {7,12} {8,-12}",
                FirstName, LastName, Age, Address, City, State, ZipCode, PhoneNumber, EmailAddress);
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //private void NotifyPropertyChanged(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
    }
}