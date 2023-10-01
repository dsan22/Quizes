using MySqlConnector;
using Projekat.Exceptions;
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

namespace Projekat
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = usernameTextBox.Text;
                string password = passwordTextBox.Password;
                string retypePassword = retypePasswordTextBox.Password;
            
                bool? isAdmin= adminCheckBox.IsChecked;
                if(isAdmin==null) return;
                if (password != retypePassword)
                {
                    MessageBox.Show("Passwords does not match");
                }
                else
                {
                    User.CreateUser(username, password,(bool)isAdmin);
                    OpenLogin();
                }
            }
            catch (UsernameAlreadyTakenException ex) {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            OpenLogin();
        }

        private void OpenLogin() {
            LoginWindow loginWindow = new()
            {
                Left = Left,
                Top = Top
            };
            loginWindow.Show();
            this.Close();
        } 
    }
}
