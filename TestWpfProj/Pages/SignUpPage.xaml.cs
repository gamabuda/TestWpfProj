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
using TestWpfProj.Data.Users;

namespace TestWpfProj.Pages
{
    public partial class SignUpPage : Page
    {
        private User _user;
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignInPage());
        }

        private void GuestButton_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow(Data.DataContext.Guest).Show();
            Window ownerWindow = Window.GetWindow(this);
            ownerWindow.Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Password;
            if (PasswordTextBox.Password == ConfirmPasswordTextBox.Password && !Data.DataContext.Users.Exists(x => x.Login == login && x.Password == password))
            {
                _user = new User(login, password);
                new MainWindow(_user).Show();
                Window ownerWindow = Window.GetWindow(this);
                ownerWindow.Close();
            }
            else
                MessageBox.Show("Некорректные данные!", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
