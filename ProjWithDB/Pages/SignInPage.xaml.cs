using ProjWithDB.Data;
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

namespace ProjWithDB.Pages
{
    public partial class SignInPage : Page
    {
        private User _user;
        private List<User> _users = DBManager.GetUsers();
        public SignInPage()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignUpPage());
        }

        private void GuestButton_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow(_users[0]).Show();
            Window.GetWindow(this).Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;
            _user = new User();

            if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (CheckLogin() && CheckPassword())
            {
                foreach (var u in DBManager.GetUsers())
                {
                    if (u.Login == login.ToLower().Trim())
                    {
                        _user = u;
                        new MainWindow(_user).Show();
                        Window.GetWindow(this).Close();
                        return;
                    }
                }
            }
        }

        private bool CheckLogin()
        {
            string login = LoginTextBox.Text;
            bool isExisted = false;

            foreach (var user in _users)
            {
                if (login.ToLower().Trim() == user.Login)
                {
                    isExisted = true;
                    _user = user;
                }

            }

            if (!isExisted)
                MessageBox.Show("Пользователя с таким логином не существует!", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);

            return isExisted;
        }

        private bool CheckPassword()
        {
            bool isValid = false;
            string password = PasswordBox.Password;

            if (password.Trim() == _user.Password)
                isValid = true;
            else
                MessageBox.Show("Неверный пароль!", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);

            return isValid;
        }
    }
}
