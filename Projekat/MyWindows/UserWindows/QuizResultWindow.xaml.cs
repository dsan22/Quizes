using Projekat.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for QuizResultWindow.xaml
    /// </summary>
    public partial class QuizResultWindow : Window
    {

        private readonly QuizAttempt attempt;

       

        public QuizResultWindow()
        {
            InitializeComponent();
            int quizAttemptId = Convert.ToInt32(Application.Current.Properties["attemptId"]);
            attempt = QuizAttempt.GetById(quizAttemptId);
            
            LoadTable();
            int correctAnswersCount=attempt.Answers.Count(ans=>ans.IsCorrect);

            scoreLabel.Content = correctAnswersCount + "/" + attempt.Answers.Count;

            double percentage = 100* (double)correctAnswersCount / attempt.Answers.Count;

            percentageLabel.Content = Math.Round(percentage, 2) +"%";

        }

        public void LoadTable() {

            List<QuizRessult> list = new();

            foreach (Answer answer in attempt.Answers) {
                Question question = Question.GetById(answer.QuestionId);
                Answer correctAnswer = question.Answers.Find(ans => ans.IsCorrect);
                if(correctAnswer == null) continue;
                list.Add(new QuizRessult { 
                    Question = question.Text,
                    Answer = answer.Text,
                    CorrectAnswer = correctAnswer.Text,
                    IsCorrect=answer.IsCorrect
                   
                });
            }

            dataGrid.ItemsSource = list;
        }

       

        private void GoBackToQuizes(object sender, RoutedEventArgs e)
        {

            Application.Current.Properties.Remove("quizId");
            Application.Current.Properties.Remove("attemptId");

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




