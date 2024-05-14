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
        private List<Meme> _memes;
        private List<MemeType> _memeTypes;
        private List<SortType> _sortTypes;

        public MainWindow()
        {
            InitializeComponent();

            _memes = Data.DataContext.Memes;
            _memeTypes = Data.DataContext.MemeTypes;
            _sortTypes = Data.DataContext.SortTypes;

            LstView.ItemsSource = _memes;
            FilterCB.ItemsSource = _memeTypes;
            SortCB.ItemsSource = _sortTypes;
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            Meme selectedMeme = (Meme)LstView.SelectedItem;
            _memes.Remove(selectedMeme);

            LstView.ItemsSource = _memes;
            LstView.Items.Refresh();
        }

        private void ViewMI_Click(object sender, RoutedEventArgs e)
        {
            Meme selectedMeme = (Meme)LstView.SelectedItem;
            MessageBox.Show($"Id:{selectedMeme.Id} \nTitle: {selectedMeme.Title}\nType: {selectedMeme.MemeType.Title}\nPrice: {selectedMeme.Price}$", "Soon!");
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            LstView.ItemsSource = _memes;
            LstView.Items.Refresh();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tempLst = _memes;

            if(!String.IsNullOrEmpty(SearchTB.Text))
            {
                tempLst = _memes.Where(x => x.Title.Contains(SearchTB.Text)).ToList();
            }

            LstView.ItemsSource = tempLst;
            LstView.Items.Refresh();
        }

        private void FilterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var filter = _memes;

            var type = (MemeType)FilterCB.SelectedItem;

            if (type == null)
                return;

            if (type.Title != "Отображение по умолчанию")
            {
                filter = filter.Where(x => x.MemeType.Id == type.Id).ToList();
            } 
            else
            {
                filter = _memes;
            }


            LstView.ItemsSource = filter;
            LstView.Items.Refresh();
        }

        private void FilterCB_DropDownClosed(object sender, EventArgs e)
        {
            //var filter = _memes;

            //var type = (MemeType)FilterCB.SelectedItem;

            ////if (type == null)
            ////    return;

            //filter = filter.Where(x => x.MemeType.Id == type.Id).ToList();
            //LstView.ItemsSource = filter;               
            //LstView.Items.Refresh();

        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sortList = new List<Meme>();

            var type = (SortType)SortCB.SelectedItem;

            if (type == null) return;

            if (type.SortTitle == "По умолчанию")
            {
                sortList = _memes;
            }
            else if (type.SortTitle == "От A до Z")
            {
                sortList = _memes.OrderBy(x => x.Title).ToList();
            }
            else if (type.SortTitle == "От Z до A")
            {
                sortList = _memes.OrderByDescending(x => x.Title).ToList();
            }
            else if (type.SortTitle == "По возрастанию цены")
            {
                sortList = _memes.OrderBy(x => x.Price).ToList();
            }
            else if (type.SortTitle == "По убыванию цены")
            {
                sortList = _memes.OrderByDescending(x => x.Price).ToList();
            }

            LstView.ItemsSource = sortList;
            LstView.Items.Refresh();
        }
    }
}
