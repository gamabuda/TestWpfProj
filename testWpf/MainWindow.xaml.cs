using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
using testWpf.DbConnections;

namespace testWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bookDataBaseEntities dataBase = new bookDataBaseEntities();
        public MainWindow()
        {
            InitializeComponent();

            BookLv.DataContext = this;
            BookLv.ItemsSource = dataBase.Book.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            try
            {
                if (BookGenreTb.Text == null || BookPriceTb.Text == null || BookWriterTb.Text == null || BookTitleTb.Text == null)
                {
                    MessageBox.Show("Incorrect Information", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                } 
                else
                {
                    var book = new Book()
                    {
                        ID_Book = Convert.ToInt32(r.Next()),
                        Title = BookTitleTb.Text,
                        Price = Convert.ToDecimal(BookPriceTb.Text),
                        ID_BookGenre = Convert.ToInt32(BookGenreTb.Text),
                        Writer = BookWriterTb.Text
                    };

                    dataBase.Book.Add(book);
                    dataBase.SaveChanges();
                }

                BookLv.ItemsSource = dataBase.Book.ToList();
                BookLv.Items.Refresh();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var f in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} fail validation\n", f.Entry.Entity.GetType());
                    foreach (var err in f.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", err.PropertyName, err.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException("Fail: " + sb.ToString(), ex);
            }
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedMeme = BookLv.SelectedItem as Book;
                dataBase.Book.Remove(selectedMeme);
                dataBase.SaveChanges();

                BookLv.DataContext = this;
                BookLv.ItemsSource = dataBase.Book.ToList();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var f in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} fail validation\n", f.Entry.Entity.GetType());
                    foreach (var err in f.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", err.PropertyName, err.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException("Fail: " + sb.ToString(), ex);
            }
        }
    }
}
