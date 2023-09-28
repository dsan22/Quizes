using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Projekat.Model
{
    internal class QuizAttempt
    {

        public QuizAttempt() {
            Answers = new();
        }

        public int Id { get; set; }

        public int QuizId { get; set; }

        public int UserId { get; set; }

        public List<Answer> Answers {get;set;}


        public static int SaveQuizAttempt(QuizAttempt attempt) {

            MySqlConnection conn = DatabaseManager.GetConnection();
            try
            {
                conn.Open();

                string query = "INSERT INTO `user_quiz_attempt` ( `user_id`, `quiz_id`) " +
                            "VALUES ( @user_id, @quiz_id)";

                MySqlCommand cmd = new (query, conn);
                cmd.Parameters.AddWithValue("@user_id", attempt.UserId);
                cmd.Parameters.AddWithValue("@quiz_id", attempt.QuizId);

                cmd.ExecuteNonQuery();

                long attemptId = cmd.LastInsertedId;


                foreach (Answer answer in attempt.Answers) {

                     query = "INSERT INTO `user_quiz_answer` ( `user_quiz_attempt_id`, `answer_id`)" +
                        " VALUES ( @attempt_id, @answer_id)";

                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@attempt_id", attemptId);
                    cmd.Parameters.AddWithValue("@answer_id", answer.Id);
                    cmd.ExecuteNonQuery();


                }
                return (int)attemptId;

            }
            finally
            {
                conn.Close();
            }

        }

        public static QuizAttempt GetById(int quizAttemptId)
        {
            MySqlConnection conn = DatabaseManager.GetConnection();
            try
            {
                conn.Open();

                QuizAttempt attempt = new ();

                string query = "SELECT * FROM user_quiz_attempt where id=@id ";

                MySqlCommand cmd = new (query, conn);
                cmd.Parameters.AddWithValue("@id", quizAttemptId);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        attempt.QuizId = (int)reader["quiz_id"];
                        attempt.UserId = (int)reader["user_id"];
                    }
                }


                 query = "SELECT * FROM user_quiz_answer where user_quiz_attempt_id=@id ";

                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", quizAttemptId);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int answerId =(int) reader["answer_id"];
                        Answer answer = Answer.GetAnswersById(answerId);
                        attempt.Answers.Add(answer);
 
                    }
                }

                return attempt;

            }
            finally
            {
                conn.Close();
            }
        }


        public static List<QuizAttempt> GetByQuizId(int questionId)
        {
            MySqlConnection conn = DatabaseManager.GetConnection();
            try
            {
                conn.Open();

                List<QuizAttempt> list = new ();

                string query = "SELECT * FROM user_quiz_attempt where quiz_id=@id ";

                MySqlCommand cmd = new (query, conn);
                cmd.Parameters.AddWithValue("@id", questionId);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int attemptId = (int)reader["id"];

                        list.Add(GetById(attemptId));
                    }
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
