using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ServicioWeb.Class
{
 
    public class Database
    {
        private static Database _instance;
        private SqlConnection _connection;

        public  Database()
        {
            string connectionString = "xxxxxxx";
            _connection = new SqlConnection(connectionString);
        }

        public static Database GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Database();
            }

            return _instance;
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }

      
    }
}