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
using GameWpfApp.Windows;
using GameWpfApp.DbConnection;

namespace GameWpfApp.AuthPages
{
    /// <summary>
    /// Interaction logic for AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }
        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginTb.Text) || string.IsNullOrEmpty(PasswordPb.Password))
            {
                MessageBox.Show("Please fill all fields!");
                return;
            }

            if (Auth(LoginTb.Text, PasswordPb.Password))
            {
                new MainWindow().Show();
                Window.GetWindow(this)?.Close();
            }
            else
            {
                MessageBox.Show("This data is not correct!");
            }
        }

        private bool Auth(string login, string password)
        {
            var user = DataBaseManager.GetUsers()
                .FirstOrDefault(x => x.Login == login && x.Password == password);

            if (user != null)
            {
                UserContext.AuthUser = user;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterPage());
        }
    }
}