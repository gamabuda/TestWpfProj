using Cats.Core;
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
using Cats.Service;

namespace Cats.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorisationWindow.xaml
    /// </summary>
    public partial class AuthorisationWindow : Window
    {
        public AuthorisationWindow()
        {
            InitializeComponent();
            LoginTb.Focus();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void CreateAccountBtn_Click(object sender, RoutedEventArgs e)
        {
            User user;
            if (DataBaseManager.CanRegister(LoginTb.Text, PasswordTb.Password, out user) == true)
            {
                UserContext.CurrentUser = user;
                DataBaseManager.AddUser(user);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
        }

        private void GuestBtn_OnClick(object sender, RoutedEventArgs e)
        {
            UserContext.Guest();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void PasswordTb_OnKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key != Key.Enter) return;

            Login();
        }

        private void Login()
        {
            User user;
            if (DataBaseManager.CanLogin(LoginTb.Text, PasswordTb.Password, out user))
            {
                UserContext.CurrentUser = user;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
        }
    }
}
