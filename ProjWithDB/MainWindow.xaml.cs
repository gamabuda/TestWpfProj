
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

            // ДОБАВЛЕНИЕ ФОТО ДЕТЕЙ
            //foreach (var p in DBManager.GetChild())
            //{
            //    if (p.Gender.ToString() == "М")
            //        p.Photo = File2Byte(@"../../img/people/boy.jpg");
            //    else
            //        p.Photo = File2Byte(@"../../img/people/girl.jpg");
            //}

            // УДАЛЕНИЕ ФОТО ДЕТЕЙ
            //foreach (var p in DBManager.GetChild())
            //{
            //    if (p.Gender.ToString() == "М")
            //        p.Photo = null;
            //    else
            //        p.Photo = null;
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

        private void RoomsPageNavigateBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RoomsPage());
        }

        private void AccountPageNavigateBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AccountPage(_user));
        }
    }
}
