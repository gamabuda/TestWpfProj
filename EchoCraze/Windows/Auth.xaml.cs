using EchoCraze.Base;
using EchoCraze;
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

namespace EchoCraze.Windows
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        private List<User> users = new List<User>();
        public Auth()
        {
            InitializeComponent();
            users = Base.Basedb.GetUsers();
        }
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        User User = new User();
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var user = Base.Basedb.GetUsers();
            if (UserContext.AuthUser.Login != null && UserContext.AuthUser.Password != null)
                return; 
            
            UserContext.AuthUser = user.FirstOrDefault(x => x.Login == LoginTB.Text && x.Password == PasswordTB.Password);
            
            if (UserContext.AuthUser != null)
            {
                new MainWindow(user.FirstOrDefault()).Show();
                return;
            }

            new MainWindow(user.FirstOrDefault()).Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Reg().Show();
        }
    }
}

