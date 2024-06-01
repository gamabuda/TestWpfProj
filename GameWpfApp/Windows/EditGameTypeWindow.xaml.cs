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
using GameWpfApp.MainPages;

namespace GameWpfApp.Windows
{
    /// <summary>
    /// Interaction logic for EditGameTypeWindow.xaml
    /// </summary>
    public partial class EditGameTypeWindow : Window
    {
        private GameType _gameType;

        public EditGameTypeWindow(GameType gameType = null)
        {
            InitializeComponent();
            _gameType = gameType ?? new GameType();
            TitleTb.Text = _gameType.Title;
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
                string cursorFile = "Resources/BakedPotato.cur";
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

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            _gameType.Title = TitleTb.Text;

            if (_gameType.Id == 0)
            {
                if (DataBaseManager.AddGameType(_gameType))
                {
                    MessageBox.Show("Game type added successfully!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add game type.");
                }
            }
            else
            {
                if (DataBaseManager.UpdateGameType(_gameType))
                {
                    MessageBox.Show("Game type updated successfully!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update game type.");
                }
            }
        }
    }
}