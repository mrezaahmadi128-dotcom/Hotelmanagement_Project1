using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelmanagement
{
    public abstract class Person
    {
        public int Id { get;private set; }
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
            Id = GuestManager.GetId();

        }
        public Result Update(string firstName, string lastName, string nationalCode, string mobileNumber)
        {

            Result reult = Guest.Validation(firstName, lastName, nationalCode, mobileNumber);
            if (!reult.Success)
                return reult;
            if (GuestManager.ExistGuest(nationalCode))
            {
                return Result.Failed("کدملی وارد شده تکرای است");
            }
            FirstName = firstName;
            LastName = lastName;
            NationalCode = nationalCode;
            MobileNumber = mobileNumber;
            return Result.Ok();
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
