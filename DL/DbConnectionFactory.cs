using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class DbConnectionFactory
    {
        private string _connectionString;
        public DbConnectionFactory()
        {
            _connectionString= ConfigurationManager.ConnectionStrings["HotelDb"].ConnectionString;
        }
        public SqlConnection CreateConnection()
        {
            return new SqlConnection( _connectionString );
        }
    }
}
