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
using System.Windows.Shapes;
using BooksProj.Data;
using BooksProj.DbConnection;

namespace BooksProj.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditProfileWindow.xaml
    /// </summary>
    public partial class EditProfileWindow : Window
    {
        private User _user;
        public EditProfileWindow()
        {
            InitializeComponent();

            var user = CurrentUser.currentUser;
            _user = user;

            oldLogin.Text = user.Login;

            this.DataContext = user;
        }

        private void SaveChangesBTN(object sender, RoutedEventArgs e)
        {
            string newLogin = oldLogin.Text.ToString();
            string newPass = oldPass.Text.ToString();
            string newPassRep = repPass.Text.ToString();

            if (newLogin == null || newPass == null || newPassRep == null)
                return;

            TimeSpan regexTimeout = TimeSpan.FromMilliseconds(100);

            if (DBManager.GetUsers().Exists(x => x.Login == newLogin))
            {
                MessageBox.Show("Аккаунт с таким именем уже существует.", "Ошибка переименовывания.", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (newPass != newPassRep)
            {
                MessageBox.Show("Пароли не совпадают.", "Ошибка создания.", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            bool nums = Regex.IsMatch(newPass, @"\d", RegexOptions.None, regexTimeout);
            bool spec = Regex.IsMatch(newPass, @"[\W_]", RegexOptions.None, regexTimeout);
            bool len = newPass.Length > 7;

            bool lett = Regex.IsMatch(newLogin.Substring(0, 1), @"^[a-zA-Z]", RegexOptions.None, regexTimeout);
            bool validchar = !Regex.IsMatch(newLogin, @"[\W_]", RegexOptions.None, regexTimeout);

            if (nums && spec && len && lett && validchar)
            {
                _user.Login = newLogin;
                _user.Password = newPass;

                DBManager.UpdateDatabase();
                Close();
            }
            else
            {
                MessageBox.Show("Пароль должен содержать любую цифру, любой спец символ и быть длиннее 7 символов " +
                    "\nИмя пользователя не должно содержать спецсимволов и его первый символ не должен быть числом",
                    "Некорректные данные", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CancelChangesBTN(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
