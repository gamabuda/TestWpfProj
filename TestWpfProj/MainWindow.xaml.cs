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
        private string _selectedSortOption;

        public MainWindow(User user)
        {
            InitializeComponent();

            _memeTypes = Data.DataContext.MemeTypes;

            // Инициализация списка Meme
            _memes = Data.DataContext.Memes;
            foreach (var meme in _memes)
            {
                meme.Price = meme.Title.Length * 2;
            }
            _selectedSortOption = "Sort A-Z";
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

            if (!String.IsNullOrEmpty(SerchTB.Text))
            {
                tempLst = _memes.Where(x => x.Title.Contains(SerchTB.Text) || x.Id.StartsWith(SerchTB.Text)).ToList();
            }

            LstView.ItemsSource = tempLst;
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
        private void FilterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedType = (MemeType)FilterCB.SelectedItem;
            ApplyFilterAndSort(_memes, selectedType, _selectedSortOption);
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedSortOption = (ComboBoxItem)SortCB.SelectedItem;
            _selectedSortOption = selectedSortOption.Content.ToString();
            ApplyFilterAndSort(_memes, (MemeType)FilterCB.SelectedItem, _selectedSortOption);
        }
        private void ApplyFilterAndSort(List<Meme> memes, MemeType selectedType, string sortOption)
        {
            var filteredMemes = memes;

            if (selectedType != null)
                filteredMemes = filteredMemes.Where(x => x.MemeType.Id == selectedType.Id).ToList();

            switch (sortOption)
            {
                case "Sort A-Z":
                    filteredMemes = filteredMemes.OrderBy(x => x.Title).ToList();
                    break;
                case "Sort Z-A":
                    filteredMemes = filteredMemes.OrderByDescending(x => x.Title).ToList();
                    break;
                case "Sort Price Asc":
                    filteredMemes = filteredMemes.OrderBy(x => x.Price).ToList();
                    break;
                case "Sort Price Desc":
                    filteredMemes = filteredMemes.OrderByDescending(x => x.Price).ToList();
                    break;
            }

            LstView.ItemsSource = filteredMemes;
            LstView.Items.Refresh();
        }
        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            // Сброс фильтрации и сортировки
            _selectedSortOption = "Sort A-Z";
            LstView.ItemsSource = _memes;
            LstView.Items.Refresh();
            FilterCB.SelectedItem = null; // Сброс выбора фильтра
        }
    }
}
