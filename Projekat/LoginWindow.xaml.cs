using Projekat.MyWindows.AdminWindows;
using Projekat.MyWindows.UserWindows;
using System;
using System.Windows;

namespace Projekat
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string username = usernameTextBox.Text;
                string password = passwordTextBox.Text;

                Model.User user = Model.User.GetByUsernameAndPassword(username,password);
                if (user.IsAdmin)
                {
                    Application.Current.Properties["id"] = user.Id;
                    AdminWindow window = new()
                    {
                        Left = Left,
                        Top = Top
                    };
                    window.Show();
                    Close();
                }
                else {
                    Application.Current.Properties["id"] = user.Id;
                    UserWindow window = new()
                    {
                        Left = Left,
                        Top = Top
                    };
                    window.Show();
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            Register reg = new()
            {
                Left = Left,
                Top = Top
            };
            reg.Show();
            Close();
        }
    }
}
