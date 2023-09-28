using MySqlConnector;
using Projekat.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Projekat.Model
{
    internal class Answer
    {
        public Answer(int id,string text,bool isCorrect ,int questionId) { 
            Id= id;
            Text= text;
            IsCorrect= isCorrect;
            QuestionId=questionId;
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public bool IsCorrect { get; set; }


        public static List<Answer> GetAnswersByQuestionId(int id) {
            MySqlConnection conn = DatabaseManager.GetConnection();

            List<Answer> list = new();
            try
            {
                conn.Open();
                string query = "SELECT * FROM answer WHERE question_id=@question_id";
                MySqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@question_id",id);
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Answer(
                        Convert.ToInt32(reader["id"]),
                        (string)reader["text"],
                        (bool)reader["is_correct"],
                        Convert.ToInt32(reader["question_id"])
                        ));

                }
                return list;
            }
            finally
            {
                conn.Close();
            }
        }


        public static Answer GetAnswersById(int id)
        {
            MySqlConnection conn = DatabaseManager.GetConnection();

            try
            {
                conn.Open();
                string query = "SELECT * FROM answer WHERE id=@id";
                MySqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return  new Answer(
                            Convert.ToInt32(reader["id"]),
                            (string)reader["text"],
                            (bool)reader["is_correct"],
                            Convert.ToInt32(reader["question_id"])
                            );

                    }
                }
                throw new NotFoundException("Invalid id for an answer : "+id);
            }
            finally
            {
                conn.Close();
            }
        }

        public static void AddFourNewBlank(long questionId)
        {

            MySqlConnection conn = DatabaseManager.GetConnection();

            try
            {
                conn.Open();
                String query = "INSERT INTO `answer` ( `text`, `is_correct`,`question_id`) " +
                       "VALUES ( 'Answer1', 1, @id), " +
                              "( 'Answer2', 0, @id), " +
                              "( 'Answer3', 0, @id), " +
                              "( 'Answer4', 0, @id);";
                MySqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@id", questionId);
                cmd.ExecuteNonQuery();

            }
            finally
            {
                conn.Close();
            }
        }

        public static void Update(int id, string answerText, bool isCorrect)
        {
            MySqlConnection conn = DatabaseManager.GetConnection();

            
            try
            {
                conn.Open();
                string query = "UPDATE answer " +
                    "SET text = @text , is_correct=@is_correct " +
                    "WHERE id=@id;";
                MySqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@text", answerText);
                cmd.Parameters.AddWithValue("@is_correct", isCorrect);
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
