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
using GameWpfApp.Data;
using GameWpfApp.DbConnection;
using GameWpfApp.MainPages;

namespace GameWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Game> _games;
        public MainWindow()
        {
            InitializeComponent();

            _games = DataBaseManager.GetGames();

            // проверка по роли
            if (UserContext.AuthUser.RoleId == 1)
                TypeGamePageBtn.Visibility = Visibility.Visible;
            else
                TypeGamePageBtn.Visibility = Visibility.Collapsed;

            MainFrame.NavigationService.Navigate(new MainPage());
        }

        // навигация
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new MainPage());
        }

        private void TypeGamePageBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new GameTypePage());
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