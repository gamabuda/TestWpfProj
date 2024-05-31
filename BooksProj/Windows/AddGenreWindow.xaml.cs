using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BooksProj.Data;

namespace BooksProj.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddGenreWindow.xaml
    /// </summary>
    public partial class AddGenreWindow : Window
    {
        public AddGenreWindow()
        {
            InitializeComponent();
        }

        private void CancelBTN(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SubmitBTN(object sender, RoutedEventArgs e)
        {
            string adding = AddGenreTB.Text;

            bool isru = !Regex.IsMatch(adding, @"^a-zA-Z$");

            if (DBManager.GetGenres().Exists(x => x.Title.ToLower() == adding.ToLower()))
            {
                MessageBox.Show("Такой жанр существует", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            } 

            if (isru)
            {
                Genre newGenre = new Genre();

                newGenre.ID_User = Convert.ToInt32(DBManager.GetUsers().Count());
                newGenre.Title = adding.Trim();

                DBManager.AddGenre(newGenre);
                DBManager.UpdateDatabase();
            }
            else
            {
                MessageBox.Show("Некорректные данные", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
