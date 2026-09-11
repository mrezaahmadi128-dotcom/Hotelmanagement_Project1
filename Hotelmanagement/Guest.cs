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
        public Guest(int id,string firstName, string lastName, string nationalCode, string mobileNumber)
            : base(firstName, lastName, nationalCode, mobileNumber)
        {
            Id=id;
        }
        public override string ToString()
        {
            return $"{Id}-{FullName}";
        }
        
        public static Result Validation(string firstName, string lastName, string nationalCode, string mobileNumber)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                return Result.Failed("نام را صحیح وارد کنید");
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                return Result.Failed("نام خانوادگی را صحیح وارد کنید");
            }
            if (string.IsNullOrWhiteSpace(nationalCode) || nationalCode.Length != 10)
            {
                return Result.Failed("کدملی نامعتبر است");
            }
            if (string.IsNullOrWhiteSpace(mobileNumber) || mobileNumber.Length != 11)
            {
                return Result.Failed("شماره موبایل نامعتبر است");
            }
            return Result.Ok();
        }
    }
}
