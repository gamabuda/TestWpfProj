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
            SortCB.ItemsSource = Sorts.SortList;
            SortCB.SelectedItem = Sorts.SortList[0];
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
            var tempLst = (List<Meme>)LstView.ItemsSource;

            if(!String.IsNullOrEmpty(SerchTB.Text))
            {
                tempLst = _memes.Where(x => x.Title.Contains(SerchTB.Text)).ToList();
            }

            LstView.ItemsSource = tempLst;
            LstView.Items.Refresh();
        }

        private void FilterCB_DropDownClosed(object sender, EventArgs e)
        {
            var filter = _memes;

            var type = (MemeType)FilterCB.SelectedItem;

            if (type == null)
                return;

            filter = filter.Where(x => x.MemeType.Id == type.Id).ToList();

            var sort = (Sort)SortCB.SelectedItem;
            filter = sort.Action(filter);

            LstView.ItemsSource = filter;
            LstView.Items.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FilterCB.SelectedValue = null;
            LstView.ItemsSource = _memes;
            LstView.Items.Refresh();
        }

        private void SortCB_DropDownClosed(object sender, EventArgs e)
        {
            var list = (List<Meme>)LstView.ItemsSource;

            var sort = (Sort)SortCB.SelectedItem;

            list = sort.Action.Invoke(list);
            LstView.ItemsSource = list;
            LstView.Items.Refresh();
        }
    }
}
