using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Web;
using ServicioWeb.Modelds;

namespace ServicioWeb.Class
{
    public class QueryClass
    {
        private string connectionString ;
        SqlConnection _connection;
        public QueryClass()
        {
         
            connectionString = "server=POLK\\SQLEXPRESS;database=generaldb;integrated security=true;";
            _connection = new SqlConnection(connectionString);
        }

        public List<Userdbt> GetList()
        {
            var userdbt = new List<Userdbt>();

            try
            {

                _connection.Open();

            SqlCommand comd = new SqlCommand("Select * from userdt", _connection);
            SqlDataReader reade = comd.ExecuteReader();
            
            while (reade.Read())
            {
                userdbt.Add(new Userdbt
                { id_user= (int)reade["user_id"],
                    email_user = (string)reade["email_user"],
                    name_user = (string)reade["name_user"],
                    password_user = (String)reade["password_user"]
                });
            }
                _connection.Close();
            }
            catch (SqlException ex)
            {
                userdbt.Add(new Userdbt { name_user = "Error al ejecutar la consulta: " + ex.Message });
            }
            return userdbt;
        }

        public List<Userdbt> GetUser(int id_user)
        {
            var userdbt = new List<Userdbt>();
        
            try
            {

                _connection.Open();
                string query = "SELECT * FROM userdt WHERE user_id = @user_id ";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@user_id", id_user);
                SqlDataReader reade = command.ExecuteReader();

                while (reade.Read())
                {
                    userdbt.Add(new Userdbt
                    {
                        id_user = (int)reade["user_id"],
                        email_user = (string)reade["email_user"],
                        name_user = (string)reade["name_user"],
                        password_user = (String)reade["password_user"]
                    });
                }
                _connection.Close();
            }
            catch (SqlException ex)
            {
                userdbt.Add(new Userdbt { name_user = "Error al ejecutar la consulta: " + ex.Message });
            }
            return userdbt;
        }

        public string CreateUser(string name_user,string email_user,string password_user)
        {
            string result = "";
            try
            {
               
                _connection.Open();
                string query = " INSERT INTO userdt (email_user, name_user,password_user) VALUES (@email_user, @name_user, @password_user) ";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@email_user", email_user);
                command.Parameters.AddWithValue("@name_user", name_user);
                command.Parameters.AddWithValue("@password_user", password_user);
                command.ExecuteReader();

                _connection.Close();

                _connection.Open();
                string query2 = "SELECT * FROM userdt WHERE email_user = @email_user ";
                command = new SqlCommand(query2, _connection);
                command.Parameters.AddWithValue("@email_user", email_user);
                SqlDataReader reade = command.ExecuteReader();
                while (reade.Read())
                {


                    if ((int)reade["user_id"] > 0)
                    {
                        result = "Creado Correctamente ";
                    }
                    else
                    {
                        result = "Error de Creacion";
                    }
                }
                _connection.Close();

            }
            catch (SqlException ex)
            {
                result = "Error al ejecutar la consulta: " + ex.Message;
            }
            return result;
        }

        public string Delete(int id_user)
        {
            string result = "";
            try
            {
             
                _connection.Open();
                string query = "DELETE FROM userdt WHERE  user_id = @user_id ";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@user_id", id_user);
                var rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    result = "Eliminado Correctamente";

                }
                else
                {
                    result = "Error al Eliminar";
                }
                _connection.Close();
            }
            catch (SqlException ex)
            {
                result="Error al ejecutar la consulta: " + ex.Message;
            }
           
            return result;
        }

        public string EditarUser(int user_id, string name_user, string email_user, string password_user)
        {
            string result = "";
            try
            {

                _connection.Open();
                string query = "UPDATE userdt SET email_user = @email_user,name_user=@name_user,password_user=@password_user WHERE user_id = @user_id ";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@user_id", user_id);
                command.Parameters.AddWithValue("@email_user", email_user);
                command.Parameters.AddWithValue("@name_user", name_user);
                command.Parameters.AddWithValue("@password_user", password_user);
                var rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    result = "Eliminado Correctamente";
                   
                }
                else
                {
                    result = "Error al Eliminar";
                }

                _connection.Close();
            }
            catch (SqlException ex)
            {
                result = "Error al ejecutar la consulta: " + ex.Message;
            }
            return result;

        }

        }
}