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
using ProjWithDB.Data.Users;

namespace ProjWithDB.Pages
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
            new MainWindow((User)ChildrenHomeEntities.GetContext().User.Where(x => x == x.Guest)).Show();
            Window ownerWindow = Window.GetWindow(this);
            ownerWindow.Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Password;
            if (PasswordTextBox.Password == ConfirmPasswordTextBox.Password && ChildrenHomeEntities.GetContext().User.Where(x => x.Login == login && x.Password == password) == null)
            {
                _user = new User();
                new MainWindow(_user).Show();
                Window ownerWindow = Window.GetWindow(this);
                ownerWindow.Close();
            }
            else
                MessageBox.Show("Некорректные данные!", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
