using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projekat.Model
{
    internal class Quiz
    {
        public Quiz(int id,String name) { 
            Id = id;
             Name = name;
        }
        public string Name {get;set;}

        public int Id { get; set; }



        public static void DeleteById(int id) {
            MySqlConnection conn = DatabaseManager.GetConnection();

            try
            {
                conn.Open();

                String query = "DELETE FROM quiz WHERE id=@id";
                MySqlCommand cmd = new (query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

            }
            finally
            {
                conn.Close();
            }
        }

        public static List<Quiz> GetAllQuizesByCreatorId(int id) { 
            MySqlConnection conn = DatabaseManager.GetConnection();

            List<Quiz> list = new ();
            try
            {
                conn.Open();
                string query = "SELECT * FROM quiz WHERE created_by=@created_by";
                MySqlCommand cmd = new (query, conn);
                cmd.Parameters.AddWithValue("@created_by", id);
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Quiz(
                        Convert.ToInt32(reader["id"]),
                        (string)reader["name"]
                        ));
                }
                return list;
            }
            finally
            {
                conn.Close();
            }
        }


        public static void CreateQuiz(string name,int createdById) {
            MySqlConnection conn = DatabaseManager.GetConnection();

            try
            {
                conn.Open();
                String query = "INSERT INTO `quiz` ( `name`, `created_by`) " +
                       "           VALUES ( @name, @created_by) ";
                MySqlCommand cmd = new (query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@created_by", createdById);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        public static Quiz GetQuizById(int id)
        {


            MySqlConnection conn = DatabaseManager.GetConnection();

            try
            {
                conn.Open();
                string query = "SELECT * FROM quiz WHERE id=@id";
                MySqlCommand cmd = new (query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                using MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                return new Quiz(
                    Convert.ToInt32(reader["id"]),
                    (string)reader["name"]
                    );
            }
            finally
            {
                conn.Close();
            }
        }

        internal static List<Quiz> GetAllQuizes()
        {
            MySqlConnection conn = DatabaseManager.GetConnection();

            List<Quiz> list = new();
            try
            {
                conn.Open();
                string query = "SELECT * FROM quiz ";
                MySqlCommand cmd = new (query, conn);
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Quiz(
                        Convert.ToInt32(reader["id"]),
                        (string)reader["name"]
                        ));
                }
                return list;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
