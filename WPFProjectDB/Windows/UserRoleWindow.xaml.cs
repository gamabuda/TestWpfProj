using System.Collections.ObjectModel;
using System.Windows;
using WPFProjectDB.Data;
using WPFProjectDB.DataBaseConnection;

namespace WPFProjectDB.Windows
{
    /// <summary>
    /// Interaction logic for UserRoleWindow.xaml
    /// </summary>
    public partial class UserRoleWindow : Window
    {
        public ObservableCollection<UserRole> UserRoles { get; set; }
        public UserRole SelectedUserRole { get; set; }
        public UserRoleWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadData();
        }

        private void LoadData()
        {
            UserRoles = new ObservableCollection<UserRole>(DataBaseManager.GetUserRole());
            UserRoleListView.ItemsSource = UserRoles;
        }

        private void AddUserRole_Click(object sender, RoutedEventArgs e)
        {
            var newUserRole = new UserRole { Title = "New Role" };
            if (DataBaseManager.AddRole(newUserRole))
            {
                UserRoles.Add(newUserRole);
            }
        }

        private void UpdateUserRole_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedUserRole != null)
            {
                DataBaseManager.UpdateRoles(SelectedUserRole);
                UserRoleListView.Items.Refresh();
            }
        }

        private void RemoveUserRole_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedUserRole != null)
            {
                if (DataBaseManager.RemoveRole(SelectedUserRole))
                {
                    UserRoles.Remove(SelectedUserRole);
                }
            }
        }
    }
}
