using DL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ReservationService
    {
        public Action Load;
        ReservationData data=new ReservationData();
        
        public OperationResult<List<ReservationDto>> GetReservations()
        {
            return data.GetReservations();
        }
        public OperationResult<ReservationDto> GetReservationById(int id)
        { 
            return data.GetReservationById(id); 
        }
        public OperationResult AddReservation(ReservationDto reservation)
        {
            OperationResult result = ValidateReservation(reservation.GuestId, reservation.RoomId, reservation.CheckIn, reservation.CheckOut);
            if (!result.Success)
            {
                return result;
            }
            if (!data.GuestExists(reservation.GuestId))
            {
                return OperationResult.Failed("آیدی مهمان وارد شده موجود نمی باشد");
            }
            if (!data.RoomExists(reservation.RoomId))
            {
                return OperationResult.Failed("آیدی اتاق وارد شده موجود نمی باشد");
            }
            if (!data.IsRoomAvailable(reservation.RoomId, reservation.CheckIn, reservation.CheckOut))
            {
                return OperationResult.Failed("این اتاق در بازه زمانی انتخاب شده،رزرو شده است");
            }
            var roomPrice = data.RoomPrice(reservation.RoomId);
            TimeSpan duration = reservation.CheckOut-reservation.CheckIn;
            if (!roomPrice.Success)
            {
                return OperationResult.Failed(roomPrice.Message);
            }
            reservation.TotalPrice = (decimal)duration.TotalDays * roomPrice.Data;
            Load?.Invoke();
            return data.AddReservation(reservation);

        }
        public OperationResult RemoveReservation(int id)
        {
            Load?.Invoke();
            return data.RemoveReservation(id);
        }
        public OperationResult UpdateReservation(ReservationDto reservation)
        {
            OperationResult result = ValidateReservation(reservation.GuestId, reservation.RoomId, reservation.CheckIn, reservation.CheckOut);
            if (!result.Success)
            {
                return result;
            }
            if (!data.GuestExists(reservation.GuestId))
            {
                return OperationResult.Failed("آیدی مهمان وارد شده موجود نمی باشد");
            }
            if (!data.RoomExists(reservation.RoomId))
            {
                return OperationResult.Failed("آیدی اتاق وارد شده موجود نمی باشد");
            }
            if (!data.IsRoomAvailableForUpdate(reservation.Id,reservation.RoomId, reservation.CheckIn, reservation.CheckOut))
            {
                return OperationResult.Failed("این اتاق در بازه زمانی انتخاب شده،رزرو شده است");
            }
            var roomPrice = data.RoomPrice(reservation.RoomId);
            TimeSpan duration = reservation.CheckOut - reservation.CheckIn;
            if (!roomPrice.Success)
            {
                return OperationResult.Failed(roomPrice.Message);
            }
            reservation.TotalPrice = (decimal)duration.TotalDays * roomPrice.Data;
            return data.UpdateReservation(reservation.Id,reservation.RoomId,reservation.GuestId,reservation.CheckIn, reservation.CheckOut,reservation.TotalPrice);
        }
        public OperationResult ValidateReservation(int guestId, int roomId, DateTime checkIn, DateTime checkOut)
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
