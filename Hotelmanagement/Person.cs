using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelmanagement
{
    public abstract class Person
    {
        public int Id { get;set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string NationalCode { get;  set; }
        public string MobileNumber { get;  set; }
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
