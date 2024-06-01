using GameWpfApp.Data;
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
using System.Windows.Shapes;
using GameWpfApp.DbConnection;

namespace GameWpfApp.Windows
{
    /// <summary>
    /// Interaction logic for EditGameWindow.xaml
    /// </summary>
    public partial class EditGameWindow : Window
    {
        private Game _game;
        private bool _isEditMode;

        public EditGameWindow(Game game = null)
        {
            InitializeComponent();
            LoadGameTypes();
            LoadUsers();

            if (game != null)
            {
                _isEditMode = true;
                _game = game;
                LoadGameDetails();
            }
            else
            {
                _game = new Game();
                _isEditMode = false;
            }
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
                string cursorFile = "Resources/GoldenApple.cur";
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
        private void LoadGameTypes()
        {
            GameTypeComboBox.ItemsSource = DataBaseManager.GetGameTypes();
            GameTypeComboBox.DisplayMemberPath = "Title";
            GameTypeComboBox.SelectedValuePath = "Id";
        }

        private void LoadUsers()
        {
            OwnerComboBox.ItemsSource = DataBaseManager.GetUsers();
            OwnerComboBox.DisplayMemberPath = "Login";
            OwnerComboBox.SelectedValuePath = "Id";
        }

        private void LoadGameDetails()
        {
            TitleTextBox.Text = _game.Title;
            DatePublishingPicker.SelectedDate = _game.DataPublishing;
            GameTypeComboBox.SelectedValue = _game.GameTypeId;
            DescriptionTextBox.Text = _game.Description;
            OwnerComboBox.SelectedValue = _game.OwnerId;
            ImageTextBox.Text = _game.Image?.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _game.Title = TitleTextBox.Text;
            _game.DataPublishing = DatePublishingPicker.SelectedDate.Value;
            _game.GameTypeId = (int)GameTypeComboBox.SelectedValue;
            _game.Description = DescriptionTextBox.Text;
            _game.OwnerId = (int?)OwnerComboBox.SelectedValue;
            _game.Image = string.IsNullOrEmpty(ImageTextBox.Text) ? null : System.Text.Encoding.UTF8.GetBytes(ImageTextBox.Text);

            if (_isEditMode)
            {
                if (DataBaseManager.UpdateGame(_game))
                    MessageBox.Show("Game updated successfully!");
                else
                    MessageBox.Show("Failed to update game.");
            }
            else
            {
                if (DataBaseManager.AddGame(_game))
                    MessageBox.Show("Game added successfully!");
                else
                    MessageBox.Show("Failed to add game.");
            }

            DataBaseManager.UpdateDatabase();
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}