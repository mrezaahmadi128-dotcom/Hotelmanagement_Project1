using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GuestDto:PersonDto
    {
        public string Display => $"{FirstName} {LastName}";
        public GuestDto(string firstName, string lastName, string nationalCode, string mobileNumber)
                : base(firstName, lastName, nationalCode, mobileNumber)
            {
            }
            public GuestDto(int id, string firstName, string lastName, string nationalCode, string mobileNumber)
                : base(firstName, lastName, nationalCode, mobileNumber)
            {
                Id = id;
            }
            public override string ToString()
            {
                return $"{Id}-{FullName}";
            }

            public static OperationResult Validation(string firstName, string lastName, string nationalCode, string mobileNumber)
            {
                if (string.IsNullOrWhiteSpace(firstName))
                {
                    return OperationResult.Failed("نام را صحیح وارد کنید");
                }
                if (string.IsNullOrWhiteSpace(lastName))
                {
                    return OperationResult.Failed("نام خانوادگی را صحیح وارد کنید");
                }
                if (string.IsNullOrWhiteSpace(nationalCode) || nationalCode.Length != 10)
                {
                    return OperationResult.Failed("کدملی نامعتبر است");
                }
                if (string.IsNullOrWhiteSpace(mobileNumber) || mobileNumber.Length != 11)
                {
                    return OperationResult.Failed("شماره موبایل نامعتبر است");
                }
                return OperationResult.Ok();
            }
        
    }
}
