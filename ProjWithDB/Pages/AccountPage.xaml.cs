using ProjWithDB.Windows;
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

namespace ProjWithDB.Pages
{
    public partial class AccountPage : Page
    {
        private User _user;
        public AccountPage(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            _user = null;
            new AuthorizationWindow().Show();
            Window.GetWindow(this).Close();
        }
    }
}
