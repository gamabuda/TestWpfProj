using MemeWpfApp.Data;
using MemeWpfApp.DbConnection;
using MemeWpfApp.Pages;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace MemeWpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Page[] page = new Page[] { new HomeItemPage(), new UserPage() };
        public MainWindow()
        {
            InitializeComponent();

            MainFrame.NavigationService.Navigate(page[0]);
        }

        private void SignOut_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void MainMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(page[0]);
        }

        private void ProfileMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(page[1]);
        }
    }
}
