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

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(LoginTb.Text) || String.IsNullOrEmpty(PasswordPb.Password))
            {
                MessageBox.Show("Please fill all fields!");
                return;
            }

            // reg or auth choose what u want
            if (Reg(LoginTb.Text, PasswordPb.Password))
            //if (Auth(LoginTb.Text, PasswordPb.Password))
            {
                new MainWindow().Show();
                this.Close();
            }
            else
                MessageBox.Show("This data is not correct!");
        }

        private bool Auth(string login, string password)
        {
            var user = DataBaseManager.GetUsers().
                FirstOrDefault(x => x.Login == login && x.Password == password);

            if(user != null)
                return true;
            else 
                return false;
        }

        private bool Reg(string login, string password)
        {
            var newUser = new User();
            newUser.Login = LoginTb.Text;
            newUser.Password = PasswordPb.Password;
            newUser.RoleId = 2;
            newUser.Name = "Unkown";
            newUser.Surname = "Unkown";
            
            DataBaseManager.AddUser(newUser);
            DataBaseManager.UpdateDatabase();
            return true;
        }
    }
}
