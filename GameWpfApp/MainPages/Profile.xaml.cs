using GameWpfApp.Windows;
using Microsoft.Win32;
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
using GameWpfApp.DbConnection;
using GameWpfApp.Data;

namespace GameWpfApp.MainPages
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        private User _currentUser;

        public Profile()
        {
            InitializeComponent();
            LoadUserData();
            try
            {
                SetCustomCursor(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        private void SetCustomCursor(FrameworkElement element)
        {
            try
            {
                string cursorFile = "Resources/Apple.cur";
                var cursorStream = Application.GetResourceStream(new Uri(cursorFile, UriKind.Relative)).Stream;
                var customCursor = new Cursor(cursorStream);
                element.Cursor = customCursor;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
                throw;
            }
        }
        private void LoadUserData()
        {
            var currentUser = UserContext.AuthUser;

            if (currentUser != null)
            {
                NameTextBox.Text = currentUser.Name;
                SurnameTextBox.Text = currentUser.Surname;
                LoginTextBox.Text = currentUser.Login;
                PasswordBox.Password = currentUser.Password;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = UserContext.AuthUser;

            if (currentUser != null)
            {
                currentUser.Name = NameTextBox.Text;
                currentUser.Surname = SurnameTextBox.Text;
                currentUser.Login = LoginTextBox.Text;
                currentUser.Password = PasswordBox.Password;

                try
                {
                    DataBaseManager.SaveChanges();
                    MessageBox.Show("Changes saved successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving changes: {ex.Message}");
                }
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            UserContext.AuthUser = null;
            var authWindow = new AuthWindow();
            authWindow.Show();
            Window.GetWindow(this)?.Close();
        }
    }
}