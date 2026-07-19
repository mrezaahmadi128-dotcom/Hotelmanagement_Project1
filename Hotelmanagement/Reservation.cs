using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelmanagement
{
    public class Reservation
    {
        public Guest Guest { get; set; }
        public Room Room { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal TotalPrice { get; private set; }
        public int Id {  get; private set; }
        public Reservation(Guest guest,Room room,DateTime checkIn,DateTime checkOut) 
        { 
            Guest = guest;
            Room = room;
            CheckIn = checkIn;
            CheckOut = checkOut;
            Id = ReservationManager.GetId();
        }
        public  static Result Validation(Guest guest, Room room, DateTime checkIn, DateTime checkOut)
        {
            if (guest==null)
            {
                return Result.Failed("لطفا مهمان را وارد کنید");
            }
            if (room == null)
            {
                return Result.Failed("لطفا اتاق را وارد کنید");
            }
            if (checkIn < DateTime.Now)
            {
                return Result.Failed("تاریخ ورود مشکل دارد");
            }
            if (checkOut < DateTime.Now)
            {
                return Result.Failed("تاریخ ورود مشکل دارد");
            }

            return Result.Ok();
        }
    }
}
