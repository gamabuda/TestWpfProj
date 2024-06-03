using System.Text.RegularExpressions;
using System.Windows;
using WPFProjectDB.DataBaseConnection;
using WPFProjectDB.Data;
using System.Windows.Controls;

namespace WPFProjectDB.Windows
{
    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;
            string username = UsernameTextBox.Text;

            string validationError = ValidateInput(login, password, username);
            if (validationError != null)
            {
                ErrorTextBlock.Text = validationError;
                return;
            }

            Users newUser = new Users
            {
                Login = login,
                Password = password,
                Username = username,
                Role_id = null
            };

            bool result = DataBaseManager.AddUser(newUser);

            if (result)
            {
                this.Close();
            }
            else
            {
                ErrorTextBlock.Text = "Error saving user to database.";
            }
        }

        private string ValidateInput(string login, string password, string username)
        {
            if (string.IsNullOrWhiteSpace(login))
                return "Login cannot be empty.";
            if (string.IsNullOrWhiteSpace(password))
                return "Password cannot be empty.";
            if (password.Length < 8)
                return "Password must be at least 8 characters long.";
            if (char.IsDigit(password[0]))
                return "Password cannot start with a number.";
            if (!Regex.IsMatch(password, @"[A-Z]"))
                return "Password must contain at least one uppercase letter.";
            if (!Regex.IsMatch(password, @"[a-z]"))
                return "Password must contain at least one lowercase letter.";
            if (!Regex.IsMatch(password, @"[0-9]"))
                return "Password must contain at least one number.";

            return null;
        }
    }
}
