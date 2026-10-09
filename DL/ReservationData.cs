using Common.Constants;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class ReservationData
    {
        private readonly DbConnectionFactory _connectionFactory;
        public ReservationData()
        {
            _connectionFactory = new DbConnectionFactory();
        }
        public OperationResult<List<ReservationDto>> GetReservations()
        {
            string query = @"select * from Reservations";
            List<ReservationDto> list=new List<ReservationDto>();
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query,conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id=Convert.ToInt32(reader["Id"]);
                        int roomId=Convert.ToInt32(reader["RoomId"]); 
                        int guestId=Convert.ToInt32(reader["GuestId"]); 
                        DateTime checkIn=Convert.ToDateTime(reader["CheckIn"]); 
                        DateTime checkOut=Convert.ToDateTime(reader["CheckOut"]);
                        decimal totalPrice = Convert.ToDecimal(reader["TotalPrice"]);
                       ReservationDto reservationDto=new ReservationDto(id,roomId,guestId,checkIn,checkOut,totalPrice);
                        list.Add(reservationDto);
                    }
                    return OperationResult<List<ReservationDto>>.Ok(list);
                }
            }
        }
        public OperationResult AddReservation(ReservationDto reservation)
        {
            
           
            string query = @"
                             INSERT INTO Reservations
                             (GuestId, RoomId, CheckIn, CheckOut,TotalPrice, CreationTime)
                             VALUES
                             (@guestId, @roomId, @checkIn, @checkOut,@totalPrice, GETDATE())";
            using (SqlConnection connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@guestId", reservation.GuestId);
                cmd.Parameters.AddWithValue("@roomId", reservation.RoomId);
                cmd.Parameters.AddWithValue("@checkIn", reservation.CheckIn);
                cmd.Parameters.AddWithValue("@checkOut", reservation.CheckOut);
                cmd.Parameters.AddWithValue("@totalPrice", reservation.TotalPrice);
                
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 1)
                {
                    return OperationResult.Ok();
                }
            }
            return OperationResult.Failed("رزرو ثبت نشد");
        }
        public OperationResult RemoveReservation(int id)
        {
            string query = @"Delete from Reservations
                             where Id=@id";
            using (SqlConnection connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 1)
                {
                    return OperationResult.Ok();
                }
            }
            return OperationResult.Failed("ایدی وارد شده موجود نمی باشد");

        }
        public OperationResult UpdateReservation(int id,int roomId,int guestId,DateTime checkIn,DateTime checkOut,decimal totalPrice)
        {
            string query = @"
                             Update Reservations
                             set RoomId=@roomId,
                                 GuestId=@guestId,
                                 CheckIn=@checkIn,
                                 CheckOut=@checkOut,
                                 TotalPrice=@totalPrice
                                 where Id=@id";
            using (SqlConnection connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@guestId", guestId);
                cmd.Parameters.AddWithValue("@roomId", roomId);
                cmd.Parameters.AddWithValue("@checkIn", checkIn);
                cmd.Parameters.AddWithValue("@checkOut", checkOut);
                cmd.Parameters.AddWithValue("@totalPrice", totalPrice);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 1)
                {
                    return OperationResult.Ok();
                }
            }
            return OperationResult.Failed(" آیدی وارد شده موجود نمی باشد");
        }
        public bool IsRoomAvailable(int roomId, DateTime checkIn, DateTime checkOut)
        {
            string query = @"SELECT * FROM Reservations 
                            WHERE RoomId=@roomId
                            AND  CheckIn<@checkOut
                            AND  CheckOut>@checkIn";
            using (SqlConnection connection = _connectionFactory.CreateConnection())
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
        public OperationResult<ReservationDto> GetReservationById(int id)
        {
            string query = @"select Id,RoomId,GuestId,CheckIn,CheckOut,TotalPrice
                           from Reservations
                           where Id=@id";
            using (SqlConnection connection = _connectionFactory.CreateConnection())
            {
                connection.Open ();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
                    {

                        ReservationDto reservation=new ReservationDto(
                            Convert.ToInt32(reader["Id"]),
                            Convert.ToInt32(reader["RoomId"]),
                            Convert.ToInt32(reader["GuestId"]),
                            Convert.ToDateTime(reader["CheckIn"]),
                            Convert.ToDateTime(reader["CheckOut"]),
                            Convert.ToDecimal(reader["TotalPrice"])
                            );
                        return OperationResult<ReservationDto>.Ok(reservation);
                    }
                }
                return OperationResult<ReservationDto>.Failed("آیدی وارد شده موجود نمی باشد");
            }
        }
        public bool GuestExists(int id)
        {
            string query = @"select count(*)
                           from Guests
                           where Id=@id";
            using (SqlConnection connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                int row = Convert.ToInt32(cmd.ExecuteScalar());
                return row > 0;
            }
        }
        public bool RoomExists(int id)
        {
            string query = @"select count(*)
                           from Rooms
                           where Id=@id";
            using (SqlConnection connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                int row = Convert.ToInt32(cmd.ExecuteScalar());
                return row > 0;
            }
        }
        public OperationResult<decimal> RoomPrice(int roomId)
        {
            decimal price = 0;
            string query = @"select Price
                           from Rooms
                           where Id=@roomId";
            using (SqlConnection connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@roomId", roomId);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        price = Convert.ToDecimal(reader["Price"]);
                        return OperationResult<decimal>.Ok(price);

                    }
                }
            }
            return OperationResult<decimal>.Failed("آیدی اتاق وارد شده موجود نمی باشد");
        }

        public bool IsRoomAvailableForUpdate(int reservationId,int roomId, DateTime checkIn, DateTime checkOut)
        {
            string query = @"SELECT * FROM Reservations 
                            WHERE RoomId=@roomId
                            AND  CheckIn<@checkOut
                            AND  CheckOut>@checkIn
                            AND  Id<>@reservationId";
            using (SqlConnection connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@roomId", roomId);
                cmd.Parameters.AddWithValue("@checkIn", checkIn);
                cmd.Parameters.AddWithValue("@checkOut", checkOut);
                cmd.Parameters.AddWithValue("@reservationId", reservationId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return false;
                }
            }
            return true;
        }
        public OperationResult<List<RoomDto>> GetRoom()
        {
            string query = @"SELECT Id,RoomNumber,Capacity,Price
                           FROM Rooms";
            List<RoomDto> list = new List<RoomDto>();
            try
            {
                using (SqlConnection conn = _connectionFactory.CreateConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    //cmd.Connection = conn;
                    //cmd.CommandText = "[dbo].[SelectRooms]";
                    //cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["Id"]);
                            string roomNumber = Convert.ToString(reader["RoomNumber"]);
                            int capaCity = Convert.ToInt32(reader["Capacity"]);
                            decimal price = Convert.ToDecimal(reader["Price"]);
                            RoomDto room = new RoomDto(id, roomNumber, capaCity, price);
                            list.Add(room);
                        }
                    }
                    return OperationResult<List<RoomDto>>.Ok(list);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return OperationResult<List<RoomDto>>.Failed(MessageConstants.SystemError);
            }


        }
    }
}
