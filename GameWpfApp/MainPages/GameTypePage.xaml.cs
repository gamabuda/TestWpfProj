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
using GameWpfApp.Data;
using GameWpfApp.DbConnection;
using GameWpfApp.Windows;

namespace GameWpfApp.MainPages
{
    /// <summary>
    /// Interaction logic for GameTypePage.xaml
    /// </summary>
    public partial class GameTypePage : Page
    {
        public GameTypePage()
        {
            InitializeComponent();

            if (UserContext.AuthUser.RoleId != 1)
            {
                MessageBox.Show("Access Denied. Admins only.");
                NavigationService.GoBack();
                return;
            }

            LoadData();
        }

        private void LoadData()
        {
            GameTypeDataGrid.ItemsSource = DataBaseManager.GetGameTypes();
        }

        private void EditMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedGameType = GameTypeDataGrid.SelectedItem as GameType;
            if (selectedGameType != null)
            {
                var editGameTypeWindow = new EditGameTypeWindow(selectedGameType);
                editGameTypeWindow.ShowDialog();
                LoadData();
            }
        }

        private void AddMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var editGameTypeWindow = new EditGameTypeWindow();
            editGameTypeWindow.ShowDialog();
            LoadData();
        }

        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedGameType = GameTypeDataGrid.SelectedItem as GameType;
            if (selectedGameType != null)
            {
                if (MessageBox.Show("Are you sure you want to delete this game type?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (DataBaseManager.RemoveGameType(selectedGameType))
                    {
                        MessageBox.Show("Game type deleted successfully!");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete game type.");
                    }
                }
            }
        }
    }
}