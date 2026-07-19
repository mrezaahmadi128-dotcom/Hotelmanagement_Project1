using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelmanagement
{
    public class Guest:Person
    {
        public Guest(string firstName, string lastName,string nationalCode,string mobileNumber)
            :base(firstName, lastName, nationalCode, mobileNumber)
        {
        }
       
      
    }
}
