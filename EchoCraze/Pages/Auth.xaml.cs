using EchoCraze.Base;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EchoCraze.Pages;
using EchoCraze.Base;
using EchoCraze.MainPages;

namespace EchoCraze.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        private List<User> users = new List<User>();
        public Auth(User u)
        {
            users = Base.Basedb.GetUsers();
            
            InitializeComponent();
        }
       
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        User User = new User();
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var user = Base.Basedb.GetUsers();
            // авторизация 2
           UserContext.AuthUser= user.FirstOrDefault();

            if (UserContext.AuthUser != null)
            {
                new MainWindow(user.FirstOrDefault()).Show();
                return;
            }

            new MainWindow(user.FirstOrDefault()).Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
