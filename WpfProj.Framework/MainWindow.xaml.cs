using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
using WpfProj.Framework.Data;
using System.IO;
using WpfProj.Framework;
using System.Data.Entity;
using System.Data.Entity.Validation;
using WpfProj.Framework.DbConnection;
using WpfProj.Framework.MainPages;

namespace TestWpfProj.Framework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<Film> _films;
        public MainWindow()
        {
            InitializeComponent();

            _films = DataBaseManager.GetMemes();



            MainFrame.NavigationService.Navigate(new MainPage());
        }

        // навигация
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new MainPage());
        }

        private void FilmGanrPageBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new FilmGanrPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Profile());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (MainFrame.NavigationService.CanGoBack)
                MainFrame.NavigationService.GoBack();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (MainFrame.NavigationService.CanGoForward)
                MainFrame.NavigationService.GoForward();
        }
    }
}
