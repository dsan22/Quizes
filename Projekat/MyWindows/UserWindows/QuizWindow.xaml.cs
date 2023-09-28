using Projekat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projekat.MyWindows.UserWindows
{
    /// <summary>
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {
        private readonly Quiz quiz;
        readonly List<Question> questions;
        readonly List<Answer> answers=new();


        int nextQuestionIndex = 1;
        

        Question? currentQuestion;

        public QuizWindow()
        {
            InitializeComponent();
            quiz = Quiz.GetQuizById(Convert.ToInt32(Application.Current.Properties["quizId"]));
            questions = Question.GetByQuizId(quiz.Id);

            quizNameLabel.Content = quiz.Name;

            LoadNextQuestion();
        }

        public void LoadNextQuestion() {

            if (questions.Count == 0) {
                return;
            }
           

            if (nextQuestionIndex == questions.Count + 1) {
               
                SaveQuizAttempt();

                QuizResultWindow window = new()
                {
                    Left = Left,
                    Top = Top
                };
                window.Show();
                Close();


                return;
            }
            
            currentQuestion = questions.ElementAt((nextQuestionIndex++) -1);
            questionTextLabel.Content = currentQuestion.Text;

            Answer1Btn.Content = currentQuestion.Answers[0].Text;
            Answer2Btn.Content = currentQuestion.Answers[1].Text;
            Answer3Btn.Content = currentQuestion.Answers[2].Text;
            Answer4Btn.Content = currentQuestion.Answers[3].Text;

        }

        private void Answer1Btn_Click(object sender, RoutedEventArgs e)
        {
            AnswerCurrentQuestion(0);
        }

        private void Answer2Btn_Click(object sender, RoutedEventArgs e)
        {
            AnswerCurrentQuestion(1);
        }

        private void Answer3Btn_Click(object sender, RoutedEventArgs e)
        {
            AnswerCurrentQuestion(2);
        }

        private void Answer4Btn_Click(object sender, RoutedEventArgs e)
        {
            AnswerCurrentQuestion(3);
        }

        public void AnswerCurrentQuestion(int answer) {

            if (currentQuestion == null) return;

            answers.Add(currentQuestion.Answers[answer]);
            LoadNextQuestion();


        
        }


        public void SaveQuizAttempt() {

            int userId = Convert.ToInt32(Application.Current.Properties["id"]);
            QuizAttempt attempt = new()
            {
                QuizId = quiz.Id,
                UserId = userId,
                Answers = answers
        };

            int attemptId=QuizAttempt.SaveQuizAttempt(attempt);

            Application.Current.Properties["attemptId"]=attemptId;




        }

        private void GoBackToQuizes(object sender, RoutedEventArgs e)
        {

            Application.Current.Properties.Remove("quizId");
            UserWindow window = new()
            {
                Top = Top,
                Left = Left
            };
            window.Show();

            Close();

        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            Application.Current.Properties.Clear();
            LoginWindow window = new()
            {
                Top = Top,
                Left = Left
            };
            window.Show();

            Close();

        }
    }
}
