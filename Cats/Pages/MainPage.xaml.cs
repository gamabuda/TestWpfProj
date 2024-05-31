using Cats.Core;
using Cats.Windows;
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
using Cats.Service;

namespace Cats.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private List<Cat> _Cats;
        private List<CatType> _currentFilter;
        private Sort _currentSort;
        private bool isReversed;
        public MainPage()
        {
            InitializeComponent();
            _currentFilter = [];
            if (UserContext.CurrentUser.ID == "GUEST")
            {
                AddBtn.Visibility = Visibility.Collapsed;
            }
            if (UserContext.CurrentUser.isAdmin != true)
            {
                EditMI.Visibility = Visibility.Collapsed;
                DeleteMI.Visibility = Visibility.Collapsed;
            }

            _Cats = DataBaseManager.GetAllCats();

            LstView.ItemsSource = _Cats;
            DataContext = UserContext.AppViewModel;
            //UserLabel.Content = UserContext.CurrentUser.Nickname;

        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            Cat selectedCat = (Cat)LstView.SelectedItem;
            if (selectedCat == null) return;
            DeleteWindow deleteWindow = new DeleteWindow(selectedCat);
            deleteWindow.ShowDialog();
            if (deleteWindow.DialogResult == true)
            {
                DataBaseManager.RemoveCat(selectedCat);
                _Cats = DataBaseManager.GetAllCats();
                LstView.ItemsSource = _Cats;
                LstView.Items.Refresh();
            }
        }

        private void ViewMI_Click(object sender, RoutedEventArgs e)
        {
            Cat selectedCat = (Cat)LstView.SelectedItem;
            if (selectedCat == null) return;
            InfoWindow infoWindow = new InfoWindow(selectedCat);
            infoWindow.ShowDialog();
        }

        private void SerchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private List<Cat> Search(List<Cat> source)
        {
            if (!String.IsNullOrEmpty(SerchTB.Text))
            {
                source = source.Where(x => x.Name.ToLower().Contains(SerchTB.Text.ToLower())
                                           || x.CatType.Title.ToLower().Contains(SerchTB.Text.ToLower())
                                           || x.Birthday.ToShortDateString().ToLower().Contains(SerchTB.Text.ToLower())
                                           || x.User.Nickname.ToLower().Contains(SerchTB.Text.ToLower())).ToList();
            }
            return source;
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            Cat selectedCat = (Cat)LstView.SelectedItem;
            if (selectedCat == null) return;
            AddWindow editWindow = new AddWindow(selectedCat);
            editWindow.ShowDialog();
            if (editWindow.DialogResult == true)
            {
                DataBaseManager.UpdateCat(editWindow.NewCat);
                LstView.Items.Refresh();
            }
        }

        private void AddBtn_OnClick(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();
            if (addWindow.DialogResult == false) return;
            DataBaseManager.AddCat(addWindow.NewCat);
            _Cats = DataBaseManager.GetAllCats();
            LstView.ItemsSource = _Cats;
            LstView.Items.Refresh();
        }

        private void FilterBtn_OnClick(object sender, RoutedEventArgs e)
        {
            FilterWindow filterWindow = new FilterWindow(_currentFilter, _currentSort, isReversed);
            filterWindow.ShowDialog();
            if (filterWindow.DialogResult == false) return;
            _currentFilter = filterWindow.CatTypes;
            _currentSort = filterWindow.Sort;
            isReversed = filterWindow.Reversed;
            Filter();
        }

        private void Filter()
        {
            var lst = DataBaseManager.GetAllCats();
            lst = lst.Where(x => _currentFilter.Count == 0 || _currentFilter.Any(s => s == x.CatType)).ToList();
            if (_currentSort != null) lst = _currentSort.SortingFunc(lst);
            if (isReversed) lst.Reverse();
            LstView.ItemsSource = Search(lst);
            LstView.Items.Refresh();

        }
    }
}
