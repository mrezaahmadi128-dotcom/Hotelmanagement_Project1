using DL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class GuestService
    {
        GuestData guestData=new GuestData();
        public OperationResult<List<GuestDto>> GetGuests()
        {
            return guestData.GetGuests();
        }
        public OperationResult AddGuest(GuestDto guest)
        {
            var result = ValidateGuest(guest.FirstName, guest.LastName, guest.NationalCode, guest.MobileNumber);
            if (!result.Success)
            {
                return result;
            }
            if (guestData.NationalCodeExist(guest.NationalCode))
            {
                return OperationResult.Failed("کدملی وارد شده تکراری هست");
            }
            return guestData.AddGuest(guest);
        }
        public OperationResult RemoveGuest(int id)
        {
            if(guestData.HasReservation(id))
            {
                return OperationResult.Failed("این مهمان دارای رزرو هست");
            }
            return guestData.RemoveGuest(id);
        }
        public OperationResult UpdateGuest(int id, string firstName, string lastName, string nationalCode, string mobileNumber)
        {
            var result= ValidateGuest(firstName, lastName, nationalCode, mobileNumber);
            if (!result.Success)
            {
                return result;
            }
            if (guestData.IsNationalCodeExist(id, nationalCode))
            {
                return OperationResult.Failed("کدملی دارد شده موجود می باشد");
            }
            return guestData.UpdateGuest(id,firstName, lastName, nationalCode, mobileNumber);
        }
        public OperationResult<GuestDto> GetGuestById(int id)
        {
            return guestData.GetGuestById(id);
        }
        public static OperationResult ValidateGuest(string firstName, string lastName, string nationalCode, string mobileNumber)
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
