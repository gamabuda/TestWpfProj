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
using TestWpfProj.Pages;

namespace TestWpfProj.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();

            AuthFrame.NavigationService.Navigate(new AuthPage(this));
        }


        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            // авторизация 1
            var user = Data.DataContext.Users.Last();
            // авторизация 2
            Data.UserContext.User = user;

            if (Data.UserContext.User != null)
            {
                new MainWindow(user).Show();
                this.Close();
                return;
            }

            new MainWindow(user).Show();
            this.Close();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AuthFrame.NavigationService.Navigate(new AuthPage(this));
        }

        private void Label_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            AuthFrame.NavigationService.Navigate(new RegPage());
        }
    }
}
