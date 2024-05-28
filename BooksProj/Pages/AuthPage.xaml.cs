using BooksProj.DbConnection;
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
        public AuthPage(Window w)
        {
            _w = w;

            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;
            string password = Password.Password;

            var user = DBManager.GetUsers().FirstOrDefault(x => x.Login == login && x.Password == password);

            if (user != null) 
            {
                CurrentUser.currentUser = user;

                new MainWindow(_w).Show();
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
