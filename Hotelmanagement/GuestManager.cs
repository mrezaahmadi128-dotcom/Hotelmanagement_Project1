using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelmanagement
{
    public class GuestManager
    {
        private string connectionString =
                                         "Server=localhost\\SQLEXPRESS;" +
                                         "Database=HotelManagement;" +
                                         "Trusted_Connection=True;" +
                                         "TrustServerCertificate=True;";
        public  DataTable GetGuests()
        {
     
            string query = @"select g.Id,g.FirstName+' '+g.LastName as FullName,g.NationalCode,g.MobileNumber
                            from Guests as g";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adabter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adabter.Fill(table);
                return table;
            }

            //    using (SqlDataReader reader = cmd.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            int id = Convert.ToInt32(reader["Id"]);
            //            string firstNmae = Convert.ToString(reader["FirstName"]);
            //            string lastName = Convert.ToString(reader["LastName"]);
            //            string nationalCode = Convert.ToString(reader["NationalCode"]);
            //            string mobileNumber = Convert.ToString(reader["MobileNumber"]);
            //            Guest guest=new Guest(id,firstNmae,lastName,nationalCode,mobileNumber);
            //            list.Add(guest);
            //        }
            //    } 
            //}
            //return list;
        }
        public Result AddGuest(Guest guest)
        {
            string query = "[dbo].[Insertguest]";
            Result result =Guest.Validation(guest.FirstName,guest.LastName,guest.NationalCode,guest.MobileNumber);
            if(!result.Success)
                return result;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query);
                cmd.Connection = connection;
                cmd.CommandText = query;
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@firstName", guest.FirstName);
                cmd.Parameters.AddWithValue("@lastName", guest.LastName);
                cmd.Parameters.AddWithValue("@nationalCode", guest.NationalCode);
                cmd.Parameters.AddWithValue("@mobileNumber", guest.MobileNumber);
                int rowsAffected=cmd.ExecuteNonQuery();
                if(rowsAffected == 1)
                {
                    return Result.Ok();
                }
            }
            return Result.Failed("خطا در ثبت");
        }
        public Result UpdateGuest(int id,string firstName, string lastName, string nationalCode, string mobileNumber)
        {
            string query = @"Update Guests 
                            set FirstName=@firstName,
                            	LastName=@lastName,
                            	NationalCode=@nationalCode,
                            	MobileNumber=@mobileNumber
                            where Id=@Id;";
            Result reult = Guest.Validation(firstName, lastName, nationalCode, mobileNumber);
            if (!reult.Success)
                return reult;
            if(IsNationalCodeExist(id,nationalCode))
            {
                return Result.Failed("کدملی دارد شده موجود می باشد");
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {  connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@nationalCode", nationalCode);
                cmd.Parameters.AddWithValue("@mobileNumber", mobileNumber);
                int rowsAffected=cmd.ExecuteNonQuery();
                if (rowsAffected == 1)
                {
                    return Result.Ok();
                }
            }
            return Result.Failed("ویرایش ناموفق");
        }
        public bool IsNationalCodeExist(int id,string nationalCode)
        {
            string query = @"select count(*)
                            from Guests
                            where NationalCode=@nationalCode
                            AND Id<>@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nationalCode", nationalCode);
                int count=Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
             
        }
        
       
        public Result RemoveGuest(int id)
        {
            if (HasReservation(id))
            {
                return Result.Failed(" این مهمان دارای رزرو است");
            }
            string query = @"DELETE FROM Guests
                            WHERE Id=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                int rowsAffected = cmd.ExecuteNonQuery();
                
                if (rowsAffected == 1)
                {
                    return Result.Ok();
                }
            }
            return Result.Failed("مهمانی با این ایدی پیدا نشد");
        }
        public bool HasReservation(int guestId)
        {
            string query = @"select count(*)
                            from reservations
                             where GuestId=@guestId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open ();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@guestId", guestId);
                int count=Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
        public  Guest GetGuestById(int id)
        {
            string query = @"select g.Id,g.FirstName,g.LastName,g.NationalCode,g.MobileNumber
                            from Guests as g
                            where g.Id=@Id;";
            using(SqlConnection connection=new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("Id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        return new Guest(
                            Convert.ToInt32(reader["Id"]),
                            Convert.ToString(reader["FirstName"]),
                            Convert.ToString(reader["LastName"]),
                            Convert.ToString(reader["NationalCode"]),
                            Convert.ToString(reader["MobileNumber"])
                            );
                    }
                }

            }
               return null;
        }
    }
}
