using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

using TestWpfProj.Data;

namespace TestWpfProj.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        private User _user;
        private Window _w;
        public RegPage(Window w)
        {
            _w = w;

            InitializeComponent();
        }

        private void CreateAcc_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;
            string password = Password.Password;

            Regex nums = new Regex(@"\d");
            Regex spec = new Regex(@"[:graph:]");

            if (Data.DataContext.Users.Exists(x => x.Login == login))
            {
                MessageBox.Show("Аккаунт с таким именем уже существует.", "Ошибка создания.", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (Password.Password == PasswordConfirmation.Password 
                && nums.IsMatch(Password.Password)
                && Password.Password.Length > 6
                && spec.IsMatch(Password.Password)
                && nums.IsMatch(Login.Text.Substring(1))
                && !spec.IsMatch(Login.Text))
            {
                _user = new User(login, password);
                Data.DataContext.Users.Add(_user);
                new MainWindow(_user, _w).Show();
                Window w = Window.GetWindow(this);
                w.Close();
            } 
            else
            {
                MessageBox.Show("Пароль должен содержать любую цифру, любой спец символ и быть длиннее 6 символов " +
                    "\nИмя пользователя не должно содержать спецсимволов и его первый символ не должен быть числом",
                    "Некорректные данные", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
                
        }
    }
}
