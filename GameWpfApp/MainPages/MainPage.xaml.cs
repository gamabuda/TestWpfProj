using GameWpfApp.Data;
using GameWpfApp.DbConnection;
using GameWpfApp.Windows;
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

namespace GameWpfApp.MainPages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            GamesDataGrid.ItemsSource = DataBaseManager.GetGames();
        }

        private void GamesDataGrid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            if (dataGrid != null && dataGrid.SelectedItem != null)
            {
                dataGrid.ContextMenu.IsOpen = true;
            }
        }

        private void EditMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedGame = GamesDataGrid.SelectedItem as Game;
            if (selectedGame != null)
            {
                var editGameWindow = new EditGameWindow(selectedGame);
                editGameWindow.ShowDialog();
                LoadData();
            }
        }

        private void AddMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var editGameWindow = new EditGameWindow();
            editGameWindow.ShowDialog();
            LoadData();
        }

        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedGame = GamesDataGrid.SelectedItem as Game;
            if (selectedGame != null)
            {
                if (MessageBox.Show("Are you sure you want to delete this game?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (DataBaseManager.RemoveGame(selectedGame))
                    {
                        MessageBox.Show("Game deleted successfully!");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete game.");
                    }
                }
            }
        }
    }
}