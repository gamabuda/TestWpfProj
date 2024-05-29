using BooksProj.Data;
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

namespace BooksProj.Pages
{
    /// <summary>
    /// Логика взаимодействия для GenrePage.xaml
    /// </summary>
    public partial class GenrePage : Page
    {
        private List<Genre> _bookGenre;
        public GenrePage()
        {
            InitializeComponent();

            _bookGenre = DBManager.GetGenres();

            _bookGenre.Remove(_bookGenre.ElementAt(0));
            LstView.ItemsSource = _bookGenre;
        }
    }
}
