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
            if (selectedMeme == null) return;
            DeleteWindow deleteWindow = new DeleteWindow(selectedMeme);
            deleteWindow.ShowDialog();
            if(deleteWindow.DialogResult == true)
            {
                _memes.Remove(selectedMeme);

                LstView.ItemsSource = _memes;
                LstView.Items.Refresh();
            }
        }

        private void ViewMI_Click(object sender, RoutedEventArgs e)
        {
            Meme selectedMeme = (Meme)LstView.SelectedItem;
            if (selectedMeme == null) return;
            MessageBox.Show($"Id:{selectedMeme.Id} \nTitle: {selectedMeme.Title}\nType: {selectedMeme.MemeType.Title}\nPrice: {selectedMeme.Price}$", "Soon!");
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            LstView.ItemsSource = _memes;
            LstView.Items.Refresh();
        }

        private void SerchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
            var lst = (List<Meme>)LstView.ItemsSource;
            lst = Search(lst);
            LstView.ItemsSource = lst;
            LstView.Items.Refresh();
        }

        private List<Meme> Search(List<Meme> source)
        {
            if (!String.IsNullOrEmpty(SerchTB.Text))
            {
                source = source.Where(x => x.Title.ToLower().Contains(SerchTB.Text.ToLower())).ToList();
            }
            return source;
        }

        private void FilterCB_DropDownClosed(object sender, EventArgs e)
        {
            Filter();
        }
        private void Filter()
        {
            var filter = _memes;

            var type = (MemeType)FilterCB.SelectedItem;

            if (type == null) 
            { 
                filter = Search(filter);
                LstView.ItemsSource = filter;
                return;
            }
            filter = filter.Where(x => x.MemeType.Id == type.Id).ToList();

            var sort = (Sort)SortCB.SelectedItem;
            filter = sort.Action(filter);
            if (SerchTB.Text != "")
                filter = Search(filter);
            LstView.ItemsSource = filter;
            LstView.Items.Refresh();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FilterCB.SelectedValue = null;
            Filter();
        }

        private void SortCB_DropDownClosed(object sender, EventArgs e)
        {
            var list = (List<Meme>)LstView.ItemsSource;

            var sort = (Sort)SortCB.SelectedItem;

            list = sort.Action.Invoke(list);
            LstView.ItemsSource = list;
            LstView.Items.Refresh();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            Meme selectedMeme = (Meme)LstView.SelectedItem;
            if (selectedMeme == null) return;
            EditWindow editWindow = new EditWindow(selectedMeme.Title, selectedMeme.Price, selectedMeme.MemeType);
            editWindow.ShowDialog();
            if(editWindow.DialogResult == true)
            {
                selectedMeme.Title = editWindow.Title;
                selectedMeme.Price = editWindow.Price;
                selectedMeme.MemeType = editWindow.MemeType;
                LstView.Items.Refresh();
            }
        }
    }
}
