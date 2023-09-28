using MySqlConnector;
using Projekat.Model;
using System;
using System.Collections;
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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private readonly List<Quiz> quizes=new();
        private readonly BindingList<Quiz> bindQuizes;

        private List<Quiz> allQuizesFromBase=new();

        

        public AdminWindow()
        {
            InitializeComponent();

            bindQuizes = new(quizes)
            {
                RaiseListChangedEvents = true,
                AllowNew = true
            };


            quizesListBox.ItemsSource= bindQuizes;
            quizesListBox.DisplayMemberPath = "Name";

            LoadQuizes();

        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
             string name= nameTextBox.Text;
             int cratedBuId= Convert.ToInt32(Application.Current.Properties["id"]);

            try
            {
                Quiz.CreateQuiz(name, cratedBuId);
                LoadQuizes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadQuizes() {

            bindQuizes.Clear();

            try
            {
                int adminId = Convert.ToInt32(Application.Current.Properties["id"]);
                List<Quiz> allQuizes = Quiz.GetAllQuizesByCreatorId(adminId);
                allQuizesFromBase=new(allQuizes);
                foreach(Quiz q in allQuizes) {
                    bindQuizes.Add(q);
                }

                Search();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            
        }

        private void DeleteQuizBtn_Click(object sender, RoutedEventArgs e)
        {
            if (quizesListBox.SelectedItem is Quiz selected)
            {
                int id = selected.Id;

                try
                {
                    Quiz.DeleteById(id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                LoadQuizes();

            }


        }

        private void ShowQuizBtn_Click(object sender, RoutedEventArgs e)
        {
            if (quizesListBox.SelectedItem is Quiz selected)
            {
                Application.Current.Properties["quizId"] = selected.Id;
                QuizWindow window = new()
                {
                    Left = Left,
                    Top = Top
                };
                window.Show();
                Close();
            }
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

        private void ShowAttempts_Click(object sender, RoutedEventArgs e)
        {
            if (quizesListBox.SelectedItem is Quiz selected)
            {
                Application.Current.Properties["quizId"] = selected.Id;
                QuizAttemptWindow window = new()
                {
                    Left = Left,
                    Top = Top
                };
                window.Show();
                Close();
            }
        }

        private void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }


        private void Search()
        {
           
            string searchString = searchTextBox.Text.Trim();
           
            List<Quiz> filtered= allQuizesFromBase.FindAll(quiz => quiz.Name.ToLower().Contains(searchString.ToLower()));
            bindQuizes.Clear();
            foreach (Quiz quiz in filtered) {
                bindQuizes.Add(quiz);
            }

        }
    }
}
