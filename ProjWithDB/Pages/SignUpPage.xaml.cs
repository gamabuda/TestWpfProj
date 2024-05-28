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
using ProjWithDB.Data;

namespace ProjWithDB.Pages
{
    public partial class SignUpPage : Page
    {
        private User _user;
        private List<User> _users = DBManager.GetUsers();
        private Dictionary<string, List<char>> _symbols = new Dictionary<string, List<char>>() { };
        public SignUpPage()
        {
            InitializeComponent();

            List<char> lettersUpper = new List<char>();
            List<char> lettersLow = new List<char>();
            List<char> numbers = new List<char>();
            List<char> special = new List<char>();

            for (var i = 'A'; i <= 'Z'; i++)
                lettersUpper.Add(i);
            _symbols["lettersUpper"] = lettersUpper;

            for (var i = 'a'; i <= 'z'; i++)
                lettersLow.Add(i);
            _symbols["lettersLow"] = lettersLow;

            for (var i = '0'; i <= '9'; i++)
                numbers.Add(i);
            _symbols["numbers"] = numbers;

            for (var i = '!'; i <= '/'; i++)
                special.Add(i);
            for (var i = ':'; i <= '@'; i++)
                special.Add(i);
            for (var i = '['; i <= '`'; i++)
                special.Add(i);
            for (var i = '{'; i <= '~'; i++)
                special.Add(i);
            _symbols["special"] = special;
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignInPage());
        }

        private void GuestButton_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow((User)DBManager.GetUsers().Where(x => x.Role_Id == 1)).Show();
            Window ownerWindow = Window.GetWindow(this);
            ownerWindow.Close();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (CheckLogin() && CheckPassword())
            {
                _user = new User();
                _user.Login = login.ToLower().Trim();
                _user.Password = password.Trim();
                _user.Role_Id = 1;
                DBManager.AddUser(_user);
                DBManager.UpdateDatabase();
                NavigationService.Navigate(new SignInPage());
            }
        }

        public bool CheckLogin()
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            foreach (var user in _users)
            {
                if (user.Login == login.ToLower().Trim())
                {
                    MessageBox.Show("Такой логин уже занят!", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }

            if (!_symbols["lettersLow"].Contains(login.ToLower()[0]))
            {
                MessageBox.Show("Логин должен начинаться с буквы!", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (login.Trim().Length < 6)
            {
                MessageBox.Show("Логин должен состоять минимум из 6 символов!", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        public bool CheckPassword()
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;
            string passwordConfirm = ConfirmPasswordBox.Password;

            bool hasUpperCase = password.Any(c => _symbols["lettersUpper"].Contains(c));
            bool hasNumber = password.Any(c => _symbols["numbers"].Contains(c));
            bool hasSpecial = password.Any(c => _symbols["special"].Contains(c));

            if (password.Trim().Length < 6)
            {
                MessageBox.Show("Пароль должен состоять минимум из 6 символов!", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (!hasUpperCase)
            {
                MessageBox.Show("Пароль должен содержать минимум 1 букву верхнего регистра!", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (!hasNumber)
            {
                MessageBox.Show("Пароль должен содержать минимум 1 цифру!", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (!hasSpecial)
            {
                MessageBox.Show("Пароль должен содержать минимум 1 спецсимвол!", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (password.Trim() != passwordConfirm.Trim())
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
    }
}
