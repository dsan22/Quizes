using Microsoft.VisualBasic;
using MySqlConnector;
using Projekat.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace Projekat.Model
{
    internal class Question
    {

    

        public Question(int id,string text)
        {
            Id = id;
            Text = text;
            Answers = new();
        }

        public string Text { get; set; }
        public int Id { get; set; }

        public List<Answer> Answers { get; set; }


        public static List<Question> GetByQuizId(int id) {

            MySqlConnection conn = DatabaseManager.GetConnection();

            List<Question> list = new();
            try
            {
                conn.Open();
                string query = "SELECT * FROM question WHERE quiz_id=@quiz_id";
                MySqlCommand cmd = new (query, conn);
                cmd.Parameters.AddWithValue("@quiz_id", id) ;
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Question q = new(
                        Convert.ToInt32(reader["id"]),
                        (string)reader["text"]
                        );
                    q.Answers = Answer.GetAnswersByQuestionId(Convert.ToInt32(reader["id"]));
                    list.Add(q);

                }
                return list;
            }
            finally
            {
                conn.Close();
            }

        }


        public static Question GetById(int id)
        {

            MySqlConnection conn = DatabaseManager.GetConnection();

            
            try
            {
                conn.Open();
                string query = "SELECT * FROM question WHERE id=@id";
                MySqlCommand cmd = new (query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                using MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Question q = new(
                        Convert.ToInt32(reader["id"]),
                        (string)reader["text"]
                        );
                    q.Answers = Answer.GetAnswersByQuestionId(Convert.ToInt32(reader["id"]));
                    return q;

                }
                throw new NotFoundException("Wrong id for question : " + id);
            }
            finally
            {
                conn.Close();
            }

        }

        internal static void AddNewBlank()
        {

            MySqlConnection conn = DatabaseManager.GetConnection();

            try
            {
                conn.Open();
                String query = "INSERT INTO `question` ( `text`, `quiz_id`) " +
                       "           VALUES ( @text, @quiz_id) ";
                MySqlCommand cmd = new (query, conn);
                cmd.Parameters.AddWithValue("@text", "Question text");
                cmd.Parameters.AddWithValue("@quiz_id", Application.Current.Properties["quizId"]);
                cmd.ExecuteNonQuery();

                long questionId = cmd.LastInsertedId;
                Answer.AddFourNewBlank(questionId);
            }
            finally
            {
                conn.Close();
            }
        }

        internal static void Delete(int id)
        {
            MySqlConnection conn = DatabaseManager.GetConnection();

 
            try
            {
                conn.Open();
                string query = "DELETE FROM question WHERE id=@id;";
                MySqlCommand cmd = new (query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

            }
            finally
            {
                conn.Close();
            }
        }

        internal static void Update(int id,string text)
        {
            

            MySqlConnection conn = DatabaseManager.GetConnection();

           
            try
            {
                conn.Open();
                string query = "UPDATE question " +
                    "SET text = @text " +
                    "WHERE id=@id;";
                MySqlCommand cmd = new (query, conn);
                cmd.Parameters.AddWithValue("@text", text);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

            }
            finally
            {
                conn.Close();
            }
        }
    }
}
