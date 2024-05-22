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
        private List<CatType> _CatTypes;
        public MainWindow()
        {
            InitializeComponent();

            _Cats = DataBaseManager.GetAllCats();
            _CatTypes = DataBaseManager.GetAllCatTypes();

            LstView.ItemsSource = _Cats;
            FilterCB.ItemsSource = _CatTypes;
            SortCB.ItemsSource = SortsList.SortList;
            SortCB.SelectedItem = SortsList.SortList[0];
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            Cat selectedCat = (Cat)LstView.SelectedItem;
            if (selectedCat == null) return;
            DeleteWindow deleteWindow = new DeleteWindow(selectedCat);
            deleteWindow.ShowDialog();
            if (deleteWindow.DialogResult == true)
            {
                _Cats.Remove(selectedCat);

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
            //MessageBox.Show($"Id:{selectedCat.Id} \nName: {selectedCat.Name}\nType: {selectedCat.CatType.Title}\nBirthday: {selectedCat.Birthday.BirthdayString}");
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            LstView.ItemsSource = _Cats;
            LstView.Items.Refresh();
        }

        private void SerchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
            var lst = (List<Cat>)LstView.ItemsSource;
            lst = Search(lst);
            LstView.ItemsSource = lst;
            LstView.Items.Refresh();
        }

        private List<Cat> Search(List<Cat> source)
        {
            if (!String.IsNullOrEmpty(SerchTB.Text))
            {
                source = source.Where(x => x.Name.ToLower().Contains(SerchTB.Text.ToLower())).ToList();
            }
            return source;
        }

        private void FilterCB_DropDownClosed(object sender, EventArgs e)
        {
            Filter();
        }
        private void Filter()
        {
            var filter = _Cats;

            var type = (CatType)FilterCB.SelectedItem;

            if (type == null)
            {
                filter = Search(filter);
                LstView.ItemsSource = filter;
                return;
            }
            filter = filter.Where(x => x.CatType.ID == type.ID).ToList();

            var sort = (Sort)SortCB.SelectedItem;
            filter = sort.SortingFunc(filter);
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
            var list = (List<Cat>)LstView.ItemsSource;

            var sort = (Sort)SortCB.SelectedItem;

            list = sort.SortingFunc.Invoke(list);
            LstView.ItemsSource = list;
            LstView.Items.Refresh();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            Cat selectedCat = (Cat)LstView.SelectedItem;
            if (selectedCat == null) return;
            EditWindow editWindow = new EditWindow(selectedCat.Name, selectedCat.Birthday, selectedCat.CatType);
            editWindow.ShowDialog();
            if (editWindow.DialogResult == true)
            {
                selectedCat.Name = editWindow.Name;
                selectedCat.Birthday = editWindow.Birthday;
                selectedCat.CatType = editWindow.CatType;
                LstView.Items.Refresh();
            }
        }
    }
}
