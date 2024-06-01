using GameWpfApp.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GameWpfApp.DbConnection;
using GameWpfApp.Windows;

namespace GameWpfApp.AuthPages
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTb.Text) || string.IsNullOrEmpty(SurnameTb.Text) || string.IsNullOrEmpty(LoginTb.Text) || string.IsNullOrEmpty(PasswordPb.Password))
            {
                MessageBox.Show("Please fill all fields!");
                return;
            }

            var newUser = new User
            {
                Name = NameTb.Text,
                Surname = SurnameTb.Text,
                Login = LoginTb.Text,
                Password = PasswordPb.Password,
                RoleId = 2 // Default role for new users
            };

            try
            {
                DataBaseManager.AddUser(newUser);
                DataBaseManager.UpdateDatabase();
                MessageBox.Show("Registration successful!");
                // Optionally, redirect to login page
                NavigationService.Navigate(new AuthPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during registration: {ex.Message}");
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthPage());
        }
    }
}