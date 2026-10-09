using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ReservationDto
    {
        public int GuestId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal TotalPrice { get;  set; }
        public int Id { get; private set; }
        public ReservationDto(int guest, int room, DateTime checkIn, DateTime checkOut,decimal totalPrice)
        {
            GuestId = guest;
            RoomId = room;
            CheckIn = checkIn;
            CheckOut = checkOut;
            TotalPrice = totalPrice;
        }
        public ReservationDto(
                int id,
                int guest,
                int room,
                DateTime checkIn,
                DateTime checkOut,
                decimal totoalPrice)
        {
            Id = id;
            GuestId = guest;
            RoomId = room;
            CheckIn = checkIn;
            CheckOut = checkOut;
            TotalPrice= totoalPrice;
        }
        public OperationResult Validation(int guestId, int roomId, DateTime checkIn, DateTime checkOut  )
        {
            if (guestId <= 0)
            {
                return OperationResult.Failed("لطفا مهمان را وارد کنید");
            }
            if (roomId <= 0)
            {
                return OperationResult.Failed("لطفا اتاق را وارد کنید");
            }
            if (checkIn < DateTime.Now.Date)
            {
                return OperationResult.Failed("تاریخ ورود نمی‌تواند قبل از امروز باشد");
            }
            if (checkOut < DateTime.Now.Date || checkOut <= checkIn)
            {
                return OperationResult.Failed("تاریخ خروچ مشکل دارد");
            }

            return OperationResult.Ok();
        }
    }
}
