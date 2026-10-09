using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PersonDto
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        
        public string MobileNumber { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public PersonDto(string firstName, string lastName, string nationalCode, string mobileNumber)
        {

            FirstName = firstName;
            LastName = lastName;
            NationalCode = nationalCode;
            MobileNumber = mobileNumber;


        }


    }
    
}   
