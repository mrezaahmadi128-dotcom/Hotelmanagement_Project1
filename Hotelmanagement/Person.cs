using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelmanagement
{
    public abstract class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string NationalCode { get; private set; }
        public string MobileNumber { get; private set; }
        public string FullName => $"{FirstName} {LastName}";
        public Person(string firstName, string lastName, string nationalCode, string mobileNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            NationalCode = nationalCode;
            MobileNumber = mobileNumber;
        }
    }
}
