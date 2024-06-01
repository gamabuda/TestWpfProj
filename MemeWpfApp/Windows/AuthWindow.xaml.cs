using MemeWpfApp.Data;
using MemeWpfApp.DbConnection;
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
using System.Windows.Shapes;

namespace MemeWpfApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = DataBaseManager.GetUsers().FirstOrDefault(x => x.Login == NameTextBox.Text && x.Password == PasswordBox.Password);

            if (user == null)
                return;

            UserContext.AuthUser = user;

            new MainWindow().Show();

            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var user = new User()
            {
                Login = NameTextRegBox.Text,
                Password = PasswordRegBox.Password,
                Role = false
            };

            DataBaseManager.AddUser(user);
            DataBaseManager.UpdateDatabase();

            UserContext.AuthUser = user;

            new MainWindow().Show();

            this.Close();
        }
    }
}
