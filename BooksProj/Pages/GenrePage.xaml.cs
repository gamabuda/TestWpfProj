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
using BooksProj.Data;
using BooksProj.DbConnection;
using BooksProj.Windows;

namespace BooksProj.Pages
{
    /// <summary>
    /// Логика взаимодействия для GenrePage.xaml
    /// </summary>
    public partial class GenrePage : Page
    {
        private List<BookGenres> _bookGenres;
        public GenrePage()
        {
            InitializeComponent();

            _bookGenres = DBManager.GetGenres();

            var _notGenre = _bookGenres.ElementAt(0);

            _bookGenres.Remove(_notGenre);
            LstView.ItemsSource = _bookGenres; 
        }

        private void AddGenreBTN(object sender, RoutedEventArgs e)
        {
            AddGenreWindow addGenre = new AddGenreWindow();
            addGenre.ShowDialog();
        }
    }
}
