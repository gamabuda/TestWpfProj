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
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        public Reg()
        {
            InitializeComponent();
        }
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
       

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(LoginTB.Text) || String.IsNullOrEmpty(PasswordTB.Password))
            {
                MessageBox.Show("Please fill all fields!");
                return;
            }

            if (Registr(LoginTB.Text, PasswordTB.Password))
            {
                var newUser = Basedb.GetUsers().FirstOrDefault(user => user.Login == LoginTB.Text && user.Password == PasswordTB.Password);
                if (newUser != null)
                {
                    UserContext.AuthUser = newUser;
                    new MainWindow(newUser).Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("User not found after registration.");
                }
            }
            else
            {
                MessageBox.Show("Registration failed!");
            }

        }
        private bool Registr(string login, string password)
        {


            if (String.IsNullOrEmpty(LoginTB.Text) || String.IsNullOrEmpty(PasswordTB.Password))
            {
                return false;
            }
                if (!char.IsDigit(login[0]) && login.Length > 6)
                {
                    foreach (char B in password)
                    {
                        if (char.IsUpper(B) && password.Length > 6)
                        {
                            Random random = new Random();
                            var newUser = new User
                            {
                                Id_User = random.Next(1, 1000),
                                Login = login,
                                Password = password,
                                Id_Role = 2,
                                Name = login
                            };


                            if (Basedb.AddUser(newUser))
                            {
                                Basedb.UpdateDatabase();
                                return true;
                            }

                        }

                    }
                }
            
            return false;
        }
    }
}