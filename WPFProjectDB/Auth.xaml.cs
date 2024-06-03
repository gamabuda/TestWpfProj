﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPFProjectDB;
using WPFProjectDB.Data;
using WPFProjectDB.DataBaseConnection;
using WPFProjectDB.Windows;

namespace TestWpfProj.Windows
{
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }
        Users CurrentUser;
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(LoginTextBox.Text) || String.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Please fill all fields!");
                return;
            }

            if (Authentication(LoginTextBox.Text, PasswordBox.Password))
            {
                new MainWindow(CurrentUser).Show();
                this.Close();
            }
            else
                MessageBox.Show("This data is not correct!");
        }

        private bool Authentication(string login, string password)
        {
            var user = DataBaseManager.GetUsers().
                FirstOrDefault(x => x.Login == login && x.Password == password);

            if (user != null)
            {
                CurrentUser = user;
                return true;
            }
            else
                return false;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void ContinueAsAGuest_Click(object sender, RoutedEventArgs e)
        {

            var user = DataBaseManager.GetUsers().
                FirstOrDefault(x => x.Login == "Guest" && x.Password == "Guest");

            if (user != null)
            {
                CurrentUser = user;
                new MainWindow(CurrentUser).Show();
                this.Close();
            }
            else
                MessageBox.Show("The occured exeption with auth with Guest account");
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            new SignIn().Show();
        }
    }
}