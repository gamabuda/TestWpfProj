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
using TestWpfProj.Windows;

namespace TestWpfProj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Meme> _memes;
        private List<MemeType> _memeTypes;
        private string _searchText = string.Empty;
        private MemeType _selectedMemeType;
        private string _selectedSort;
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
        }//

        private void ViewMI_Click(object sender, RoutedEventArgs e)
        {
            Meme selectedMeme = (Meme)LstView.SelectedItem;
            MessageBox.Show($"Id:{selectedMeme.Id} \nTitle: {selectedMeme.Title}\nType: {selectedMeme.MemeType.Title}\nPrice: {selectedMeme.Price}$", "Soon!");
        }
        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            Meme selectedMeme = (Meme)LstView.SelectedItem;
            if (selectedMeme != null)
            {
                EditItemWindow editWindow = new EditItemWindow(selectedMeme);
                if (editWindow.ShowDialog() == true)
                {
                    // Refresh the ListView to show updated data
                    LstView.Items.Refresh();
                }
            }
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            LstView.ItemsSource = _memes;
            LstView.Items.Refresh();
        }

        private void SerchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            _searchText = SerchTB.Text;
            ApplyFiltersAndSorting();
        }

        private void FilterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedMemeType = (MemeType)FilterCB.SelectedItem;
            ApplyFiltersAndSorting();
        }

        private void FilterCB_DropDownClosed(object sender, EventArgs e)
        {
            _selectedMemeType = (MemeType)FilterCB.SelectedItem;
            ApplyFiltersAndSorting();
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
            SortCB.SelectedIndex = -1;
            _selectedSort = null;

            ApplyFiltersAndSorting();
        }

        private void ResetFiltersAndSorting()
        {
            FilterCB.SelectedIndex = -1;
            _selectedMemeType = null;
            SerchTB.Text = string.Empty;
            _searchText = string.Empty;

            ApplyFiltersAndSorting();
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SortCB.SelectedItem == null)
            {
                return; // Ничего не делать, если ничего не выбрано
            }

            _selectedSort = ((ComboBoxItem)SortCB.SelectedItem).Content.ToString();
            ApplyFiltersAndSorting();
        }

        private void ApplyFiltersAndSorting()
        {
            var filteredList = _memes;

            // Apply search filter
            if (!string.IsNullOrEmpty(_searchText))
            {
                filteredList = filteredList.Where(x => x.Title.Contains(_searchText, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            // Apply type filter
            if (_selectedMemeType != null)
            {
                filteredList = filteredList.Where(x => x.MemeType.Id == _selectedMemeType.Id).ToList();
            }

            // Apply sorting
            if (!string.IsNullOrEmpty(_selectedSort))
            {
                switch (_selectedSort)
                {
                    case "По возрастанию (А-Я)":
                        filteredList = filteredList.OrderBy(m => m.Title, StringComparer.CurrentCulture).ToList();
                        break;
                    case "По убыванию (Я-А)":
                        filteredList = filteredList.OrderByDescending(m => m.Title, StringComparer.CurrentCulture).ToList();
                        break;
                    case "По возрастанию цены":
                        filteredList = filteredList.OrderBy(m => m.Price).ToList();
                        break;
                    case "По убыванию цены":
                        filteredList = filteredList.OrderByDescending(m => m.Price).ToList();
                        break;
                }
            }

            LstView.ItemsSource = filteredList;
        }
    }
}