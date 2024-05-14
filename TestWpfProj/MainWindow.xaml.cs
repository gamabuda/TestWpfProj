using System;
using System.Collections;
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
            AnyChanged();
        }

        private void FilterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AnyChanged();
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
            AnyChanged();
        }

        private void AnyChanged()
        {
            var tempLst = _memes;

            if (!String.IsNullOrEmpty(SerchTB.Text))
            {
                string searchText = SerchTB.Text.ToUpper();
                tempLst = tempLst.Where(x => x.Title.Split(' ').Any(word => word.StartsWith(searchText))).ToList();
            }

            var type = (MemeType)FilterCB.SelectedItem;
            if (type != null)
            {
                tempLst = tempLst.Where(x => x.MemeType.Id == type.Id).ToList();
            }

            var sortType = (ComboBoxItem)SortCB.SelectedItem;
            if (sortType != null)
            {
                switch (sortType.Content.ToString())
                {
                    case "По умолчанию":
                        break;
                    case "A-z":
                        tempLst = tempLst.OrderBy(x => x.Title).ToList();
                        break;
                    case "Z-a":
                        tempLst = tempLst.OrderByDescending(x => x.Title).ToList();
                        break;
                    case "По возрастанию цены":
                        tempLst = tempLst.OrderBy(x => x.Price).ToList();
                        break;
                    case "По убыванию цены":
                        tempLst = tempLst.OrderByDescending(x => x.Price).ToList();
                        break;
                }
            }

            LstView.ItemsSource = tempLst;
            LstView.Items.Refresh();
        }
        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            SerchTB.Text = "";
            FilterCB.SelectedItem = null;
            SortCB.SelectedItem = null;
            LstView.ItemsSource = _memes;
            LstView.Items.Refresh();
        }
    }
}
