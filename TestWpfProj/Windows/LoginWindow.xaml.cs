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
using TestWpfProj.Data;

namespace TestWpfProj.Windows
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTB.Text;
            string password = PasswordPB.Password;

            var user = Data.DataContext.Users.FirstOrDefault(u => u.Login == username && u.Password == password);

            if (user == null)
            {
                MessageBox.Show("Неправильный юзернейм или пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            UserContext.User = user;
            MainWindow mainWindow = new MainWindow(user);
            mainWindow.Show();
            this.Close();
        }
    }
}