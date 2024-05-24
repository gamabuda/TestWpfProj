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
using TestWpfProj.Windows;

namespace TestWpfProj
{
    public partial class MainWindow : Window
    {
        private List<RetroGame> _games;
        private List<GameType> _gameTypes;

        public MainWindow(User user)
        {
            InitializeComponent();

            _games = Data.DataContext.RetroGames;
            _gameTypes = Data.DataContext.GameTypes;

            LstView.ItemsSource = _games;
            FilterCB.ItemsSource = _gameTypes;

            MessageBox.Show($"Hello, {user.Login}!");
            MessageBox.Show($"Welcome back, {UserContext.User.Login}!");
            try
            {
                SetCustomCursor(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        private void SetCustomCursor(FrameworkElement element)
        {
            try
            {
                string cursorFile = "Resources/Cake.cur";
                var cursorStream = Application.GetResourceStream(new Uri(cursorFile, UriKind.Relative)).Stream;
                var customCursor = new Cursor(cursorStream);
                element.Cursor = customCursor;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
                throw;
            }
        }
    

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            RetroGame selectedGame = (RetroGame)LstView.SelectedItem;
            _games.Remove(selectedGame);

            LstView.ItemsSource = _games;
            LstView.Items.Refresh();
        }

        private void ViewMI_Click(object sender, RoutedEventArgs e)
        {
            RetroGame selectedGame = (RetroGame)LstView.SelectedItem;
            new ViewItemWindow1(selectedGame).ShowDialog();
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            RetroGame selectedGame = (RetroGame)LstView.SelectedItem;
            new EditItemWindow1(selectedGame).ShowDialog();
        }

        private void SerchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tempLst = _games;

            if (!String.IsNullOrEmpty(SerchTB.Text))
            {
                tempLst = _games.Where(x => x.Title.Contains(SerchTB.Text)).ToList();
            }

            LstView.ItemsSource = tempLst;
            LstView.Items.Refresh();
        }

        private void FilterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var filter = _games;

            var type = (GameType)FilterCB.SelectedItem;

            if (type == null)
                return;

            filter = filter.Where(x => x.GameType.Id == type.Id).ToList();
            LstView.ItemsSource = filter;
            LstView.Items.Refresh();
        }
        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SortCB.SelectedItem is ComboBoxItem selectedItem)
            {
                string sortCriteria = selectedItem.Content.ToString();

                switch (sortCriteria)
                {
                    case "Title A-Z":
                        _games = _games.OrderBy(x => x.Title).ToList();
                        break;
                    case "Title Z-A":
                        _games = _games.OrderByDescending(x => x.Title).ToList();
                        break;
                    case "Price Ascending":
                        _games = _games.OrderBy(x => x.Price).ToList();
                        break;
                    case "Price Descending":
                        _games = _games.OrderByDescending(x => x.Price).ToList();
                        break;
                }

                LstView.ItemsSource = _games;
                LstView.Items.Refresh();
            }
        }
    }
}