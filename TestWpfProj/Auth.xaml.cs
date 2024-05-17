using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TestWpfProj.Data;

namespace TestWpfProj.Windows
{
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            var user = UserContext.Users.FirstOrDefault(u => u.Login == login && u.Password == password);

            if (user != null)
            {
                User authenticatedUser = user;
                MessageBox.Show("Login successful!");
                Close();
                var mainWindow = new MainWindow(authenticatedUser);
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void ContinueAsAGuest_Click(object sender, RoutedEventArgs e)
        {
            User authenticatedUser = UserContext.Users[0];
            var mainWindow = new MainWindow(authenticatedUser);
            this.Close();
            mainWindow.Show();
        }
    }
}
