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
        public MainWindow()
        {
            InitializeComponent();

            _films = Data.DataContext.Films;
            _filmGanres = Data.DataContext.FilmGanres;

            LstView.ItemsSource = _films;
            FilterCB.ItemsSource = _filmGanres;
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

        private void SortCB_SelectionChanged()
        {
            //var sortA = FilmSortList.OrderBy(p => p.Title); //От А до Я
            //Console.WriteLine("");
            //foreach (var t in sortA)
            //    Console.WriteLine(t.Title);

            //var sortY = FilmSortList.OrderByDescending(p => p.Title); //От Я до А
            //Console.WriteLine("");
            //foreach (var t in sortY)
            //    Console.WriteLine(t.Title);

            //var sort1 = FilmSortList.OrderBy(p => p.Otsenka); //По возрастанию оценки
            //Console.WriteLine("");
            //foreach (var t in sort1)
            //    Console.WriteLine($"{t.Title} is Otsenka = {t.Otsenka}");

            //var sort9 = FilmSortList.OrderByDescending(p => p.Otsenka); //По убыванию оценки
            //Console.WriteLine("");
            //foreach (var t in sort9)
            //    Console.WriteLine($"{t.Title} is Otsenka = {t.Otsenka}");
        }
    }
}
