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
using TestWpfProj.Data;

namespace TestWpfProj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Film> _films;
        private List<FilmGanr> _filmGanres;
        private List<Film> _listView;
        private List<string> _sortItems = new List<string>() { "From A to Z", "From Z to A", "↑ Otsenka", "↓ Otsenka" };
        public MainWindow()
        {
            InitializeComponent();

            _films = Data.DataContext.Films;
            _filmGanres = Data.DataContext.FilmGanres;
            _listView = _films;

            LstView.ItemsSource = _listView;
            FilterCB.ItemsSource = _filmGanres;
            Sort.ItemsSource = _sortItems;
        }

        private void Sort_DropDownClosed(object sender, EventArgs e)
        {
            var type = Sort.SelectedItem;

            if (type == null)
                return;

            if (type == "From A to Z")
                _listView = _listView.OrderBy(x => x.Title).ToList();
            else if (type == "From Z to A")
                _listView = _listView.OrderByDescending(x => x.Title).ToList();
            else if (type == "↑ Otsenka")
                _listView = _listView.OrderBy(x => x.Otsenka).ToList();
            else if (type == "↓ Otsenka")
                _listView = _listView.OrderByDescending(x => x.Otsenka).ToList();

            Sort.SelectedItem = null;
            LstView.ItemsSource = _listView;
            LstView.Items.Refresh();
        }

        private void ClearFiltrBtn_Click(object sender, RoutedEventArgs e)
        {
            Sort.SelectedItem = null;

            _listView = _films;
            LstView.ItemsSource = _listView;
            LstView.Items.Refresh();
        }

        private void ClearSortBtn_Click(object sender, RoutedEventArgs e)
        {
            Sort.SelectedItem = null;

            _listView = _films;
            LstView.ItemsSource = _listView;
            LstView.Items.Refresh();
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            Film selectedMeme = (Film)LstView.SelectedItem;
            _films.Remove(selectedMeme);

            LstView.ItemsSource = _films;
            LstView.Items.Refresh();
        }

        private void ViewMI_Click(object sender, RoutedEventArgs e)
        {
            Film selectedFilm = (Film)LstView.SelectedItem;
            MessageBox.Show($"Id: {selectedFilm.Id} \nTitle: {selectedFilm.Title} \nGanr: {selectedFilm.FilmGanr.Title} \nData: {selectedFilm.Data} \nOtsenka: {selectedFilm.Otsenka} \nPicture: {selectedFilm.Picture}", "Soon!");
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            LstView.ItemsSource = _films;
            LstView.Items.Refresh();
        }

        private void SerchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tempLst = _films;

            if (!String.IsNullOrEmpty(SerchTB.Text))
            {
                tempLst = _films.Where(x => x.Title.Contains(SerchTB.Text)).ToList();
            }

            LstView.ItemsSource = tempLst;
            LstView.Items.Refresh();
        }

        private void FilterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var filter = _films;

            var type = (FilmGanr)FilterCB.SelectedItem;

            if (type == null)
                return;

            filter = filter.Where(x => x.FilmGanr.Id == type.Id).ToList();
            LstView.ItemsSource = filter;
            LstView.Items.Refresh();
        }

        private void FilterCB_DropDownClosed(object sender, EventArgs e)
        {

        }
    }
}
