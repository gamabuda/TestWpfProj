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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace EchoCraze.Pages
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        public Reg()
        {
            InitializeComponent();
        }
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        User User = new User();
        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(LoginTB.Text) || !String.IsNullOrEmpty(PasswordTB.Text))
            {
                if (!char.IsDigit(UserContext.AuthUser.Login[0]) && UserContext.AuthUser.Login.Length > 6)
                {
                    foreach (char B in UserContext.AuthUser.Password)
                    {
                        if (char.IsUpper(B) && UserContext.AuthUser.Password.Length > 6)
                        {

                            UserContext.AuthUser = User;
                            if (Basedb.AddUser(User))
                            {

                                Basedb.AddUser(User);
                                new Auth(User).Show();

                            }

                        }

                    }
                }
            }
        }
    }
}
