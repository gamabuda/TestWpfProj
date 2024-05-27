using MemeWpfApp.Data;
using MemeWpfApp.DbConnection;
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
using MemeWpfApp.MainPages;

namespace MemeWpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Meme> _memes;
        public MainWindow()
        {
            InitializeComponent();

            _memes = DataBaseManager.GetMemes();

            // проверка по роли
            if(UserContext.AuthUser.RoleId == 1)
                TypeMemePageBtn.Visibility = Visibility.Visible; 
            else
                TypeMemePageBtn.Visibility = Visibility.Collapsed;

            MainFrame.NavigationService.Navigate(new MainPage());
        }

        // навигация
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new MainPage());
        }

        private void TypeMemePageBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new MemeTypePage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Profile());
        }
    }
}
