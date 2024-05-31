using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using ProjWithDB.Windows;
using System.Data.Entity.Infrastructure;
using ProjWithDB.Data;
using ProjWithDB.Pages;
using System.IO;

namespace ProjWithDB
{
    public partial class MainWindow : Window
    {

        private User _user;
        public MainWindow(User user)
        {
            InitializeComponent();
            _user = user;
            MainFrame.Navigate(new MainPage());
            DBManager.UpdateDatabase();
            if (_user.Role_Id == 1)
                UsersPageNavigateBtn.Visibility = Visibility.Collapsed;

            // ДОБАВЛЕНИЕ ФОТО ДЕТЕЙ
            //foreach (var p in DBManager.GetChild())
            //{
            //    if (p.Gender.ToString() == "М")
            //        p.Photo = File2Byte(@"../../img/icons/boyIcon.png");
            //    else
            //        p.Photo = File2Byte(@"../../img/icons/girlIcon.png");
            //}

            // УДАЛЕНИЕ ФОТО ДЕТЕЙ
            //foreach (var p in DBManager.GetChild())
            //{
            //        p.Photo = null;
            //}

            // ДОБАВЛЕНИЕ ФОТО ПОЛЬЗОВАТЕЛЕЙ
            //foreach (var p in DBManager.GetUsers())
            //{
            //    p.Photo = File2Byte(@"../../img/icons/userNeon.png");
            //}
        }
        public Byte[] File2Byte(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                return File.ReadAllBytes(filePath);

            return null;
        }

        private void MainPageNavigateBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainPage());
        }

        private void ChildrenListPageNavigateBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ChildrenListPage(_user));
        }

        private void UsersPageNavigateBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new UsersPage(_user));
        }

        private void AccountPageNavigateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_user.Role_Id == 1)
                MainFrame.Navigate(new GuestAccountPage());
            else
                MainFrame.Navigate(new AccountPage(_user));
        }
    }
}
