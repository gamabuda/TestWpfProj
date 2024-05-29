﻿using BooksProj.Data;
using BooksProj.DbConnection;
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
using BooksProj.Windows;

namespace BooksProj.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainListPage.xaml
    /// </summary>
    public partial class MainListPage : Page
    {
        private List<Book> _books;
        private List<Genre> _bookGenres;
        private List<Sorts> _sortTypes;

        public MainListPage()
        {
            var _user = CurrentUser.currentUser;

            InitializeComponent();

            _books = DBManager.GetBooks();
            _bookGenres = DBManager.GetGenres();
            _sortTypes = DBManager.GetSorts();

            LstView.ItemsSource = _books;
            FilterCB.ItemsSource = _bookGenres;
            SortCB.ItemsSource = _sortTypes;


            if (_user.ID_Role == 1)
            {
                editForAdm.Visibility = Visibility.Collapsed;
                deleteForAdm.Visibility = Visibility.Collapsed;
            }
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            Book selectedBook = (Book)LstView.SelectedItem;

            if (selectedBook != null)
            {
                MessageBoxResult conf = MessageBox.Show($"Вы уверены, что хотите удалить '{selectedBook.Title}' ?", "Подтвердить удаление.", MessageBoxButton.YesNo);

                if (conf == MessageBoxResult.Yes)
                {
                    DBManager.RemoveBook(selectedBook);

                    LstView.ItemsSource = _books;
                    LstView.Items.Refresh();
                    DBManager.UpdateDatabase();
                }
                else
                {
                    LstView.Items.Refresh();
                }
            }

        }

        private void ViewMI_Click(object sender, RoutedEventArgs e)
        {
            Book selectedBook = (Book)LstView.SelectedItem;
            ViewWindow viewWindow = new ViewWindow(selectedBook);
            viewWindow.ShowDialog();
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            Book selectedBook = (Book)LstView.SelectedItem;
            EditBookWindow editBookWindow = new EditBookWindow(selectedBook);
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

            if (!String.IsNullOrEmpty(SearchTB.Text))
            {
                tempLst = _books.Where(x => x.Title.Contains(SearchTB.Text)).ToList();
            }

            LstView.ItemsSource = tempLst;
            LstView.Items.Refresh();
        }

        private void FilterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var filter = _books;

            var type = (Genre)FilterCB.SelectedItem;

            if (type == null)
                return;

            if (type.Title != "Отображение по умолчанию")
            {
                filter = filter.Where(x => x.Genre.ID_Genre == type.ID_Genre).ToList();
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

            var type = (Sorts)SortCB.SelectedItem;

            if (type == null) return;

            if (type.Title == "По умолчанию")
            {
                sortList = _books;
            }
            else if (type.Title == "От А до Я")
            {
                sortList = _books.OrderBy(x => x.Title).ToList();
            }
            else if (type.Title == "От Я до А")
            {
                sortList = _books.OrderByDescending(x => x.Title).ToList();
            }
            else if (type.Title == "По возрастанию цены")
            {
                sortList = _books.OrderBy(x => x.Price).ToList();
            }
            else if (type.Title == "По убыванию цены")
            {
                sortList = _books.OrderByDescending(x => x.Price).ToList();
            }
            else if (type.Title == "По автору")
            {
                sortList = _books.OrderBy(x => x.Writer).ToList();
            }


            LstView.ItemsSource = sortList;
            LstView.Items.Refresh();
        }
    }
}
