using Projekat.Model;
using Projekat.MyWindows.AdminWindows;
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

namespace Projekat.MyWindows.UserWindows
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {

        private readonly List<Quiz> quizes = new();
        private readonly BindingList<Quiz> bindQuizes;

        private List<Quiz> allQuizesFromBase = new();
        public UserWindow()
        {
            InitializeComponent();


            bindQuizes = new(quizes)
            {
                RaiseListChangedEvents = true,
                AllowNew = true
            };


            quizesListBox.ItemsSource = bindQuizes;
            quizesListBox.DisplayMemberPath = "Name";

            LoadQuizes();
        }


        private void LoadQuizes()
        {

            bindQuizes.Clear();

            try
            {
                List<Quiz> allQuizes = Quiz.GetAllQuizes();
                allQuizesFromBase = new(allQuizes);
                foreach (Quiz q in allQuizes)
                {
                    bindQuizes.Add(q);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void DoQuizBtn_Click(object sender, RoutedEventArgs e)
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


        private void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }


        private void Search()
        {

            string searchString = searchTextBox.Text.Trim();

            List<Quiz> filtered = allQuizesFromBase.FindAll(quiz => quiz.Name.ToLower().Contains(searchString.ToLower()));
            bindQuizes.Clear();
            foreach (Quiz quiz in filtered)
            {
                bindQuizes.Add(quiz);
            }

        }


    }
}
