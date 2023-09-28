using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Projekat.Exceptions;

namespace Projekat.Model
{
    internal class User
    {

        public User(int id,string username, string password,bool isAdmin) {
            Id = id;
            Username=username;
            Password=password;
            IsAdmin=isAdmin;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }


        public static User GetByUsernameAndPassword(string username, string password) {
            MySqlConnection connection = DatabaseManager.GetConnection();

            try
            {
                connection.Open();

                string query = "SELECT * FROM user WHERE username=@username AND password=@password";
                MySqlCommand cmd = new (query, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                using MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new User(
                           (int)reader["id"],
                           (string)reader["username"],
                           (string)reader["password"],
                           (bool)reader["is_admin"]
                        );
                }
                else
                {
                    throw new NotFoundException("Wrong username or password");
                }

            }
            finally
            {
                connection.Close();
            }

        }

        public static void CreateUser(string username,string password,bool isAdmin) {

            MySqlConnection conn = DatabaseManager.GetConnection();

            try
            {
                conn.Open();

                string query = "SELECT COUNT(1) FROM user WHERE username=@username";
                MySqlCommand cmd = new (query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                if (Convert.ToInt32(cmd.ExecuteScalar()) == 1)
                {
                    throw new UsernameAlreadyTakenException(username);
                }
                else
                {

                    query = "INSERT INTO `user` ( `username`, `password`,`is_admin`) " +
                       "           VALUES ( @username, @password,@isAdmin) ";
                    cmd = new (query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@isAdmin", isAdmin);
                    cmd.ExecuteNonQuery();
                   

                }
            }
            finally
            {
                conn.Close();
            }
        }

        public static User GetById(int id)
        {
            MySqlConnection connection = DatabaseManager.GetConnection();

            try
            {
                connection.Open();

                string query = "SELECT * FROM user WHERE id=@id";
                MySqlCommand cmd = new (query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                using MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new User(
                           (int)reader["id"],
                           (string)reader["username"],
                           (string)reader["password"],
                           (bool)reader["is_admin"]
                        );
                }
                else
                {
                    throw new NotFoundException("Wrong username or password");
                }

            }
            finally
            {
                connection.Close();
            }

        }

    }
}
