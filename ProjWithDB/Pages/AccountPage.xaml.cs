using Microsoft.Win32;
using ProjWithDB.Data;
using ProjWithDB.Windows;
using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class AccountPage : Page
    {
        private User _user;
        private byte[] _img = new byte[0];
        private List<User> _users = new List<User>();
        private Dictionary<string, List<char>> _symbols = new Dictionary<string, List<char>>() { };
        public AccountPage(User user)
        {
            InitializeComponent();
            _user = user;
            this.DataContext = _user;
            _users = DBManager.GetUsers();

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

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?",
                    "Выход из аккаунта",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _user = null;
                new AuthorizationWindow().Show();
                Window.GetWindow(this).Close();
            }
        }

        private void DeletePhoto_Click(object sender, RoutedEventArgs e)
        {
            _img = null;
            ObjectImg.Source = null;
        }

        private void LoadImgBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a photo";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                var img = new BitmapImage(new Uri(op.FileName));
                _img = File2Byte(op.FileName);
                ObjectImg.Source = img;
                LoadImgBtn.Background = Brushes.Lavender;
                LoadImgBtn.BorderBrush = Brushes.Transparent;
            }
        }

        public Byte[] File2Byte(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                return File.ReadAllBytes(filePath);

            return null;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(Id_TB.Text) || String.IsNullOrEmpty(Login_TB.Text) || String.IsNullOrEmpty(Password_TB.Text) || String.IsNullOrEmpty(Role_TB.Text))
                return;

            if(CheckLogin() && CheckPassword())
            {
                    _user.Login = Login_TB.Text;
                    _user.Password = Password_TB.Text;
                    var role = DBManager.GetRoles().FirstOrDefault(x => x.Title == Role_TB.Text);
                    if (role != null)
                        _user.Role_Id = role.Id;
                    else
                    {
                        var newRole = new Role() { Title = Role_TB.Text };
                        DBManager.AddRole(newRole);
                        _user.Role_Id = newRole.Id;
                    }
                    _user.Photo = _img;
                    DBManager.UpdateDatabase();
                    MessageBox.Show("Изменения успешно сохранены!", "Сохранение изменений", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public bool CheckLogin()
        {
            string login = Login_TB.Text.ToLower().Trim();
            string password = Password_TB.Text;

            if (login == _user.Login)
                return true;

            foreach (var user in _users)
            {
                if (user.Login == login)
                {
                    MessageBox.Show("Такой логин уже занят!", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }

            if (!_symbols["lettersLow"].Contains(login[0]))
            {
                MessageBox.Show("Логин должен начинаться с буквы!", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (login.Length < 6)
            {
                MessageBox.Show("Логин должен состоять минимум из 6 символов!", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        public bool CheckPassword()
        {
            string login = Login_TB.Text;
            string password = Password_TB.Text;

            if (password == _user.Password)
                return true;

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

            return true;
        }

        //private void EditBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    LoadImgBtn.IsEnabled = true;
        //    SaveBtn.IsEnabled = true;
        //    Info_SP.IsEnabled = true;
        //}
    }
}
