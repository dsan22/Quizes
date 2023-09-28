using Projekat.Model;
using Projekat.MyWindows.UserWindows;
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

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Paragraph = iTextSharp.text.Paragraph;
using Microsoft.Win32;

namespace Projekat.MyWindows.AdminWindows
{
    /// <summary>
    /// Interaction logic for QuizAttemptWindow.xaml
    /// </summary>
    /// 


   

    public partial class QuizAttemptWindow : Window
    {
        readonly List<QuizAttempt> attempts = new();

        readonly List<UsersAttempt> userAttempts = new();
        public QuizAttemptWindow()
        {
            InitializeComponent();

            int quizId = Convert.ToInt32(Application.Current.Properties["quizId"]);
            attempts = QuizAttempt.GetByQuizId(quizId);
         

            foreach (QuizAttempt attempt in attempts) {
                User user = User.GetById(attempt.UserId);

                userAttempts.Add(new UsersAttempt { User = user, Attempt = attempt });
            }

            usersListBox.ItemsSource = userAttempts;
           
            usersListBox.DisplayMemberPath = "User.Username";

        }





        private void GoBackToQuizes(object sender, RoutedEventArgs e)
        {

            Application.Current.Properties.Remove("quizId");
            AdminWindow window = new()
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

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (usersListBox.SelectedItem is not UsersAttempt selected) return;
            if (selected.Attempt == null) return;

            QuizAttempt attempt = selected.Attempt;

            List<QuizRessult> list = new();

            foreach (Answer answer in attempt.Answers)
            {
                Question question = Question.GetById(answer.QuestionId);
                if (question == null) continue;
                Answer correctAnswer = question.Answers.Find(ans => ans.IsCorrect);
                if (correctAnswer == null) continue;
                list.Add(new QuizRessult
                {
                    Question = question.Text,
                    Answer = answer.Text,
                    CorrectAnswer = correctAnswer.Text,
                    IsCorrect = answer.IsCorrect

                });
            }

            dataGrid.ItemsSource = list;

            
        }

        private void SavePDF_Click(object sender, RoutedEventArgs e)
        {

            SaveFileDialog saveFileDialog = new()
            {
                Filter = "PDF Files|*.pdf",
                Title = "Save PDF File"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                
                string filePath = saveFileDialog.FileName;

               
                Document doc = new ();

                try
                {
                   
                    using (FileStream fs = new (filePath, FileMode.Create))
                    {
                       
                        PdfWriter writer = PdfWriter.GetInstance(doc, fs);

                        
                        doc.Open();

                        
                        PdfPTable table = new (3);

                        
                        table.AddCell("User");
                        table.AddCell("Correct answers");
                        table.AddCell("Percentage");

                     
                        foreach (UsersAttempt usersAttempt in userAttempts) {
                            int correctAnswersCount = usersAttempt.Attempt.Answers.Count(ans => ans.IsCorrect);
                            double percentage = 100 * (double)correctAnswersCount / usersAttempt.Attempt.Answers.Count;

                            table.AddCell(usersAttempt.User.Username);
                            table.AddCell( correctAnswersCount+"/"+ usersAttempt.Attempt.Answers.Count);
                            table.AddCell(Math.Round(percentage, 2) + "%");

                        }

                        
                        doc.Add(table);

                        
                        doc.Close();
                    }

                    
                    MessageBox.Show("PDF saved successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

        }
    }
}