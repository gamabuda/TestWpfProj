﻿using System;
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

namespace TestWpfProj.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        private Window _w;
        public AuthPage(Window w)
        {
            _w = w;
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            // авторизация 1
            var user = Data.DataContext.Users.Last();
            // авторизация 2
            Data.UserContext.User = user;

            if (Data.UserContext.User != null)
            {
                new MainWindow(user).Show();
                _w.Close();
                return;
            }

            new MainWindow(user).Show();
            _w.Close();
        }
    }
}
