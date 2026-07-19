using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelmanagement
{
    public class GuestManager
    {
        private static List<Guest>_guests=new List<Guest>();
        public static List<Guest> GetGuest()
        {
            return _guests;
        }
        public Result AddGuest(Guest guest)
        {
            Result result =Guest.Validation(guest.FirstName,guest.LastName,guest.NationalCode,guest.MobileNumber);
            if(!result.Success)
                return result;
            if(ExistGuest(guest.NationalCode))
            {
                return Result.Failed("این کاربر وجود دارد ");
            }
            _guests.Add(guest);
            return Result.Ok();
        }

        public static bool ExistGuest(string National)
        {
            foreach (Guest guest in _guests)
            {
                if (guest.NationalCode == National)
                    return true;
            }
            return false;
        }
        public static int GetId()
        {
            if(_guests.Count == 0)
                return 1;
            return _guests[_guests.Count-1].Id+1;
        }
        public Result RemoveGuest(int id)
        {
            Guest guest = null;
            foreach (Guest item in _guests)
            {
                if (item.Id == id)
                {
                    guest = item;
                    break;
                }
            }
            if(guest != null)
            {
                _guests.Remove(guest);
                return Result.Ok();
            }
            return Result.Failed("آیدی وارد شده وجود ندارد");
        }
        public static Guest GetGuestById(int id)
        {
            foreach(Guest item in _guests)
            {
                if(item.Id == id)
                    return item;
            }
            return null;
        }
    }
}
