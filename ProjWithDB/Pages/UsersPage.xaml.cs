using ProjWithDB.Data;
using ProjWithDB.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjWithDB.Pages
{
    public partial class UsersPage : Page
    {
        private User _user;
        private List<User> _users;
        private List<User> _listView;
        private List<User> _searchList = new List<User>();
        private TextChangedEventArgs _searchInput;
        private List<string> _sortLetters = new List<string>() { "От А до Я", "От Я до А" };

        public UsersPage(User user)
        {
            InitializeComponent();
            _user = user;
            _users = DBManager.GetUsers();
            _listView = _users;

            DBManager.UpdateDatabase();
            LstView.ItemsSource = _listView;
            LoginFilter.ItemsSource = _sortLetters;
            RoleFilter.ItemsSource = DBManager.GetRoles();
        }

        private void DeletePerson_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = (User)LstView.SelectedItem;

            if (selectedUser == null)
                return;

            if (MessageBox.Show("Вы действительно хотите удалить этого пользователя?",
                    "Удаление информации",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                DBManager.RemoveUser(selectedUser);
                _users = DBManager.GetUsers();
            }

            SearchTB_TextChanged(sender, _searchInput);
            LstView.ItemsSource = _listView;
            LstView.Items.Refresh();
        }

        private void ViewPerson_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = (User)LstView.SelectedItem;

            if (selectedUser == null)
                return;

            new EditUserInfoWindow(selectedUser).ShowDialog();

            SearchTB_TextChanged(sender, _searchInput);
            DBManager.UpdateDatabase();
            _listView = DBManager.GetUsers();
            LstView.ItemsSource = _listView;
            LstView.Items.Refresh();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            _searchInput = e;

            if (!String.IsNullOrEmpty(SearchTB.Text))
                _searchList = _users.Where(x => x.Login.ToLower().StartsWith(SearchTB.Text.ToLower())).ToList();
            else
                _searchList.Clear();

            if (_searchList.Count > 0)
                _listView = _searchList;
            else if (_searchList.Count == 0 && SearchTB.Text.Length != 0)
                _listView.Clear();
            else if (SearchTB.Text.Length == 0)
                _listView = DBManager.GetUsers();

            LoginFilter_DropDownClosed(sender, e);
            RoleFilter_DropDownClosed(sender, e);

            LstView.ItemsSource = _listView;
            LstView.Items.Refresh();
        }

        private void LoginFilter_DropDownClosed(object sender, EventArgs e)
        {
            var type = LoginFilter.SelectedItem;
            if (type == null)
                return;

            if (type == "От А до Я")
                _listView = _listView.OrderBy(x => x.Login).ToList();
            else if (type == "От Я до А")
                _listView = _listView.OrderByDescending(x => x.Login).ToList();

            LstView.ItemsSource = _listView;
            LstView.Items.Refresh();
        }

        private void RoleFilter_DropDownClosed(object sender, EventArgs e)
        {
            var type = (Role)RoleFilter.SelectedItem;

            if (type == null)
                return;

            _listView = _listView.Where(x => x.Role_Id == type.Id).ToList();

            if (_searchList.Count > 0)
                _listView = _searchList.Where(x => x.Role_Id == type.Id).ToList();
            else if (_searchList.Count == 0 && SearchTB.Text.Length != 0)
                _listView.Clear();
            else if (SearchTB.Text.Length == 0)
                _listView = DBManager.GetUsers().Where(x => x.Role_Id == type.Id).ToList();

            LoginFilter_DropDownClosed(sender, e);
            LstView.ItemsSource = _listView;
            LstView.Items.Refresh();
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginFilter.SelectedItem = null;
            RoleFilter.SelectedItem = null;


            if (_searchList.Count > 0)
                _listView = _searchList;
            else
                _listView = _users;

            LoginFilter_DropDownClosed(sender, e);
            RoleFilter_DropDownClosed(sender, e);
            LstView.ItemsSource = _listView;
            LstView.Items.Refresh();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?",
                    "Выход из аккаунта",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _user = null;
                new AuthorizationWindow().Show();
                Window.GetWindow(this).Close();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddUserWindow().ShowDialog();
            DBManager.UpdateDatabase();
            _listView = DBManager.GetUsers();
            LstView.ItemsSource = _listView;
            LstView.Items.Refresh();
        }
    }
}
