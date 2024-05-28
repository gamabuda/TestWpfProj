using BooksProj.DbConnection;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using BooksProj.Data;
using BooksProj.Pages;
using System.Runtime.CompilerServices;

namespace BooksProj
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Window _w;
        public MainWindow(Window w)
        {
            InitializeComponent();

            var _user = CurrentUser.currentUser;
            _w = w;

            MainFrame.NavigationService.Navigate(new MainListPage());

            MessageBox.Show($"Добро пожаловать, {_user.Login}!");

            if (_user.ID_Role == 1)
            {
                genresBTN.Visibility = Visibility.Collapsed;
            }
        }

        private void MenuBTN(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите выйти из аккаунта?", "Подтвердить выход", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                new AuthWindow().Show();
                Window w = Window.GetWindow(this);
                w.Close();
            }
            else
            {
                return;
            }

        }

        private void ProfileBTN(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new ProfilePage());
        }

        private void GenresBTN(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new GenrePage());
        }

        private void TableBTN(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new MainListPage());
        }
    }
}
