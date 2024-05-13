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
        public MainWindow()
        {
            InitializeComponent();

            _memes = Data.DataContext.Memes;
            _memeTypes = Data.DataContext.MemeTypes;

            LstView.ItemsSource = _memes;
            FilterCB.ItemsSource = _memeTypes;
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

        private void SerchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tempLst = _memes;

            if(!String.IsNullOrEmpty(SerchTB.Text))
            {
                tempLst = _memes.Where(x => x.Title.Contains(SerchTB.Text)).ToList();
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

            filter = filter.Where(x => x.MemeType.Id == type.Id).ToList();
            LstView.ItemsSource = filter;
            LstView.Items.Refresh();
        }

        private void FilterCB_DropDownClosed(object sender, EventArgs e)
        {
            var filter = _memes;

            var type = (MemeType)FilterCB.SelectedItem;

            if (type == null)
                return;

            filter = filter.Where(x => x.MemeType.Id == type.Id).ToList();
            LstView.ItemsSource = filter;
            LstView.Items.Refresh();
        }
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ResetFiltersAndSorting();
        }
        private void ResetSortingButton_Click(object sender, RoutedEventArgs e)
        {
            ResetSorting();
        }
        private void ResetSorting()
        {
            // Сбросить сортировку
            SortCB.SelectedIndex = -1;

            // Вернуть полный список
            LstView.ItemsSource = _memes;
        }
        private void ResetFiltersAndSorting()
        {
            // Сбросить фильтрацию
            FilterCB.SelectedIndex = -1;

            // Вернуть полный список
            LstView.ItemsSource = _memes;
        }
        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SortCB.SelectedItem == null)
            {
                return; // Ничего не делать, если ничего не выбрано
            }

            var sortType = ((ComboBoxItem)SortCB.SelectedItem).Content.ToString();

            switch (sortType)
            {
                case "По возрастанию (А-Z)":
                    _memes = _memes.OrderBy(m => m.Title).ToList();
                    break;
                case "По убыванию (Z-A)":
                    _memes = _memes.OrderByDescending(m => m.Title).ToList();
                    break;
                case "По возрастанию цены":
                    _memes = _memes.OrderBy(m => m.Price).ToList();
                    break;
                case "По убыванию цены":
                    _memes = _memes.OrderByDescending(m => m.Price).ToList();
                    break;
                default:
                    break;
            }

            LstView.ItemsSource = _memes;
        }

    }
}
