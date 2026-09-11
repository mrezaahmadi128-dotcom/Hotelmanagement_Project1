using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelmanagement
{
    public class Reservation
    {
        public int GuestId { get; set; }
        public int RoomId{ get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal TotalPrice { get; private set; }
        public int Id {  get; private set; }
        public Reservation(int guest,int room,DateTime checkIn,DateTime checkOut) 
        { 
            GuestId = guest;
            RoomId = room;
            CheckIn = checkIn;
            CheckOut = checkOut;
            Id = ReservationManager.GetId();
        }
        public Reservation(
                int id,
                int guest,
                int room,
                DateTime checkIn,
                DateTime checkOut)
        {
            Id = id;
            GuestId = guest;
            RoomId = room;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }
        public   Result Validation(int guestId, int roomId, DateTime checkIn, DateTime checkOut)
        {
            if (guestId<=0)
            {
                return Result.Failed("لطفا مهمان را وارد کنید");
            }
            if (roomId <= 0)
            {
                return Result.Failed("لطفا اتاق را وارد کنید");
            }
            if (checkIn < DateTime.Now.Date)
            {
                return Result.Failed("تاریخ ورود نمی‌تواند قبل از امروز باشد");
            }
            if (checkOut < DateTime.Now.Date || checkOut<= checkIn)
            {
                return Result.Failed("تاریخ خروچ مشکل دارد");
            }

            return Result.Ok();
        }
    }
}
