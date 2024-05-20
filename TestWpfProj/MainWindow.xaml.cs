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
using TestWpfProj.Data;
using TestWpfProj.Windows;

namespace TestWpfProj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Book> _books;
        private List<BookGenre> _bookGenres;
        private List<SortType> _sortTypes;


        public MainWindow(User user)
        {
            InitializeComponent();

            _books = Data.DataContext.Memes;
            _bookGenres = Data.DataContext.BookGenres;
            _sortTypes = Data.DataContext.SortTypes;

            LstView.ItemsSource = _books;
            FilterCB.ItemsSource = _bookGenres;
            SortCB.ItemsSource = _sortTypes;

            MessageBox.Show($"Hello, {user.Login}!");
            MessageBox.Show($"Welcome back, {UserContext.User.Login}!");
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            Book selectedBook = (Book)LstView.SelectedItem;
            _books.Remove(selectedBook);

            LstView.ItemsSource = _books;
            LstView.Items.Refresh();
        }

        private void ViewMI_Click(object sender, RoutedEventArgs e)
        {
            Book selectedBook = (Book)LstView.SelectedItem;
            ViewWindow viewWindow = new ViewWindow(selectedBook);

            viewWindow.Owner = this;
            viewWindow.ShowDialog();
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            Book selectedBook = (Book)LstView.SelectedItem;
            EditBookWindow editBookWindow = new EditBookWindow(selectedBook);

            editBookWindow.Owner = this;
            editBookWindow.ShowDialog();
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            LstView.ItemsSource = _books;
            LstView.Items.Refresh();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tempLst = _books;

            if(!String.IsNullOrEmpty(SearchTB.Text))
            {
                tempLst = _books.Where(x => x.Title.Contains(SearchTB.Text)).ToList();
            }

            LstView.ItemsSource = tempLst;
            LstView.Items.Refresh();
        }

        private void FilterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var filter = _books;

            var type = (BookGenre)FilterCB.SelectedItem;

            if (type == null)
                return;

            if (type.Title != "Отображение по умолчанию")
            {
                filter = filter.Where(x => x.BookGenre?.Id == type.Id).ToList();
            } 
            else
            {
                filter = _books;
            }


            LstView.ItemsSource = filter;
            LstView.Items.Refresh();
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sortList = new List<Book>();

            var type = (SortType)SortCB.SelectedItem;

            if (type == null) return;

            if (type.SortTitle == "По умолчанию")
            {
                sortList = _books;
            }
            else if (type.SortTitle == "От А до Я")
            {
                sortList = _books.OrderBy(x => x.Title).ToList();
            }
            else if (type.SortTitle == "От Я до А")
            {
                sortList = _books.OrderByDescending(x => x.Title).ToList();
            }
            else if (type.SortTitle == "По возрастанию цены")
            {
                sortList = _books.OrderBy(x => x.Price).ToList();
            }
            else if (type.SortTitle == "По убыванию цены")
            {
                sortList = _books.OrderByDescending(x => x.Price).ToList();
            }
            else if (type.SortTitle == "По автору")
            {
                sortList = _books.OrderBy(x => x.Writer).ToList();
            }


            LstView.ItemsSource = sortList;
            LstView.Items.Refresh();
        }
    }
}
