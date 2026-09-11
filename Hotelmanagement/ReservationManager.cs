using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Configuration;

namespace Hotelmanagement
{
    public class ReservationManager
    {
        private static List<Reservation> _reservations=new List<Reservation>();
        public static List<Reservation> GetReservation()
        {
            return new List<Reservation>(_reservations);
        }
       private string connectionString=
           "Server=localhost\\SQLEXPRESS;" +
        "Database=HotelManagement;" +
        "Trusted_Connection=True;" +
        "TrustServerCertificate=True;";
        public  void TestConnection(out string msg)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                msg = "Connected!";
                connection.Close();
            }
            catch(Exception e) 
            {
                msg= e.Message;
            }
           
        }
        public List<Reservation> GetReservations()
        {
            List<Reservation> list = new List<Reservation>();
            string query = "SELECT * FROM Reservations";
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
               connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                using (SqlDataReader reader = cmd.ExecuteReader()) 
                {
                    while (reader.Read())
                    {
                        int id=Convert.ToInt32(reader["Id"]);
                        int guest= Convert.ToInt32(reader["GuestId"]);
                        int room= Convert.ToInt32(reader["RoomId"]);
                        DateTime checkIn= Convert.ToDateTime(reader["CheckIn"]);
                        DateTime checkOut= Convert.ToDateTime(reader["CheckOut"]);
                        Reservation reservation=new Reservation(id,guest,room,checkIn,checkOut);
                        list.Add(reservation);
                    }
                }
                return list;

            }






        }
        public Result AddReserv(Reservation reservation)
        {
            

            Result result=reservation.Validation(reservation.GuestId,reservation.RoomId,reservation.CheckIn,reservation.CheckOut);
            if(!result.Success)
            {
                return result;
            }
            if(!IsRoomAvailable(reservation.RoomId,reservation.CheckIn,reservation.CheckOut))
            {
                return Result.Failed("این اتاق در بازه زمانی انتخاب شده،رزرو شده است");
            }
            string query = @"
                             INSERT INTO Reservations
                             (GuestId, RoomId, CheckIn, CheckOut, CreationTime)
                             VALUES
                             (@guestId, @roomId, @checkIn, @checkOut, GETDATE())";
            using (SqlConnection connection=new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query,connection);
                cmd.Parameters.AddWithValue("@guestId",reservation.GuestId);
                cmd.Parameters.AddWithValue("@roomId",reservation.RoomId);
                cmd.Parameters.AddWithValue("@checkIn",reservation.CheckIn);
                cmd.Parameters.AddWithValue("@checkOut",reservation.CheckOut);
                int rowsAffected=cmd.ExecuteNonQuery();
                if (rowsAffected == 1)
                {
                    return Result.Ok();
                }
            }
            return Result.Failed("رزرو ثبت نشد");
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
        public bool IsRoomAvailable(int roomId,DateTime checkIn,DateTime checkOut)
        {
            string query = @"SELECT * FROM Reservations 
                            WHERE RoomId=@roomId
                            AND  CheckIn<@checkOut
                            AND  CheckOut>@checkIn";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@roomId", roomId);
                cmd.Parameters.AddWithValue("@checkIn", checkIn);
                cmd.Parameters.AddWithValue("@checkOut", checkOut);
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return false;
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