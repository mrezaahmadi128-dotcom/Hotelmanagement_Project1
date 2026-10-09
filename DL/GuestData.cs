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
    public class GuestData
    {
        private readonly DbConnectionFactory _connectionFactory;
        public GuestData()
        {
            _connectionFactory = new DbConnectionFactory();
        }

        public OperationResult<List<GuestDto>> GetGuests()
        {

            string query = @"select g.Id,g.FirstName,g.LastName,g.FirstName+' '+g.LastName as FullName,g.NationalCode,g.MobileNumber
                            from Guests as g";
            List<GuestDto> list = new List<GuestDto>();
            try
            {
                using (SqlConnection connection = _connectionFactory.CreateConnection())
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["Id"]);
                            string firstNmae = Convert.ToString(reader["FirstName"]);
                            string lastName = Convert.ToString(reader["LastName"]);
                            string nationalCode = Convert.ToString(reader["NationalCode"]);
                            string mobileNumber = Convert.ToString(reader["MobileNumber"]);
                            GuestDto guest = new GuestDto(id, firstNmae, lastName, nationalCode, mobileNumber);
                            list.Add(guest);
                        }
                    }
                    return OperationResult<List<GuestDto>>.Ok(list);

                }
            }
            catch (Exception ex)
            {
                return OperationResult<List<GuestDto>>.Failed(ex.Message);
            }
        }
        public OperationResult AddGuest(GuestDto guest)
        {
            string query = "[dbo].[Insertguest]";
            
            using (SqlConnection connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query);
                cmd.Connection = connection;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@firstName", guest.FirstName);
                cmd.Parameters.AddWithValue("@lastName", guest.LastName);
                cmd.Parameters.AddWithValue("@nationalCode", guest.NationalCode);
                cmd.Parameters.AddWithValue("@mobileNumber", guest.MobileNumber);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 1)
                {
                    return OperationResult.Ok();
                }
            }
            return OperationResult.Failed("خطا در ثبت");
        }

        public OperationResult RemoveGuest(int id)
        {
            
            string query = @"DELETE FROM Guests
                            WHERE Id=@id";
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
            return OperationResult.Failed("مهمانی با این ایدی پیدا نشد");
        }
        public OperationResult UpdateGuest(int id, string firstName, string lastName, string nationalCode, string mobileNumber)
        {
            string query = @"Update Guests 
                            set FirstName=@firstName,
                            	LastName=@lastName,
                            	NationalCode=@nationalCode,
                            	MobileNumber=@mobileNumber
                            where Id=@Id;";
            
            
            using (SqlConnection connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@nationalCode", nationalCode);
                cmd.Parameters.AddWithValue("@mobileNumber", mobileNumber);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 1)
                {
                    return OperationResult.Ok();
                }
            }
            return OperationResult.Failed("ویرایش ناموفق");
        }
       
        public OperationResult<GuestDto> GetGuestById(int id)
        {
            string query = @"select g.Id,g.FirstName,g.LastName,g.NationalCode,g.MobileNumber
                            from Guests as g
                            where g.Id=@Id;";
            using (SqlConnection connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("Id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        GuestDto guest= new GuestDto(
                            Convert.ToInt32(reader["Id"]),
                            Convert.ToString(reader["FirstName"]),
                            Convert.ToString(reader["LastName"]),
                            Convert.ToString(reader["NationalCode"]),
                            Convert.ToString(reader["MobileNumber"])
                            );
                        return OperationResult<GuestDto>.Ok(guest);
                    }
                }

            }
            return OperationResult<GuestDto>.Failed("آیدی وارد موجود نمی باشد");
        }
        public bool HasReservation(int guestId)
        {
            string query = @"select count(*)
                            from reservations
                             where GuestId=@guestId";
            using (SqlConnection connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@guestId", guestId);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
        public bool NationalCodeExist(string nationalCode)
        {
            string query = @"select count(*)
                            from Guests
                            where NationalCode=@nationalCode";
            using (SqlConnection connection = _connectionFactory.CreateConnection())
            {
                connection.Open ();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@nationalCode", nationalCode);
                int row=Convert.ToInt32(cmd.ExecuteScalar());
                return row > 0;
            }
            
                           
        }
        public bool IsNationalCodeExist(int id, string nationalCode)
        {
            string query = @"select count(*)
                            from Guests
                            where NationalCode=@nationalCode
                            AND Id<>@id";
            using (SqlConnection connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nationalCode", nationalCode);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }

        }

    }
}
