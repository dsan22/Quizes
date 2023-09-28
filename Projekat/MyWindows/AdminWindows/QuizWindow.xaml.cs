using Projekat.Model;
using Projekat.MyWindows.UserWindows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Projekat.MyWindows.AdminWindows
{
    /// <summary>
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {
         private readonly Quiz quiz;

        

        private readonly List<Question> questions = new();
        private readonly BindingList<Question> bindQuestion;
        public QuizWindow()
        {
            
            InitializeComponent();

            quiz = Quiz.GetQuizById(Convert.ToInt32(Application.Current.Properties["quizId"]));
            nameLabel.Content = "Quiz: "+ quiz.Name;


            bindQuestion = new(questions)
            {
                RaiseListChangedEvents = true,
                AllowNew = true
            };


            questionListBox.ItemsSource = bindQuestion;
            questionListBox.DisplayMemberPath = "Text";

            LoadQuestions();
        }


        private void LoadQuestions() {
            bindQuestion.Clear();

            try
            {
                int quizId = Convert.ToInt32(Application.Current.Properties["quizId"]);
                List<Question> list = Question.GetByQuizId(quizId);
                foreach (Question q in list)
                {
                    bindQuestion.Add(q);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            questionListBox.SelectedIndex = 0;
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (questionListBox.SelectedItem is Question selected)
            {

                questionTextBox.Text = selected.Text;

                answer1TextBox.Text = selected.Answers[0].Text;
                answer2TextBox.Text = selected.Answers[1].Text;
                answer3TextBox.Text = selected.Answers[2].Text;
                answer4TextBox.Text = selected.Answers[3].Text;

                answer1Radio.IsChecked = selected.Answers[0].IsCorrect;
                answer2Radio.IsChecked = selected.Answers[1].IsCorrect;
                answer3Radio.IsChecked = selected.Answers[2].IsCorrect;
                answer4Radio.IsChecked = selected.Answers[3].IsCorrect;
            }

        }

        private void SaveQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = questionListBox.SelectedIndex;
            if (questionListBox.SelectedItem is Question selected)
            {
                try
                {
                    string text = questionTextBox.Text;
                    if (text != selected.Text)
                    {
                        Question.Update(selected.Id, text);
                    }

                    string answerText;
                    bool? isCorrect;

                    answerText = answer1TextBox.Text;
                  
                    isCorrect = answer1Radio.IsChecked;
                    if (isCorrect == null) return;
                    if (answerText != selected.Answers[0].Text || isCorrect != selected.Answers[0].IsCorrect)
                    {
                        Answer.Update(selected.Answers[0].Id, answerText, (bool)isCorrect);
                    }

                    answerText = answer2TextBox.Text;
                    isCorrect = answer2Radio.IsChecked;
                    if (isCorrect == null) return;
                    if (answerText != selected.Answers[1].Text || isCorrect != selected.Answers[1].IsCorrect)
                    {
                        Answer.Update(selected.Answers[1].Id, answerText, (bool)isCorrect);
                    }

                    answerText = answer3TextBox.Text;
                    isCorrect = answer3Radio.IsChecked;
                    if (isCorrect == null) return;
                    if (answerText != selected.Answers[2].Text || isCorrect != selected.Answers[2].IsCorrect)
                    {
                        Answer.Update(selected.Answers[2].Id, answerText, (bool)isCorrect);
                    }

                    answerText = answer4TextBox.Text;
                    isCorrect = answer4Radio.IsChecked;
                    if (isCorrect == null) return;
                    if (answerText != selected.Answers[3].Text || isCorrect != selected.Answers[3].IsCorrect)
                    {
                        Answer.Update(selected.Answers[3].Id, answerText, (bool)isCorrect);
                    }


                    LoadQuestions();
                    questionListBox.SelectedIndex = selectedIndex;
                    MessageBox.Show("Question successfully saved");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Question.AddNewBlank();
                LoadQuestions();
                questionListBox.SelectedIndex=questionListBox.Items.Count-1;    
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (questionListBox.SelectedItem is Question selected)
            {
                try
                {
                    Question.Delete(selected.Id);
                    LoadQuestions();
                    questionListBox.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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
    }
}
