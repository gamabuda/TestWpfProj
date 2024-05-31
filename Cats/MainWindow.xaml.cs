using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Cats.Core;
using Cats.Pages;
using Cats.Service;
using Cats.Windows;

namespace Cats
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainPage _mainPage;
        private ProfilePage _profilePage;

        public MainWindow()
        {
            InitializeComponent();

            _mainPage = new MainPage();
            _profilePage = new ProfilePage();

            MainFrame.NavigationService.Navigate(_mainPage);

            if (UserContext.CurrentUser.ID == "GUEST")
                ProfilePageBtn.IsEnabled = false;

            Application.Current.MainWindow = this;
        }

        private void MainPageBtn_OnClick(object sender, RoutedEventArgs e)
        {
            MainPageBtn.Style = (Style)Resources["OpenedPageBtn"];
            ProfilePageBtn.Style = (Style)Resources["ClosedPageBtn"];
            MainFrame.NavigationService.Navigate(_mainPage);
        }

        private void ProfilePageBtn_Click(object sender, RoutedEventArgs e)
        {
            MainPageBtn.Style = (Style)Resources["ClosedPageBtn"];
            ProfilePageBtn.Style = (Style)Resources["OpenedPageBtn"];
            MainFrame.NavigationService.Navigate(_profilePage);
        }
    }
}
