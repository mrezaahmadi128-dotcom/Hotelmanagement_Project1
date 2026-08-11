using System;
using System.Collections.Generic;

namespace Hotelmanagement
{
    public class ReservationManager
    {
        private static List<Reservation> _reservations=new List<Reservation>();
        public static List<Reservation> GetReservation()
        {
            return new List<Reservation>(_reservations);
        }
        public Result AddReserv(Reservation reservation)
        {
            Result result=reservation.Validation(reservation.Guest,reservation.Room,reservation.CheckIn,reservation.CheckOut);
            if(!result.Success)
            {
                return result;
            }
            if(!IsRoomAvailable(reservation))
            {
                return Result.Failed("این اتاق در بازه زمانی انتخاب شده،رزرو شده است");
            }
            _reservations.Add(reservation);
            return Result.Ok();
        }
        public bool ExistReserv(int id)
        {
            foreach (Reservation reservation in _reservations)
            {
                if (reservation.Id == id)
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsRoomAvailable(Reservation reservation)
        {
            foreach(Reservation resev in _reservations)
            {
                if (resev.Room.RoomNumber == reservation.Room.RoomNumber)
                {
                    if (!(reservation.CheckIn >= resev.CheckOut || reservation.CheckOut<= resev.CheckIn))
                    {
                        return false;
                        
                    }
                }
            }
            return true;
        }
        public static int GetId()
        {
            if(_reservations.Count == 0)
                return 1;
            return _reservations[_reservations.Count-1].Id+1;
        }


    }
}