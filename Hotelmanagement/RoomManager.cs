using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelmanagement
{
    public class RoomManager
    {
       public event EventHandler RoomAdded;
        public event EventHandler RoomRemoved;
        private string connectionString =
                                       "Server=localhost\\SQLEXPRESS;" +
                                       "Database=HotelManagement;" +
                                       "Trusted_Connection=True;" +
                                       "TrustServerCertificate=True;";
        
        public  List<Room> GetRooms()
        {
            string query = @"SELECT Id,RoomNumber,Capacity,Price
                           FROM Rooms";
            List<Room> list = new List<Room>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query,conn);
                //cmd.Connection = conn;
                //cmd.CommandText = "[dbo].[SelectRooms]";
                //cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id=Convert.ToInt32(reader["Id"]);
                        string roomNumber = Convert.ToString(reader["RoomNumber"]);
                        int capaCity = Convert.ToInt32(reader["Capacity"]);
                        decimal price = Convert.ToDecimal(reader["Price"]);
                        Room room=new Room(id,roomNumber,capaCity,price);
                        list.Add(room);
                    }
                }
                return list;
            }
        }
        public  Result AddRoom(Room room)
        {
            Result result=room.Validation(room.RoomNumber,room.Capacity,room.Price);
            if(!result.Success)
                return result;
            if(RoomNumberExists(room.RoomNumber))
            {
                return Result.Failed("شماره اتاق وارد شده تکراری می باشد");
            }
            string quey = @"INSERT INTO Rooms
                           (RoomNumber,Capacity,Price,CreationTime)
                            VALUES
                            (@RoomNumber,@Capacity,@Price,getdate())";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd=new SqlCommand(quey,conn);
                cmd.Parameters.AddWithValue("@RoomNumber", room.RoomNumber);
                cmd.Parameters.AddWithValue("@Capacity", room.Capacity);
                cmd.Parameters.AddWithValue("@Price", room.Price);
                
                var rowsaffects=cmd.ExecuteNonQuery()>0;
                if (rowsaffects)
                {
                    RoomAdded?.Invoke(this, EventArgs.Empty);
                    return Result.Ok();
                }
            }
            return Result.Failed("اطلاعات ذخیره نشد");
        }

        public bool RoomNumberExists(string roomNumber)
        {
            string query = @"SELECT COUNT(*)
                           FROM Rooms
                            WHERE RoomNumber=@RoomNumber";
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = query;
                command.Connection=conn;
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@RoomNumber", roomNumber);
                var row=Convert.ToInt32(command.ExecuteScalar());
                return row>0;    
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomNumber"></param>
        /// <returns></returns>
        public Result RemoveRoom(int id)
        {
            if(HasReservatin(id))
            {
                return Result.Failed("این اتاق دارای رزرو است");
            }
            string query = @"Delete from Rooms
                                where Id=@id";
            using (SqlConnection connection=new SqlConnection(connectionString))
            {
                
                connection.Open();
                SqlCommand cmd= new SqlCommand(query,connection);
                cmd.Parameters.AddWithValue("@id", id);
                int rows=cmd.ExecuteNonQuery();
                if(rows==1)
                {
                    RoomRemoved?.Invoke(this, EventArgs.Empty);
                    return Result.Ok();
                }
            }
            return Result.Failed("شماره اتاق وارد شده موجود نیست");
        }
        public bool HasReservatin(int roomId)
        {
            string query = @"select count(*)
                            from reservations
                             where RoomId=@roomId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@roomId", roomId);
                int rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());

                return rowsAffected > 0;              
            }
           
        }
        public  Room GetRoomById(int id)
        {
            string query = @"Select Id,RoomNumber,Capacity,Price
                           from Rooms
                           where Id=@id";
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Room(
                            Convert.ToInt32(reader["Id"]),
                            Convert.ToString(reader["RoomNumber"]),
                            Convert.ToInt32(reader["Capacity"]),
                            Convert.ToDecimal(reader["Price"])
                            );
                    }
                }
            }
            return null;
            
        }
        public Result Update(int id,string roomNumber,int capacity,decimal price)
        {
            Result result = Validation(roomNumber, capacity,price);
            if (!result.Success)
                return result;
            if(IsRoomNumberExists( id, roomNumber))
            {
               return Result.Failed("شماره اتاق وارد شده تکراری می باشد");
            }
            string query = @"Update Rooms
                           set RoomNumber=@roomNumber
                               Capacity=@capacity
                               Price=@price
                            where Id=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open ();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@roomNumber", roomNumber);
                command.Parameters.AddWithValue("@capacity", capacity);
                command.Parameters.AddWithValue("@price", price);
                int rowsAffect=command.ExecuteNonQuery();
                if( rowsAffect==1)
                {
                    return Result.Ok();
                }
            }
            return Result.Failed("شماره اتاق");

        }
        public bool IsRoomNumberExists(int id,string roomNumber)
        {
            string query = @"Select count(*)
                           from Rooms
                           where RoomNumber=@roomNumber
                            AND Id<>@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@roomNumber",roomNumber);
                cmd.Parameters.AddWithValue("@id",id);
                int row=Convert.ToInt32(cmd.ExecuteScalar());
                return row > 0;
            }
        }
        public Result Validation(string roomNumber, int capaCity, decimal price)
        {
            if (string.IsNullOrWhiteSpace(roomNumber))
            {
                return Result.Failed("شماره اتاق الزامی است");
            }
            if (capaCity <= 0)
            {
                return Result.Failed("ظرفیت نا مغتبر است");
            }
            if (price <= 0)
            {
                return Result.Failed("مبلغ نا معتبر است");
            }
            return Result.Ok();
        }
    }
}
