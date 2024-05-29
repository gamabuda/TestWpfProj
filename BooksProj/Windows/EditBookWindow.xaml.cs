﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BooksProj.DbConnection;

namespace BooksProj.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditMemeWindow.xaml
    /// </summary>
    public partial class EditBookWindow : Window
    {
        private Book _editBook;
        public EditBookWindow(Book book)
        {
            InitializeComponent();

            this.DataContext = _editBook = book;

            Type.Text = book.Genre.Title;
            Title.Text = book.Title;
            Price.Text = book.Price.ToString();
            Writer.Text = book.Writer;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!(String.IsNullOrEmpty(Type.Text) || String.IsNullOrEmpty(Title.Text) || String.IsNullOrEmpty(Price.Text) || String.IsNullOrEmpty(Writer.Text)))
            {
                _editBook.Genre.Title = Type.Text;
                _editBook.Title = Title.Text;
                _editBook.Price = Convert.ToInt32(Price.Text);
                _editBook.Writer = Writer.Text;


                Close();
            }
            else
            {
                MessageBox.Show("Некорректная информация.");
            }
        }
    }
}
