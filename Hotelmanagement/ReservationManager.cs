using System.Collections.Generic;

namespace Hotelmanagement
{
    public class ReservationManager
    {
        private static List<Reservation> _reservations=new List<Reservation>();
        public static List<Reservation> GetReservatin()
        {
            return _reservations;
        }
        public Result AddReserv(Reservation reservation)
        {
            
            Result result =Reservation.Validation(reservation.Guest,reservation.Room,reservation.CheckIn,reservation.CheckOut);
            if(!result.Success)
                return result;
            if(!ExistReserv(reservation.Id))
            {
                return Result.Failed("رزرو وارد شده تکراری است");
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
    }
}