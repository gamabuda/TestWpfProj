using BooksProj.DbConnection;
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
using BooksProj.Data;

namespace BooksProj.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPAge.xaml
    /// </summary>
    public partial class RegPage : Page
    {
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

            TimeSpan regexTimeout = TimeSpan.FromMilliseconds(100);

            if (DBManager.GetUsers().Exists(x => x.Login == login))
            {
                MessageBox.Show("Аккаунт с таким именем уже существует.", "Ошибка создания.", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (password != PasswordConfirmation.Password)
            {
                MessageBox.Show("Пароли не совпадают.", "Ошибка создания.", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            bool nums = Regex.IsMatch(password.Trim(), @"\d", RegexOptions.None, regexTimeout);
            bool spec = Regex.IsMatch(password.Trim(), @"[\W_]", RegexOptions.None, regexTimeout);
            bool len = password.Trim().Length > 7;

            bool lett = Regex.IsMatch(login.Trim().Substring(0, 1), @"^[a-zA-Z]", RegexOptions.None, regexTimeout);
            bool validchar = !Regex.IsMatch(login.Trim(), @"[\W_]", RegexOptions.None, regexTimeout);

            if (nums && spec && len && lett && validchar)
            {
                User newUser = new User();

                newUser.ID_User = Convert.ToInt32(DBManager.GetUsers().Count()) + 1;
                newUser.Login = login.Trim();
                newUser.Password = password.Trim();
                newUser.ID_Role = 1;

                DBManager.AddUser(newUser);
                DBManager.UpdateDatabase();

                CurrentUser.currentUser = newUser;

                new MainWindow().Show();
                Window w = Window.GetWindow(this);
                w.Close();
            }
            else
            {
                MessageBox.Show("Пароль должен содержать любую цифру, любой спец символ и быть длиннее 7 символов.\n" +
                    "Имя пользователя должно начинаться с буквы и не содержать спецсимволов.",
                    "Некорректные данные", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
