using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class RoomData
    {
        private readonly DbConnectionFactory _connectionFactory;
        public RoomData()
        {
            _connectionFactory = new DbConnectionFactory();
        }
        public OperationResult AddRoom(RoomDto room)
        {
            
            string quey = @"INSERT INTO Rooms
                           (RoomNumber,Capacity,Price,CreationTime)
                            VALUES
                            (@RoomNumber,@Capacity,@Price,getdate())";
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(quey, conn);
                cmd.Parameters.AddWithValue("@RoomNumber", room.RoomNumber);
                cmd.Parameters.AddWithValue("@Capacity", room.Capacity);
                cmd.Parameters.AddWithValue("@Price", room.Price);

                var rowsaffects = cmd.ExecuteNonQuery() > 0;
                if (rowsaffects)
                {
                    return OperationResult.Ok();
                }
            }
            return OperationResult.Failed("اطلاعات ذخیره نشد");
        }
        public OperationResult RemoveRoom(int id)
        {
            
            string query = @"Delete from Rooms
                                where Id=@id";
            using (SqlConnection connection = _connectionFactory.CreateConnection())
            {

                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                {
                    return OperationResult.Ok();
                }
            }
            return OperationResult.Failed("آیدی وارد شده موجود نیست");
        }
        public OperationResult Update(int id, string roomNumber, int capacity, decimal price)
        {
           
            string query = @"Update Rooms
                           set RoomNumber=@roomNumber,
                               Capacity=@capacity,
                               Price=@price
                            where Id=@id";

            using (SqlConnection connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@roomNumber", roomNumber);
                command.Parameters.AddWithValue("@capacity", capacity);
                command.Parameters.AddWithValue("@price", price);
                int rowsAffect = command.ExecuteNonQuery();
                if (rowsAffect == 1)
                {
                    return OperationResult.Ok();
                }
            }
            return OperationResult.Failed("اتاقی با آیدی وارد شده موجود نمی باشد");

        }
        public OperationResult<List<RoomDto>> GetRooms()
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
                return OperationResult<List<RoomDto>>.Failed(ex.Message);
            }


        }
        public bool IsRoomNumberExists(int id, string roomNumber)
        {
            string query = @"Select count(*)
                           from Rooms
                           where RoomNumber=@roomNumber
                            AND Id<>@id";
            using (SqlConnection connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@roomNumber", roomNumber);
                cmd.Parameters.AddWithValue("@id", id);
                int row = Convert.ToInt32(cmd.ExecuteScalar());
                return row > 0;
            }
        }
        public OperationResult<RoomDto> GetRoomById(int id)
        {
            string query = @"Select Id,RoomNumber,Capacity,Price
                           from Rooms
                           where Id=@id";
            using (SqlConnection connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        RoomDto rom= new RoomDto(
                            Convert.ToInt32(reader["Id"]),
                            Convert.ToString(reader["RoomNumber"]),
                            Convert.ToInt32(reader["Capacity"]),
                            Convert.ToDecimal(reader["Price"])
                            );
                        
                        return OperationResult<RoomDto>.Ok(rom);

                    }
                }
            }
            return OperationResult<RoomDto>.Failed("اتاقی با ایدی وارد شده موجود نمی باشد");


        }
        public bool HasReservation(int roomId)
        {
            string query = @"select count(*)
                            from reservations
                             where RoomId=@roomId";
            using (SqlConnection connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@roomId", roomId);
                int rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());

                return rowsAffected > 0;
            }

        }
        public bool RoomNumberExists(string  roomNumber)
        {
            string query = @"SELECT COUNT(*)
                           FROM Rooms
                            WHERE RoomNumber=@RoomNumber";
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = query;
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@RoomNumber", roomNumber);
                var row = Convert.ToInt32(command.ExecuteScalar());
                return row > 0;
            }
        }
    }
}
