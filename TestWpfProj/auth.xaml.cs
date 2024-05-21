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

namespace TestWpfProj
{
    /// <summary>
    /// Логика взаимодействия для auth.xaml
    /// </summary>
    public partial class auth : Window
    {
        public auth()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            
            string username = UsernameTextBox.Text;
            string Password = PasswordTextBox.Text;
            if (username == "admin" && Password == "12345678")
            {
                MessageBox.Show("Login successful!");
                this.Close();
                MainWindow mainWindow = new MainWindow();
                mainWindow.SetLoggedIn(true);
            }
            else
            {
                MessageBox.Show("Invalid username or password!");
            }
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Открытие окна регистрации
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
        }
    }
}
