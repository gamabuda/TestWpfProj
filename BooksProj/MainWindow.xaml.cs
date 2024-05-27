using BooksProj.DbConnections;
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

namespace BooksProj
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Window _w;
        public MainWindow(User user, Window w)
        {
            InitializeComponent();

            _w = w;

            MainFrame.NavigationService.Navigate(new MainListPage(this));

            MessageBox.Show($"Добро пожаловать, {user.Login}!");
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

        }

        private void GenresBTN(object sender, RoutedEventArgs e)
        {

        }

        private void TableBTN(object sender, RoutedEventArgs e)
        {

        }
    }
}
