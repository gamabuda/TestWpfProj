using BooksProj.DbConnections;
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
using BooksProj.Data;

namespace BooksProj.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        private Window _w;
        private List<User> _user;
        public AuthPage(Window w)
        {
            _w = w;
            _user = DBManager.GetUsers();

            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;
            string password = Password.Password;

            var user = new User(login, password);

            if (_user.Exists(x => x.Login == login && x.Password == password))
            {
                new MainWindow(user, _w).Show();
                Window w = Window.GetWindow(this);
                w.Close();
            }
            else
            {
                MessageBox.Show("Некорректные данные.");
            }
        }
    }
}
