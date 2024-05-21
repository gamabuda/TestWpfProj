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
using TestWpfProj.Data;

namespace TestWpfProj.Windows
{
    public partial class EditItemWindow1 : Window
    {
        private RetroGame _game;

        public EditItemWindow1(RetroGame game)
        {
            InitializeComponent();
            _game = game;

            ObjectTitle.Text = _game.Title;
            TitleTB.Text = _game.Title;
            GameTypeCB.ItemsSource = Data.DataContext.GameTypes;
            GameTypeCB.SelectedItem = _game.GameType;
            PriceTB.Text = _game.Price.ToString();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            _game.Title = TitleTB.Text;
            _game.GameType = (GameType)GameTypeCB.SelectedItem;
            _game.Price = decimal.Parse(PriceTB.Text);

            Close();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}