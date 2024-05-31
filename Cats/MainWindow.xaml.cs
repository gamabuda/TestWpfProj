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
        public MainPage _mainPage;
        public ProfilePage _profilePage;
        public TypesPage _typesPage;

        public MainWindow()
        {
            InitializeComponent();

            _mainPage = new MainPage();
            _profilePage = new ProfilePage();
            _typesPage = new TypesPage();

            DataContext = UserContext.AppViewModel;

            MainFrame.NavigationService.Navigate(_mainPage);

            if (UserContext.CurrentUser.ID == "GUEST")
                ProfilePageBtn.IsEnabled = false;

            Application.Current.MainWindow = this;
            if (UserContext.CurrentUser.isAdmin == false)
                CatTypesPageBtn.Visibility = Visibility.Collapsed;
        }

        private void MainPageBtn_OnClick(object sender, RoutedEventArgs e)
        {
            MainPageBtn.Style = (Style)Resources["OpenedPageBtn"];
            ProfilePageBtn.Style = (Style)Resources["ClosedPageBtn"];
            CatTypesPageBtn.Style = (Style)Resources["ClosedPageBtn"];
            MainFrame.NavigationService.Navigate(_mainPage);
        }

        private void ProfilePageBtn_Click(object sender, RoutedEventArgs e)
        {
            MainPageBtn.Style = (Style)Resources["ClosedPageBtn"];
            ProfilePageBtn.Style = (Style)Resources["OpenedPageBtn"];
            CatTypesPageBtn.Style = (Style)Resources["ClosedPageBtn"];
            MainFrame.NavigationService.Navigate(_profilePage);
        }

        private void CatTypesPageBtn_OnClick(object sender, RoutedEventArgs e)
        {
            MainPageBtn.Style = (Style)Resources["ClosedPageBtn"];
            ProfilePageBtn.Style = (Style)Resources["ClosedPageBtn"];
            CatTypesPageBtn.Style = (Style)Resources["OpenedPageBtn"];
            MainFrame.NavigationService.Navigate(_typesPage);
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            UserContext.CurrentUser = null;
            AuthorisationWindow authorisationWindow = new AuthorisationWindow();
            authorisationWindow.Show();
            Application.Current.MainWindow.Close();
        }
    }
}
