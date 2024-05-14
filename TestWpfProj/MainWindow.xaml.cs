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
    public partial class MainWindow : Window
    {
        private List<Child> _people;
        private List<Child> _listView;
        private List<string> _genders;
        private List<string> _sortLetters = new List<string>() { "От А до Я", "От Я до А" };
        private List<string> _sortNumbers = new List<string>() { "По возрастанию", "По убыванию" };
        public MainWindow()
        {
            InitializeComponent();

            _people = Data.DataContext.Children;
            _genders = Data.DataContext.Genders;
            _listView = _people;

            LstView.ItemsSource = _listView;
            SurnameFilter.ItemsSource = _sortLetters;
            NameFilter.ItemsSource = _sortLetters;
            PatronymicFilter.ItemsSource = _sortLetters;
            GenderFilter.ItemsSource = _genders;
            AgeFilter.ItemsSource = _sortNumbers;
            RoomNumberFilter.ItemsSource = _sortNumbers;
            MoveInDateFilter.ItemsSource = _sortNumbers;
        }

        private void DeletePerson_Click(object sender, RoutedEventArgs e)
        {
            Child selectedPerson = (Child)LstView.SelectedItem;
            _people.Remove(selectedPerson);
            SerchTB.Text = "";
            LstView.ItemsSource = _people;
            LstView.Items.Refresh();
        }

        private void ViewPerson_Click(object sender, RoutedEventArgs e)
        {
            Child selectedPerson = (Child)LstView.SelectedItem;
            MessageBox.Show($"Id: {selectedPerson.Id} \n" +
                $"Фамилия: {selectedPerson.Surname}\n" +
                $"Имя: {selectedPerson.Name}\n" +
                $"Отчество: {selectedPerson.Patronymic}\n" +
                $"Пол: {selectedPerson.Gender}\n" +
                $"Возраст: {selectedPerson.Age}\n" +
                $"Комната: {selectedPerson.RoomNumber}\n" +
                $"Дата заселения: {selectedPerson.MoveInDate}\n");
        }

        private void SerchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(SerchTB.Text))
                _listView = _people.Where(x => x.Surname.ToLower().StartsWith(SerchTB.Text) || x.Name.ToLower().StartsWith(SerchTB.Text) || x.Patronymic.ToLower().StartsWith(SerchTB.Text)).ToList();
            else
                _listView = _people;

            LstView.ItemsSource = _listView;
            LstView.Items.Refresh();
        }

        private void SurnameFilter_DropDownClosed(object sender, EventArgs e)
        {
            var type = SurnameFilter.SelectedItem;

            if (type == null)
                return;

            if (type == "От А до Я")
                _listView = _listView.OrderBy(x => x.Surname).ToList();
            else if (type == "От Я до А")
                _listView = _listView.OrderByDescending(x => x.Surname).ToList();

            NameFilter.SelectedItem = null;
            PatronymicFilter.SelectedItem = null;
            AgeFilter.SelectedItem = null;
            RoomNumberFilter.SelectedItem = null;
            MoveInDateFilter.SelectedItem = null;
            LstView.ItemsSource = _listView;
            LstView.Items.Refresh();
        }

        private void NameFilter_DropDownClosed(object sender, EventArgs e)
        {
            var type = NameFilter.SelectedItem;

            if (type == null)
                return;

            if (type == "От А до Я")
                _listView = _listView.OrderBy(x => x.Name).ToList();
            else if (type == "От Я до А")
                _listView = _listView.OrderByDescending(x => x.Name).ToList();
            
            SurnameFilter.SelectedItem = null;
            PatronymicFilter.SelectedItem = null;
            AgeFilter.SelectedItem = null;
            RoomNumberFilter.SelectedItem = null;
            MoveInDateFilter.SelectedItem = null;
            LstView.ItemsSource = _listView;
            LstView.Items.Refresh();
        }

        private void PatronymicFilter_DropDownClosed(object sender, EventArgs e)
        {
            var type = PatronymicFilter.SelectedItem;

            if (type == null)
                return;

            if (type == "От А до Я")
                _listView = _listView.OrderBy(x => x.Patronymic).ToList();
            else if (type == "От Я до А")
                _listView = _listView.OrderByDescending(x => x.Patronymic).ToList();

            SurnameFilter.SelectedItem = null;
            NameFilter.SelectedItem = null;
            AgeFilter.SelectedItem = null;
            RoomNumberFilter.SelectedItem = null;
            MoveInDateFilter.SelectedItem = null;
            LstView.ItemsSource = _listView;
            LstView.Items.Refresh();
        }

        private void GenderFilter_DropDownClosed(object sender, EventArgs e)
        {
            var type = GenderFilter.SelectedItem;

            if (type == null)
                return;

            _listView = _people.Where(_people => _people.Gender == type).ToList();
            NameFilter_DropDownClosed(sender, e);
            SurnameFilter_DropDownClosed(sender, e);
            PatronymicFilter_DropDownClosed(sender, e);
            AgeFilter_DropDownClosed(sender, e);
            RoomNumberFilter_DropDownClosed(sender, e);
            MoveInDateFilter_DropDownClosed(sender, e);
            LstView.ItemsSource = _listView;
            LstView.Items.Refresh();
        }


        private void AgeFilter_DropDownClosed(object sender, EventArgs e)
        {
            var type = AgeFilter.SelectedItem;

            if (type == null)
                return;

            if (type == "По возрастанию")
                _listView = _listView.OrderBy(x => x.Age).ToList();
            else if (type == "По убыванию")
                _listView = _listView.OrderByDescending(x => x.Age).ToList();

            SurnameFilter.SelectedItem = null;
            NameFilter.SelectedItem = null;
            PatronymicFilter.SelectedItem = null;
            RoomNumberFilter.SelectedItem = null;
            MoveInDateFilter.SelectedItem = null;
            LstView.ItemsSource = _listView;
            LstView.Items.Refresh();
        }

        private void RoomNumberFilter_DropDownClosed(object sender, EventArgs e)
        {
            var type = RoomNumberFilter.SelectedItem;

            if (type == null)
                return;

            if (type == "По возрастанию")
                _listView = _listView.OrderBy(x => x.RoomNumber).ToList();
            else if (type == "По убыванию")
                _listView = _listView.OrderByDescending(x => x.RoomNumber).ToList();

            SurnameFilter.SelectedItem = null;
            NameFilter.SelectedItem = null;
            PatronymicFilter.SelectedItem = null;
            AgeFilter.SelectedItem = null;
            MoveInDateFilter.SelectedItem = null;
            LstView.ItemsSource = _listView;
            LstView.Items.Refresh();
        }

        private void MoveInDateFilter_DropDownClosed(object sender, EventArgs e)
        {
            var type = MoveInDateFilter.SelectedItem;

            if (type == null)
                return;

            if (type == "По возрастанию")
                _listView = _listView.OrderBy(x => x.MoveInDate).ToList();
            else if (type == "По убыванию")
                _listView = _listView.OrderByDescending(x => x.MoveInDate).ToList();
            
            SurnameFilter.SelectedItem = null;
            NameFilter.SelectedItem = null;
            PatronymicFilter.SelectedItem = null;
            AgeFilter.SelectedItem = null;
            RoomNumberFilter.SelectedItem = null;
            LstView.ItemsSource = _listView;
            LstView.Items.Refresh();
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            SurnameFilter.SelectedItem = null;
            NameFilter.SelectedItem = null;
            PatronymicFilter.SelectedItem = null;
            GenderFilter.SelectedItem = null;
            AgeFilter.SelectedItem = null;
            RoomNumberFilter.SelectedItem = null;
            MoveInDateFilter.SelectedItem = null;

            _listView = _people;
            LstView.ItemsSource = _listView;
            LstView.Items.Refresh();
        }
    }
}
