using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Cats.Data;

namespace Cats
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Cat> _Cats;
        private List<CatType> _currentFilter;
        private Sort _currentSort;
        private bool isReversed;
        public MainWindow()
        {
            InitializeComponent();
            _currentFilter = [];
            if (UserContext.CurrentUser.isAdmin != true)
            {
                EditMI.Visibility = Visibility.Collapsed;
                DeleteMI.Visibility = Visibility.Collapsed;
            }

            _Cats = DataBaseManager.GetAllCats();

            LstView.ItemsSource = _Cats;
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
                DataBaseManager.EditCat(editWindow.NewCat);
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
            if(filterWindow.DialogResult == false) return;
            _currentFilter = filterWindow.CatTypes;
            _currentSort = filterWindow.Sort;
            Filter();
        }

        private void Filter()
        {
            var lst = DataBaseManager.GetAllCats();
            lst = lst.Where(x => _currentFilter.Count == 0 || _currentFilter.Any(s => s == x.CatType)).ToList();
            if (_currentSort != null) lst = _currentSort.SortingFunc(lst);
            LstView.ItemsSource = Search(lst);
            LstView.Items.Refresh();

        }

        private void AddTypeBtn_OnClick(object sender, RoutedEventArgs e)
        {
            AddTypeWindow addWindow = new AddTypeWindow();
            addWindow.ShowDialog();
            if(addWindow.DialogResult == false) return;
            DataBaseManager.AddCatType(addWindow.NewType);
        }
    }
}
