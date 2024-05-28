using BooksProj.Data;
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
using BooksProj.Windows;

namespace BooksProj.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();

            this.DataContext = CurrentUser.currentUser;
        }

        private void ProfileEditBTN(object sender, RoutedEventArgs e)
        {
            EditProfileWindow editProfile = new EditProfileWindow();
            editProfile.ShowDialog();
        }
    }
}
